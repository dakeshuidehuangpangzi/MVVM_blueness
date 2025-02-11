

using Platform.Extensions.Enum;
using Platform.Extensions.Interfaces;
using System.Windows;

namespace MvvmDialoging
{
    public class DialogService : IDialogService
    {
        public delegate void Delegate3Btn(EDialogResult result);

        public static List<Delegate3Btn> On3Btn = new List<Delegate3Btn>();

        private readonly ILogger logger;
        private readonly IDialogFactory dialogFactory;
        private readonly IDialogTypeLocator dialogTypeLocator;
        private readonly IFrameworkDialogFactory frameworkDialogFactory;
        private readonly DialogViewModelLocatorCache cache;

        public DialogService(IDialogTypeLocator? dialogTypeLocator=null, IDialogFactory? dialogFactory=null,IFrameworkDialogFactory? frameworkDialogFactory=null)
        {
            //this.logger = logger;
            this.dialogFactory = dialogFactory ?? new ReflectionDialogFactory();
            this.dialogTypeLocator = dialogTypeLocator ?? new NamingCinventionDialogTypeLocator();
            this.frameworkDialogFactory = frameworkDialogFactory ?? new DefaultFrameworkDialogFactory();
            cache = new();
        }


        #region 接口

        public bool CloseDialog(IviewModel viewModel) 
        {
            return OperationDialog(viewModel,EOperationDialog.Close); 
        }

        public bool OperationDialog(IviewModel viewModel, EOperationDialog operationDialog)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            if (Application.Current.Dispatcher.Thread.IsThreadPoolThread == Thread.CurrentThread.IsThreadPoolThread)
            {
                foreach (Window? window in Application.Current.Windows)
                {
                    if (window == null || !viewModel.Equals(window.DataContext)) continue;
                    try
                    {
                        switch (operationDialog)
                        {
                            case EOperationDialog.Close:
                                window.Close();
                                cache.Remove(viewModel);
                                break;
                            case EOperationDialog.DragMove:
                                window.DragMove();
                                break;
                            case EOperationDialog.Hide:
                                window.Hide();
                                break;
                            case EOperationDialog.Show:
                                window.Show();
                                break;
                            case EOperationDialog.WindowState_Minimized:
                                window.WindowState = WindowState.Minimized;
                                break;
                            case EOperationDialog.WindowState_Maximized:
                                window.WindowState = WindowState.Maximized;
                                break;
                            case EOperationDialog.WindowState_Normal:
                                window.WindowState = WindowState.Normal;
                                break;
                            default:
                                break;
                        }
                        return true;
                    }
                    catch (Exception )
                    {
                        break;
                    }
                }
            }
            else
            {
                bool is_ok = false;
                Application.Current.Dispatcher.Invoke(() => {

                    foreach (Window? window in Application.Current.Windows)
                    {
                        if (window == null || !viewModel.Equals(window.DataContext)) continue;
                        try
                        {
                            switch (operationDialog)
                            {
                                case EOperationDialog.Close:
                                    window.Close();
                                    cache.Remove(viewModel);
                                    break;
                                case EOperationDialog.DragMove:
                                    window.DragMove();
                                    break;
                                case EOperationDialog.Hide:
                                    window.Hide();
                                    break;
                                case EOperationDialog.Show:
                                    window.Show();
                                    break;
                                case EOperationDialog.WindowState_Minimized:
                                    window.WindowState = WindowState.Minimized;
                                    break;
                                case EOperationDialog.WindowState_Maximized:
                                    window.WindowState = WindowState.Maximized;
                                    break;
                                case EOperationDialog.WindowState_Normal:
                                    window.WindowState = WindowState.Normal;
                                    break;
                                default:
                                    break;
                            }
                            is_ok = true;
                            return;
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                });
                return is_ok;
            }
            return false;
        }

        public void Show(IviewModel viewModel, IviewModel? ownerModel = null)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            Type dialogType = dialogTypeLocator.Locate(viewModel);
            Show(viewModel, dialogType, ownerModel);
        }

        public EDialogResult ShowDiaglogOther(EloggerLevel level, string message, string title = "", EShowDialogBtnState state = EShowDialogBtnState.OkCancel)
        {
            var viewModel = new OtherShowDialogViewModel (logger, level, message, title, state );
            Type dialogType = dialogTypeLocator.Locate(viewModel);
            return ShowDialog(viewModel, dialogType);
        }

        public EDialogResult ShowDialog<T>(T viewModel, IviewModel ownerViewModel = null) where T : ViewModelBaseDialog
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            Type dialogType = dialogTypeLocator.Locate(viewModel);
            return ShowDialog(viewModel, dialogType, ownerViewModel);
        }

        public EDialogResult ShowDialogAsync<T>(T viewModel, IviewModel ownerViewModel = null) where T : ViewModelBaseDialogAsync
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            Type dialogType = dialogTypeLocator.Locate(viewModel);
            return ShowDialogAsunc(viewModel, dialogType, ownerViewModel);
        }

        public void ShowSingleton(IviewModel viewModel, IviewModel? ownerModel = null)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            var window = GetWindow(viewModel);
            if (window != null) return;
            Type dialogType = dialogTypeLocator.Locate(viewModel);
            Show(viewModel, dialogType, ownerModel);
        }


        #endregion

        #region 私有方法

        private EDialogResult ShowDialog(ViewModelBaseDialog viewModel,Type dialogType,IviewModel?ownerViewModel=null)
        {
            iWindow dialog = CreateDialog(dialogType, viewModel, ownerViewModel);
            On3Btn.Add(dialog.Click3Btn);
            viewModel.AddBeginLog();
            dialog.ShowDialg();
            viewModel.AddEndLog();
            On3Btn.Remove(dialog.Click3Btn);
            return viewModel.DialogResult;
        }

        private EDialogResult ShowDialogAsunc(ViewModelBaseDialogAsync viewModel, Type dialogType, IviewModel? ownerViewModel = null)
        {
            var tc = new TaskCompletionSource<EDialogResult>();
            Thread td = new Thread(() => {
                try
                {
                    iWindow dialog = CreateDialog(dialogType, viewModel, ownerViewModel);
                    On3Btn.Add(dialog.Click3Btn);
                    viewModel.AddBeginLog();
                    dialog.ShowDialg();
                    viewModel.AddEndLog();
                    On3Btn.Remove(dialog.Click3Btn);
                    tc.SetResult(viewModel.DialogResult);
                }
                catch (Exception ex)
                {
                    viewModel.AddErrorLog(ex);
                    tc.SetException(ex);
                }
            });
            td.TrySetApartmentState(ApartmentState.STA);
            td.IsBackground = true;
            td.Start();
            try
            {
                EDialogResult result = tc.Task.GetAwaiter().GetResult();
                return result;
            }
            catch (Exception ex)
            {
                tc.SetException(ex);
                return EDialogResult.None;
            }
        }

        private void Show(IviewModel viewModel,Type dialogType,IviewModel? ownerModel=null)
        {
            iWindow dialog = CreateDialog(dialogType, viewModel, ownerModel);
            dialog.Show();
        }

        private iWindow CreateDialog( Type dialogType,IviewModel viewModel,IviewModel? ownerViewModel=null)
        {
            var dialog = dialogFactory.Create(dialogType);
            if (Application.Current.Dispatcher.Thread.ManagedThreadId == Thread.CurrentThread.ManagedThreadId)
            {
                if (Application.Current.MainWindow.IsActive)
                    dialog.Owner = Application.Current.MainWindow;
            }
            dialog.DataContext = viewModel;
            dialog.SetWindowStartupLocation(WindowStartupLocation.CenterScreen);
            cache.TryAdd(viewModel, dialog);
            return dialog;
        }
        private Window?GetWindow(IviewModel?viewModel)
        {
            if (viewModel == null) return null;
            Window? result = null;
            if (Application.Current.Dispatcher.Thread.ManagedThreadId == Thread.CurrentThread.ManagedThreadId)
            {
                foreach (Window? window in Application.Current.Windows)
                {
                    if (window?.DataContext is IviewModel vm && viewModel.Equals(vm))
                    {
                        result = window;
                        break;
                    }
                }
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach (Window? window in Application.Current.Windows)
                    {
                        if (window?.DataContext is IviewModel vm && viewModel.Equals(vm))
                        {
                            result = window;
                            break;
                        }

                    }
                });
            }
            return result;
        }
        #endregion
    }

}

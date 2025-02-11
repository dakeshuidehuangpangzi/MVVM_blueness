using Platform.Extensions.Enum;

namespace Platform.Extensions.Interfaces
{
    public interface IDialogService
    {
        /// <summary>
        /// 阻塞弹框
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="viewModel"></param>
        /// <param name="ownerViewModel"></param>
        /// <returns></returns>
        EDialogResult ShowDialog<T>(T viewModel, IviewModel ownerViewModel = null) where T : ViewModelBaseDialog;
        /// <summary>
        /// 阻塞弹框， 不阻塞UI线程
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="viewModel"></param>
        /// <param name="ownerViewModel"></param>
        /// <returns></returns>
        EDialogResult ShowDialogAsync<T>(T viewModel, IviewModel ownerViewModel = null) where T : ViewModelBaseDialogAsync;
        /// <summary>
        /// 非阻塞弹窗  当出现有该类型弹框时就不会再创建
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="ownerModel"></param>
        void Show(IviewModel viewModel, IviewModel? ownerModel = null);
        /// <summary>
        /// 关闭指定窗口
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="ownerModel"></param>
        void ShowSingleton(IviewModel viewModel, IviewModel? ownerModel = null);
        bool CloseDialog(IviewModel viewModel);
        /// <summary>
        /// 操作已存在的窗口
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="operationDialog"></param>
        /// <returns></returns>
        bool OperationDialog(IviewModel viewModel, EOperationDialog operationDialog);
        /// <summary>
        /// 阻塞弹窗 其他模块使用
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        EDialogResult ShowDiaglogOther(EloggerLevel level, string message, string title = "", EShowDialogBtnState state = EShowDialogBtnState.OkCancel);


    }
}

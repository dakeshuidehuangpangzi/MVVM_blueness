   M S B A M L   `   `   `  ����H  DMVVM_Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MVVM_PlatformMVVM_Platform  5          MVVM_Platform.MainView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:MVVM_Platform     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $
��1200��5	      $	��800��5
      ���#f1f5fd$��Microsoft YaHei)�5      $��12(�5      $��
ExtraLight"�5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5      '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 1q�6    � 	Resources 5       �� MergedDictionaries �� Source   Key �� 
TargetType	 �� Property
 �� Value �� 
TargetType ��Name �� CornerRadius � RowDefinitions  Iconfont J� Opacity �� Triggers P� Property P� Value �� 
TargetName�� 5   
    5      �� 5      $F @pack://application:,,,/Assets;component/Styles/ButtonStyles.xaml?�6%   �� 5      �� 5      MenuButtonStyle  " 	�64   .�5      �� 	 � ��$
 5q�63   �� 5      	 � ��
 5      �� 5   "   " 	�62   .R�5   &   �� $
 root��5    )   
������ $��1q�5"   )   $ 8��5#   )   ._�5$   *   �  5%   .   �� 5&   2   �� 5'   2   $��24 �6@   .+�5)   .   �� $
��icon��5*   1   $��0,8,0,0q�5+   1   $��Center=�5,   1   $��Center=�5-   1   #��[ 5.   1   $��28(�5/   1   ���	#66000000$	 0.7Q�51   1   ��52   1   �� *
MenuIcon+�� 53   .   $��header��54   1   $��1��55   1   $��Center=�56   1   $��Center=�57   1   $��11(�58   1   ���	#99000000��5:   1   �� *
MenuHeader+5;   +   5=   '    5>   &   P� 5?   *    �@d�	IsChecked$
 TrueY�6G   . �5@   .   �� $
 root��65   	 � ��
 �	#2216a1ff6]   �� 5A   .   $
 root��65   	 � ��
 �	#4416a1ff6^   �� 5B   .   $
 icon��65   	 � ��

 � ���6]   5C   +   5E   #   5G      5H      5I      %    5K      .��5M      �  J� Effect 5N   
   -  'System.Windows.Media.Effects.BlurEffect  5O         Radius$ 0Q�6    5Q   
   �� 5R      $��50 �6   �� 5S       � ColumnDefinitions 5U   
   �� 5V      $	��100 �6   �� 5W      $��* �6   .+�5Z   
   � $��2��6   .+�5[      �� $��Right=�6    �� Orientation$ 
Horizontal=�65   .+�5\      �� -   5        $��40��5]      $��30��5^      $��20,0,0,0q�5_      $��Center=�5`      $��Center=�5a      $	����5c      #��[ 5d      ���#555  WindowControlButtonStyle#��[ 5f      �� 5g      -   5        $��40��5h      $��30��5i      $��Center=�5j      $��Center=�5k      $	����5m      #��[ 5n      ���#555#��[ 5p      5q      5r      �� 5t   
   $��1��6   ��5u      �� 5v       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��5w      �  � Offset$	 0.1Q�6#    � Color$ Transparent��60   � 5x      $	 0.2Q�6#   $ 	#1116a1ff��60   � 5y      $	 0.5Q�6#   $ 	#1116a1ff��60   � 5z      $ 1Q�6#   $ Transparent��6.   5{      ��5}      �� 5~      $	 0,0&�6&   $	 0,1&�67   .��5      � $ 0Q�6#   $ Transparent��6.   � 5�      $	 0.3Q�6#   $
 Gold��60   � 5�      $ 1Q�6#   $ Transparent��6.   5�      ._�5�      �� $��	0,0,0,100q�5�      $��Center=�5�      ��5�      �� *Menus+��5�      �� 5�      .R�5�      	�  	� 	GroupName$
 menu��5�        MenuButtonStyle#��[ 5�      ��5�      �� *DataContext.ShowPageCommand+ �� RelativeSource ��  �� AncestorType
 Window��5�      ��  d� 	IsChecked 5�      �� *
IsSelected+5�      5�      5�      5�      � 5�   
   $��1��6   $��1��6   .+�5�      >� $	��0,5q�6   ��6'   �� *ViewContent+5�      5�      5�      
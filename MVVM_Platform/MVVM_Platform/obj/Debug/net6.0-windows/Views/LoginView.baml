   M S B A M L   `   `   `  ����H  DMVVM_Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MVVM_PlatformMVVM_Platform  5      D @UIControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:UIControl;assembly=UIControl	UIControl 5          MVVM_Platform.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:MVVM_Platform     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      9ui*clr-namespace:UIControl;assembly=UIControl     5      -   5        $	��win��5	        � Title$  登录界面��5
      $	��250��5      $	��450��5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5      '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 1q�6    � 	Resources 5       �� MergedDictionaries   Key �� 
TargetType �� Property	 �� Value3  -System.Windows.Media.Effects.DropShadowEffect
   
BlurRadius   Opacity   ShadowDepth   Color �� 
TargetType ��Name �� CornerRadius �� 
StartPoint �� EndPoint � Offset � Color 
� Center 
� GradientOrigin 
� RadiusX 
� RadiusY �� Triggers P� Property P� Value �� 
TargetName �� Triggers �� Binding �� Path  �� RelativeSource! �� Mode" �� Value# �� Source�� 5   
    5      �� 5      �� 5      NormalButtonStyle  " ��66   .�5      ��  �@J�Effect	 5        5   "   $
 10Q�5   %   $	 0.1Q�5   %   $ 0Q�5   %   $
 #333��5   %   5!      �� 5"       � ��
	 ���� 67   �� 5#       � ��
	 �����67   �� 5$       � ��	 5%      �� 5&   "   " ��62   .R�5'   &   �� $	 bor��5(   )   ���#16a1ff$��1q�5*   )   $
}�True��5+   )   $ 9��5,   )   ��5-   *   �� 5.   .   $	 0,1&�6B   $	 1,0&�6S   .��5/   2   � $	 0.3Q�6?   $ #16a1ff��6L   � 50   2   $ 1Q�6?   $ #01c8fe��6J   51   /   ._�53   *   � .+�54   .   �� $ 5��65   ��55   2   
� 56   6   $	 0,1&�6J   $	 0,1&�6W   $	 0.4Q�6l   $	 0.8Q�6z   .��57   :   � $	 0.2Q�6G   $ 	#88b4fee7��6T   � 58   :   $ 1Q�6G   $ Transparent��6R   59   7   5;   /   �� 5<   .   #��z��65   $ 4��6_   �� 5=   .   $
��mask��5>   1   ���	#11000000$ 5��5@   1   $y�	Collapsed=�5A   1   �� 5C   .   #��z��6?   #��z��6�   5D   +   5E   '    5F   &   P� 5G   *    �@J�IsMouseOver$
 True��6I   . �5H   .   �� $
 mask��65    � y�$	 Visible=�6]   5I   +   P� 5J   *    � {�$ False��6G   . �5K   .   �� $	 bor��65    � y�$	 	Collapsed=�6\   5L   +   5O   #   5Q      5R      �� 5S      TextBlockStyle  " ��63   .�5T      ��  � ��
	 �  ��67   �� 5U       � ��$	 Center=�6@   �� 5V       � ��$	 Center=�6>    5W      �� 5X       6*   �� $
 Text�  �� $
! Self=�"  6s   .a�5Y   "   ��  � y�$	 	Collapsed=�6?   5Z      5\      5]      �� 5^      $;# 5pack://application:,,,/UIControl;component/Style.xaml?�6%   %    5`      .��5b      � $
}�True��6   .+�5c   
   A� $	��300��5d      $	��600��5e      $��0,-200,-200,0q�5f      $��Right=�5g      $	��Top=�5h      ��5i      
� 5j      .��5k      � $ 0Q�6#   $ #c2e0fa��6.   � 5l      $ 1Q�6#   $ #f1f5fd��6.   5m      5o      A� 5p   
   $	��300��5q      $	��600��5r      $��-180,-180,0,0q�5s      $
��Left=�5t      $	��Top=�5u      ��5v      
� 5w      .��5x      � $ 0Q�6#   $ #b4fee7��6.   � 5y      $ 1Q�6#   $ Transparent��6.   5z      5|      � 5}   
   $
��35,0q�6   $ � RowDefinitions$ 5~      �� 5      $��50 �6    �� 5�      $��* �6    �� 5�      $	�� 30 �6    �� 5�      $��30 �6    �� 5�      $��30 �6    �� 5�      $��40 �6    �� 5�      $��50 �6    �� 5�      $��50 �6    �� 5�      $��50 �6    �� 5�      $��50 �6    �� 5�      $��* �6    .+�5�      �� $��3��5�      $��Center=�5�      ��5�      �� *User.UserName+�� 5�      $��4��5�      $��Center=�5�      ��5�      �� *User.Password+�� 5�      $��5��5�        TextBlockStyle#��[ 5�      ��5�      �� *ErrorMessage+  UIControl.Cylinder  5�      $��7��5�      $��	登   录��5�      $��20(�5�      
�������5�      �� 5�      $��6��5�      $��	登   录��5�        NormalButtonStyle#��[ 5�      ��5�      �� *LoginCommand+��5�      �� % �� ElementName$	% win��{�5�      �� *	IsLogin+5�      �� 5�      $��8��5�      $��登 录��5�        ButtonStyle#��[ 5�      5�      5�      5�      
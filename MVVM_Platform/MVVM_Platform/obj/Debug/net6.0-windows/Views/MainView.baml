   M S B A M L   `   `   `  ����H  DMVVM_Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MVVM_PlatformMVVM_Platform  5   	       MVVM_Platform.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MVVM_Platform     5   	     � 
ResizeMode$  NoResize=�5   	   $��Microsoft YaHei)�5	   	   $��12(�6&   $��
ExtraLight"�64    � WindowStartupLocation$ CenterScreen=�5
   	   ���#f1f5fd � Title$ 
MainWindow��5   	   $	��800��6   $
��1200��6)   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 1q�6    � 	Resources 5       �� MergedDictionaries �� Source   Key �� 
TargetType	 �� Property
 �� Value �� 
TargetType ��Name �� CornerRadius � RowDefinitions  Iconfont J� Opacity �� Triggers P� Property P� Value �� 
TargetName�� 5   
    5      �� 5      $F @pack://application:,,,/Assets;component/Styles/ButtonStyles.xaml?�6%   �� 5      �� 5      MenuButtonStyle  " 	�64   .�5      �� 	 � ��$
 5q�63   �� 5      	 � ��
 5      �� 5   "   " 	�62   .R�5   &   �� $
 root��6-   
������ $��1q�6U   $ 8��6i   ._�5   *   �  5   .   �� 5   2   �� 5   2   $��24 �6@   .+�5   .   �� $
��icon��5#   O   $��Center=�5    9   $��Center=�6T   #��[ 5!   8   $��28(�6`   $��0,8,0,0q�5"   8   ���	#66000000$	 0.7Q�5#   [   ��5   8   �� *
MenuIcon+5#   [   �� 5$   .   $��header��5&   O   $��Center=�5%   9   $��Center=�6T   ���	#99000000$��1��5&   ]   $��11(�6j   ��5$   8   �� *
MenuHeader+5&   j   5'   +   5)   '    5*   &   P� 5+   *    �@d�	IsChecked$
 TrueY�6G   . �5,   .   �� $
 root��6]   	 � ��
 �	#2216a1ff�� 5-   .   $
 root��6^   	 � ��
 �	#4416a1ff�� 5.   .   $
 icon��6K   	 � ��

 � ���6]   5/   +   51   #   53      54      55      %    57      .��59      �  J� Effect 5:   
   -  'System.Windows.Media.Effects.BlurEffect  5;         Radius$ 0Q�6    5=   
   �� 5>      $��50 �6   �� 5?       � ColumnDefinitions 5A   
   �� 5B      $	��100 �6   �� 5C      $��* �6   .+�5F   
   � $��2��6   .+�5G      �� $��Right=�6    �� Orientation$ 
Horizontal=�65   .+�5H      �� -   5        $	����5H      $��30��6-   $��40��69   $��20,0,0,0q�6D   ���#555$��Center=�5J      $��Center=�5K        WindowControlButtonStyle#��[ 5L      #��[ 6K   �� 5M      -   5        $	����5M      $��30��6,   $��40��68   ���#555$��Center=�5O      $��Center=�5P      #��[ 5Q      #��[ 6K   5R      5S      �� 5U   
   $��1��6   ��5V      �� 5W       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��5X      �  � Color$ Transparent��6#    � Offset$	 0.1Q�67   � 5Y      $ 	#1116a1ff��6#   $	 0.2Q�65   � 5Z      $ 	#1116a1ff��6#   $	 0.5Q�65   � 5[      $ Transparent��6#   $ 1Q�67   5\      ��5^      �� 5_      $	 0,0&�6&   $	 0,1&�67   .��5`      � $ Transparent��6#   $ 0Q�67   � 5a      $
 Gold��6#   $	 0.3Q�60   � 5b      $ Transparent��6#   $ 1Q�67   5c      ._�5e      �� $��Center=�69   $��	0,0,0,100q�6T   ��6   �� *Menus+��5f      �� 5g      .R�5h      	�  	� 	GroupName$
 menu��6G     MenuButtonStyle#��[ 5i   "    d� 	IsChecked 5h   &   �� *
IsSelected+��5j   &   �� *DataContext.ShowPageCommand+ �� RelativeSource ��  �� AncestorType
 Window��5k   &   �� 5m      5o      5p      � 5r   
   $��1��6   $��1��6   .+�5s      >� $	��0,5q�6<   ��6   �� *ViewContent+6<   5t      5u      5v      
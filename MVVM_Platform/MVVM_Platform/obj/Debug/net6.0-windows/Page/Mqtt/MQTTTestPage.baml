   M S B A M L   `   `   `  ����H  DMVVM_Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MVVM_PlatformMVVM_Platform  5           MVVM_Platform.MQTTTestPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:MVVM_Platform     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � 	Resources  5       �� MergedDictionaries �� Source   Key �� 
TargetType  Iconfont J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName	 �� Property
 �� Value �� Angle�� 5   
    5      �� 5      $F @pack://application:,,,/Assets;component/Styles/ButtonStyles.xaml?�6%   �� 5      �� 5      ArrowButtonTemplate  " d�6B   .R�5      � $
��back��6   
������ .+�5      �� $��arrow��5   !   $��Center=�5   !   $��Center=�5   !   #��[ 5   !   
�������$ 0.5,0.5&�5   !   $	����5   !   5       5      P� 5       �@d�	IsChecked$
 TrueY�6;   . �5   "   �� $ arrow��6)   	 � z�
 5   &   �� 5   *   $ 90Q�6:   5!   #   5"      P� 5#       �@J�IsMouseOver$
 True��6=   . �5$   "   �� $
 back��6)   	 � ��
 �	#110000006Q   5%      5'      5(      %    5+      .��5-      ]� .+�5.   
   � $	��200��6   $
��Left=�6     5/       �� 
TargetType-  'System.Windows.Input.KeyboardNavigation � ColumnDefinitions � RowDefinitions J� InputBindings d� MouseAction �� Command �� RelativeSource �� AncestorType �� CommandParameter ��Name �� Padding �� CornerRadius J� SnapsToDevicePixels ��Name �� StringFormat �� Path ��Name �� Binding �� Value��%�  '��       �� 50      " ��6   .�51      �� 	 �@ AcceptsReturn$

 True��6I   �� 52      	 � ��$

 Left=�6C   �� 53      	 � ��$
 Center=�6A   �� 54      	 � ��$	
 8,5q�60   �� 55      	 � ��

 �����63   �� 56      	 � ��$
 12(�61   �� 57      	 � ��$
 0q�68   �� 58      	 � ��
 59      �� 5:      " ��6.   .R�5;   "   � $
��root��6'   
������  5<   &   �� 5=   *   �� 5>   *   $��30��6;    5@   &   �� 5A   *   $
��Auto �68   $��36��6F   �� 5B   *    5D   &   d� 5E   *   $ 	LeftClicke�5H   -    5F   -   �� *DataContext.OpenViewCommand+ ��  UserControl 5G   -   �� 5H   -   .+�5K   &   �� $ Bd��5L   )   $��2��5M   )   # z��5N   )   #��z��5O   )   #��z��5P   )   #��z��5Q   )   $ 10��5R   )   $
 true��5S   )   5Y   '   �� 5Z   &   $ TB��60   
���   ���5[   *   `� 5\   .   $  {0}@{1}:{2}��6;   .1�5]   2   �� $ Model.ClientID�6:   �� 5^   2   $ 
Model.Host�6:   �� 5_   2   $ 
Model.Port�6:   5`   /   5c   '   �� 5i   &   $ 	ItemsHost��5j   )   $��1��5k   )   $��2��5l   )   $��8,0,8,0q�5m   )   5n   #    5o   "   P� 5p   &    �@��
IsSelected$
 true��6D   . �5q   *   �� $ Bd��61   	 � ��
 �	#FF9FF0FF6W   5r   '   �� 5s   &    62   �� *
MenuIcon+ 6O   Z� .a�5t   *   �� $
 root��61   	 � ��$
 10,0,0,0q�6U   5u   '   5w      5y      5{      5|       5}      �� 5~      $��50 �6    �� 5      .+�5�      �� $��Center=�6    �� Orientation$ 
Horizontal=�64   .+�5�      �� $��连接��5�      $��20(�5�      $��
ExtraBlack"�5�      d� 5�      -   5        $��	btnManual��5�      $��30��5�      $	��5,3q�5�      $��Stretch=�5�        MqttToggleButtonStyle#��[ 5�      
  � Tag$  5��5�      ��5�      �� *AddSubscribeCommand+.��5�      � $	��0,0q�6    5�      �� 5�      $��20 �6/   �� 5�      $��20 �6/   .+�5�      �� $
��Left=�6$   $��+��6?   �� 5�      $��1��5�      $��Right=�5�      #��[ 5�      $	����5�      5�      5�      � 5�      ! � AllowsTransparency$
! True��5�      $
��Left=�5�      " � 	StaysOpen$" False��5�      ��5�      �� # �� ElementName$# 	btnManual��$ 	IsChecked�$ � PlacementTarget$ 5�      �� $# 	btnManual��5�      �� 5�      $��保存��5�        WindowControlButtonStyle#��[ 5�      ��5�      �� *SaveConfigCommand+5�      5�      �� 5�      -   5        $��
Clientlist��5�      $��1��5�      $��0q�5�      $��Disabled=�5�      ��5�      �� *	Clients+5�      5�      �� 5�   
   $	��0,5q�5�      $	��Top=�5�      ��5�      �� *ViewContent+5�      5�      5�      
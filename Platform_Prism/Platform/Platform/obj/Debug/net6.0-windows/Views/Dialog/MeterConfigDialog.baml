   M S B A M L   `   `   `  ����C  ?Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Platform.Views.DialogPlatform.Views.Dialog  5      -    'Platform.Views.Dialog.MeterConfigDialog   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Platform.Views.Dialog     5      ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f43xck)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5
      ]� .+�5   
   � $
��Left=�6   $	��150��6%     � RowDefinitions  5      �� 5      $��40 �6    �� 5      $��* �6    .+�5      �� �� 5      $��1��65   ��6   �� *Meter+65   5      � 5   
   $��Right=�6   $	�� 10q�6&     5      �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    .+�5      �� $��保存��6   $	��100��6B   $��
-510,0,0,0q�6N   ��6"   �� *TextCommand+6N   �� 5      $��添加��6   $	��100��6A   ��6"   �� *
AddCommand+6A   �� 5!       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��1��6O   .+�5"      �� $��名称:��6   �� 5#      $	��150��6   ��6&   �� *
Param.Name+ �� Mode$ TwoWay=��� 5%      $��地址:��6   $��
 100,0,0,0q�6&   �� 5&      $	��150��6   ��6&   �� *Param.AddressName+$ TwoWay=�5'      �� 5(      $ 
Horizontal=�6   $��Center=�62   $��2��6M   .+�5)      �� $��数量:��6   �� 5,      $��数据类型:��6   $��
 100,0,0,0q�6(   �� 5-      $	��150��6K   ��6   �� *
Param.Type+$ TwoWay=�6K   5.      �� 5/      $ 
Horizontal=�6   $��Center=�62   $��3��6M   .+�50      �� $��型号:��6   �� 51      $	��150��6K   ��6   �� *
Param.Type+$ TwoWay=�6K   �� 52      $��设备名称:��6   $��
 100,0,0,0q�6(   �� 53      $	��150��6   ��6&   �� *Param.MachineName+$ TwoWay=�54      55      56      57      
   M S B A M L   `   `   `  ����B  >Nelysis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Nelysis.PopupNelysis.Popup  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      G CNelysis.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM6clr-namespace:Nelysis.Core.Enums;assembly=Nelysis.CoreNelysis.Core.Enums 5	      &     Nelysis.Popup.NotificationDialog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Nelysis.Popup     5      9System&clr-namespace:System;assembly=mscorlib     5      Henums6clr-namespace:Nelysis.Core.Enums;assembly=Nelysis.Core     5	      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5
      ! 	 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       � 	Resources 5       �� 
TargetType �� Property �� Value   
enumValues S� 
MethodName S� 
ObjectTypeU
 QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
 System.Enum S� MethodParameters M� TypeName��%}  '��       '�� �     '�� E    &	  �    �� 5   
   " ��6   .�5      ��  � ��$ Stretch=�64   �� 5       � ��$ Stretch=�62   �� 5       � ��$
 Wrap=�6-   5      �� 5   
   " ��6   .�5      ��  � ��$ Stretch=�64   �� 5       � ��$ Stretch=�62   �� 5       �@��TextWrapping$
 Wrap=�6-   5      �� 5   
   " ��6   .�5      ��  � ��$ 75��6&   �� 5       � ��$ 25��6'   �� 5       � ��$ 0,10,0,0q�6'   5      S� 5   
   $ 	GetValues��5      "  5        5!      M� 5"      $ enums:ComponentsTypes��6   5%      5&      .��5(      � -   5        	 �Name$	 
LayoutRoot��5(      $��5q�6   
 � RowDefinitions
 5)   
   �� 5*      $��* �6   �� 5+      $��* �6   �� 5,      $��* �6   �� 5-      $��* �6   .+�50   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�51      �� $
��ID: ��6   �� 52      ��6   �� *NetworkComponents.ID+53      �� 55   
   $��1��6   $ 
Horizontal=�6"   .+�56      �� $��MAC: ��6   �� 57      ��6   �� *NetworkComponents.MAC+58      � 5:   
   $��2��6    � ColumnDefinitions 5;      �� 5<      $��* �6#   �� 5=      $��* �6#   �� 5>      $��* �6#   .+�5A      �� $��0��6   .+�5B      �� $��	Hostname:��6   �� 5C      ��6   �� *NetworkComponents.Hostname+5D      �� 5E      $��1��6   .+�5F      �� $��ComponentType:��6   �� 5G      ��6   ��  �� Source# [   �� SelectedItem 5H      �� *!NetworkComponents.ComponentType+5K      �� 5L      $��2��6   .+�5M      �� $��
IPAddress:��6   �� 5N      ��6   �� *NetworkComponents.IPAddress+5O      5S      �� 5U   
   $��Stretch=�6   $��3��5V      $ 
Horizontal=�5W      .+�5X      �� $
��true��5Y      $��OK��5Z      $
��Left=�5[       �� 	IsDefault$
 True��5\      ��5X      �� *CloseDialogCommand+5\      �� 5]      $��false��5^      $��Cancel��5_      $��Right=�5`      ��5]      �� *CloseDialogCommand+5`      5b      5c      5d      
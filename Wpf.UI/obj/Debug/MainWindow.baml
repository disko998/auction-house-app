   M S B A M L   `   `   `  ����D  @Wpf.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Wpf.Model;assembly=Wpf.Model	Wpf.Model  5   	   H DWpf.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:Wpf.ViewModel;assembly=Wpf.ViewModelWpf.ViewModel 5   	   A =Wpf.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Wpf.UIWpf.UI 5   	      Wpf.UI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <model*clr-namespace:Wpf.Model;assembly=Wpf.Model     5   	   I
view_model2clr-namespace:Wpf.ViewModel;assembly=Wpf.ViewModel     5   	   &localclr-namespace:Wpf.UI     5   	   -   5          � Title$  Auction��5
   	   $	��500��6   $	��800��6&    � 
ResizeMode$ NoResize=�62    � 	Resources 5         Wpf.Model.IdConverter 	  IdCon   Wpf.Model.PriceConverter  PriceCon��%:   &	        &	        5   
   6,     5   
   62   5      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   6.   �� 5      6!   .+�5   
   �� -   5        $	��lb1��5   :   $��2��6�   $��5q�6�   ��6E   �� *ListProduct+ �� SelectedItem 6i   �� *CurrentProduct+��5      �� 5      .R�5      �� $	��150��6   $��30��6)   ._�5      ��  �� TextAlignment$ Center=�6$   
����ح�$
��Bold"�6R   
���   ���6w   ��  �� Path$ ProductName�6�   5      5      5!      �� 5"   
   $��0,0,5,0q�6   $��Details��6$   $��2��65   .��5#      �  5$      �� 5%      6&   �� 5&      6&   �� 5'      6&    5)      �� 5*      6)   �� 5+      6)   .+�5-      �� $��Center=�6    �� Orientation$ Vertical=�6:   .+�5.      �� $��10q�6    $��15(�6,   $��Black"�6:   ��6M   �� *CurrentProduct.ProductName+6{   �� 5/      $��10q�6    $ Center=�6,   $��Black"�6C   $��15(�6V   ��6d   �� *CurrentProduct.StartingPrice+6�   50      �� 51      $��1��6   $��2��6+   $ Vertical=�6<   .+�52      �� $��Description:��6    66   �� 53      	 �� TextWrapping$
	 Wrap=�6   $	��170��62   
 �� 
IsReadOnly
 .  �� AcceptsReturn .  �� 
AcceptsTab . $��Visible=�6�   ��6Q   �� *CurrentProduct.ProductInfo+6�   54      � 55      $��Center=�6   $��1��69    � Orientation$ Vertical=�6I   .+�56      �� $��10q�6!   $ 
Horizontal=�6-   .+�57      �� $��15(�6$   $��Last bind by:��62   6I   �� 58      -   5        $��
tbBindUser��58   $   $��15(�66   
��� � �$
��Bold"�6W   ��6i   �� *CurrentProduct.UserId+ �� 	Converter# [  6�   59      �� 5:      $��10q�6!   $��Bottom=�6-   $ 
Horizontal=�6H   .+�5;      �� $��15(�6$   $��Currently price:��62   6L   �� 5<      -   5        $��tbPrice��5<   $   
��� � �$��15(�6F   $
��Bold"�6T   ��6f   �� *CurrentProduct.Price+# [ 6�   5=      5>      �� 5?      -   5        $��tbTimer��5?      $��1��6+   $��1��6;   $��Center=�6H   $��Center=�6e   $��30(�6�   $��	ExtraBold"�6�   ��6�   �� *CurrentProduct.Time+6�   �� 5@      -   5        $��btnBind��5@      $��2��6(   $��1��65   $��20q�6E   $
��Bind��6Q   $��30(�6`   6�   5A      5B      �� 5C   
   $��User details��6   $��0,0,5,5q�6)   $��1��6:   $��1��6J   .��5D      �  5E      �� 5F      6&   �� 5G      6&    5I      �� 5J      6)   �� 5K      6)   .+�5M      �� $ 
Horizontal=�6   .+�5N      �� -   5        $��	tbWelcome��5N   .   $��15(�6    $��Center=�6?   $��Login to bind!��6Z   6r   �� 5O      $��Center=�6    $	��5,0q�6;   
���  ��$��Italic$�6Y   $
��Bold"�6l   $��20(�6~   ��6�   �� *CurrentUser.UserName+6�   5P      �� 5Q      -   5        $��btnLogin��5Q      $��1��6)   $��15(�69   $��Login��6G   $	��250��6W   $��5q�6c   6n   �� 5R      -	   5        $��btnAdd��5R      $y�Hidden=�6<   $��5q�6P   $��1��6[   $��0��6h   $��Add product��6x   6�   �� 5S      -
   5        $��	btnDelete��5S   ;   $y�Hidden=�6L   $��5q�6`   $��1��6k   $��1��6x   $��Delete product��6�   ��6   �� *DeleteCommand+6�   5T      5U      5V      5W      
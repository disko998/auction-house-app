   M S B A M L   `   `   `  ����A  =Wpf.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Wpf.UIWpf.UI  5   	       Wpf.UI.NewWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Wpf.UI     5   	   -   5          � Title$  Registration��5   	   $	��350��6   $	��300��6+    � 
ResizeMode$ NoResize=�67   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.1* �6   6,   �� 5      6   .+�5   
   �� -   5        $��25��5      $��80��6   $
��Left=�6(   $
��Back��6C   6i   �� 5   
   $��1��6   $��Center=�6"   $��Center=�6=   .+�5   
   �� $��	Username:��6   6(   �� 5   
   -   5         �� 	MaxLength$ 30��5      $��0,0,0,5q�6�   $	��120��6�   $��25��6�   ��6!   �� *NewUser.UserName+ �� NotifyOnValidationError . " �� ValidatesOnNotifyDataErrors . 6�   �� 5   
   $��	Password:��6   6(   �� 5   
   -   5        $��tbPass1��5   >   $ 30��6   $��0,0,0,5q�6�   $	��120��6�   $��25��6�   ��6M   �� *NewUser.Password+ . 6�   �� 5   
   $��Confirm Password:��6   6/   �� 5   
   -   5        $��tbPass2��5      $��0,0,0,5q�6x   $	��120��6�   $��25��6�   ��6!   �� *	PassValid+6�   �� 5   
   $��Admin:��6   6$   �� 5   
   $��0,0,0,5q�6    �� Orientation$ 
Horizontal=�6&   .+�5      	� -   5        $
��rbDa��5      $	��Yes��68    	� 	GroupName$ Admin��6F   	� 5      -   5        $
��rbNe��5      $��No��68   $ Admin��6F   6Z   5      �� 5   
   $��25��61   $��80��6=   $
��Left=�6H   $��Confirm��6c   ��6   �� *SaveCommand+6w   5      5      5      
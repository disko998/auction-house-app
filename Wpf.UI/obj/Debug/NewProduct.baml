   M S B A M L   `   `   `  ����A  =Wpf.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Wpf.UIWpf.UI  5   	       Wpf.UI.NewProduct   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Wpf.UI     5   	     � Title$  New Product��5   	   $	��350��6   $	��400��6*    � 
ResizeMode$ NoResize=�66   .��5	      �  � RowDefinitions 5
   
   �� 5      $��7* �6   6*   �� 5      6   .+�5   
   �� .+�5      �� $��
10,10,10,0q�6   $��Naziv proizvoda:��6,   6F   �� 5      -   5        $��tbName��5       �� 	MaxLength$ 30��6$    �� TextAlignment$ Center=�63   $��
10,0,10,10q�6J   $��30��6^   $�� ��6j   6t   �� 5      $��	10,0,10,0q�6   $��Pocetna cena (euro):��6+   6I   �� 5      -   5        $��tbCena��5      $ 10��6$   $ Center=�63   $��
10,0,10,10q�6J   $��30��6^   $�� ��6j   6t   �� 5      $��	10,0,10,0q�6   $(��"Ostale informacije (max 100 char):��6+   6W   �� 5      -   5        $��tbInfo��5      $	 100��6$   $��	10,0,10,0q�64   $	��130��6G    �� TextWrapping$
 Wrap=�6U    �� AcceptsReturn .  �� 
AcceptsTab . " �� VerticalScrollBarVisibility$ Visible=�6�   $�� ��6�   6�   5      �� 5   
   -   5        $��1��5      $��Add product��6   $	��120��64   $��5q�6@   $��Right=�6K   6   �� 5   
   -   5        $��1��5      $��Back to auction��6   $	��120��68   $��5q�6D   $
��Left=�6O   6�   5      5      
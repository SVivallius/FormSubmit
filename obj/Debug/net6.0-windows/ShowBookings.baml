   M S B A M L   `   `   `  ����I  EBordsbokningar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BordsbokningarBordsbokningar  5   	   !    Bordsbokningar.ShowBookings   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Bordsbokningar     5   	     � Title$  ShowBookings��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $
��200* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   $	��332��6*   �� 5      $��70 �6   .+�5   
   �� -   5         ��Name$ bookings_lbx��5      $	��332��6(   $��Center=�65   $
��Left=�6P   $	��780��6k   $��10,0,0,0q�6w   $��2��6�   �� 5   
   -   5         ��Name$ 	Close_btn��5      $��Stäng fönster��6$   $
��Left=�6<   $��	410,0,0,0q�6W   $	��180��6j   $��1��6v   $��1��6�   $��50��6�   $��Center=�6�   �� 5   
   -   5        $ 
unBook_btn��5      $��Avboka markerad��6%   $��Center=�6?   $��Center=�6\   $��50��6w   $	��180��6�   $��1��6�   6�   5      5      
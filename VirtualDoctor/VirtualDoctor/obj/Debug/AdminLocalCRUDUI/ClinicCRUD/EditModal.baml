   M S B A M L   `   `   `  ����H  DVirtualDoctor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:VirtualDoctor.AdminLocalCRUDUI.ClinicCRUD)VirtualDoctor.AdminLocalCRUDUI.ClinicCRUD  5   	   9    3VirtualDoctor.AdminLocalCRUDUI.ClinicCRUD.EditModal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:VirtualDoctor.AdminLocalCRUDUI.ClinicCRUD     5   	     � Title$  	EditModal��5   	   $	��450��6   $	��800��6(   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ #1E222D��6    � Offset$ 0Q�6/   � 5      $ #95A493��6   $ 1Q�6/   5       � ColumnDefinitions 5   
   �� 5      $
��2.5* �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 	NameLabel��5      $��Clinics name��6#   $
��Left=�6:   $��	99,0,0,10q�6U   $��Bottom=�6h   $	��277��6�   $��32��6�   $��0��6�   �� 5   
   -   5         ��Name$ 
SaveButton��5      $��Center=�6%   $��3��6C   $��Center=�6P   $	��120��5      $��28��6   ���#7d9e7f
�������$
��Bold"�6T   	 �� 	IsDefault	 . $��2��6�   .��5      �� $��28��6   Save6)   5      �� 5    
   -   5        
 ��Name$
 NameBox��5        �� TextAlignment$ Center=�6#   $
��Left=�6:   $��45��6U   $��99,0,0,0q�6a   $��1��6s    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��277��6�   �� 5!   
   -   5        $ MessageLabel��5!      $
��Left=�6&   $��	10,10,0,0q�6A   $��2��6T   $	��Top=�6a   $��2��6y   $	��332��6�   $��85��6�   $��1��6�   .��5"      �� $	��316��6   $��75��6$   62   5#      �� 5$   
   -   5        $ 
PlaceLabel��5$       $��Place��6   $
��Left=�64   $��99,0,0,0q�6O   $��2��6a   $	��Top=�6n   $	��277��6�   $��36��6�   �� 5%   
   -   5         ��Name$ PlaceComboBox��5%   f   $
��Left=�6   $��	99,64,0,0q�6.   $��2��6A   $	��Top=�6N   $	��277��6}   $��45��6�   5&      5'      
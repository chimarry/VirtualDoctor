   M S B A M L   `   `   `  ����H  DVirtualDoctor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:VirtualDoctor.AdminLocalCRUDUI.LocalAccountCRUD/VirtualDoctor.AdminLocalCRUDUI.LocalAccountCRUD  5   	   H DMultiComboBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullF3clr-namespace:CustomControls;assembly=MultiComboBoxCustomControls 5   	   A    ;VirtualDoctor.AdminLocalCRUDUI.LocalAccountCRUD.CreateModal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Olocal=clr-namespace:VirtualDoctor.AdminLocalCRUDUI.LocalAccountCRUD     5   	   Csrc3clr-namespace:CustomControls;assembly=MultiComboBox     5   	     � Title$  CreateModal��5	   	   $	��450��6   $	��800��6*   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ #1E222D��6    � Offset$ 0Q�6/   � 5      $ #95A493��6   $ 1Q�6/   5       � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
EmailLabel��5       $��Email��6   $
��Left=�64   $��	34,10,0,0q�6O   $��1��6b   $	��Top=�6o   $	��276��6�   $��40��6�   �� 5   
   -   5        $ FullNameLabel��5   $   $��	Full name��6   $��1��6;   $
��Left=�6K   $��	41,10,0,0q�6f   $��1��6y   $	��Top=�6�   $	��276��6�   $��40��6�   �� 5   
   -   5        $ PasswordLabel��5   #   $��Password��6   $
��Left=�6:   $��	34,10,0,0q�6U   $��2��6h   $	��Top=�6u   $	��276��6�   $��41��6�   �� 5   
   -   5        $ 
RolesLabel��5       $��Roles��6   $��1��64   $
��Left=�6D   $��	41,10,0,0q�6_   $��2��6r   $	��Top=�6   $	��276��6�   $��41��6�   �� 5    
   -   5         ��Name$ EmailBox��5       $
��Left=�6$   $��40��6?   $��	34,55,0,0q�6K   $��1��6^   	 �� TextWrapping$
	 Wrap=�6k   $	��Top=�6   $	��276��6�   6�   �� 5!   
   -   5        $ FullNameBox��5!      $
��Left=�6'   $��38��6B   $��	41,57,0,0q�6N   $��1��6a   $
	 Wrap=�6n   $	��Top=�6�   $	��276��6�   $��1��6�   6�   G� 5"   
   -   5        
 G�Name$
 PasswordBox��5"      $
��Left=�6+   $��	34,56,0,0q�6F   $��2��6Y   $	��Top=�6f   $	��276��6~   $��38��6�   6�   �� 5$   
   -   5         ��Name$ 
SaveButton��5$      $
��Left=�6&   $��
180,53,0,0q�6A   $��3��6U   $	��Top=�6b   $	��120��6z   $��29��6�   ���#7d9e7f
�������$
��Bold"�5%   :    �� 	IsDefault . .��5&      �� Save6   5'      "  CustomControls.MultiComboBox  5(   
   -	   5        $��selectedItems��5(   6   $��41,56.5,79,10.25q�6   $��2��6K   $��1��6X   $	��Top=�6h    �� SelectionMode$ Multiple=�6�      IsCreateNewEnabled .    DisplaySeparator$ , ��5+   "   $��38��5,   J   ��5*   "   �� *Items+$  CustomControls.BindableListBox   SelectedItems 5,   "   �� *SelectedItems+50      �� 51   
   -
   5        $ MessageLabel��51      $
��Left=�6&   $��	21,10,0,0q�6A   $	��Top=�6T   $��85��6l   $	��365��6x   .��52      �� $
��Wrap=�6   $��75��6,   $	��355��68   53      54      55      
   M S B A M L   `   `   `  ����H  DVirtualDoctor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD)VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD  5   	   <    6VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD.DetailsModal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD     5   	     � Title$  DetailsModal��5   	   $	��450��6   $	��800��6+    � 	Resources 5	         ListBoxItemStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels��%Q  &	        �� 5
   
   " ��6)   .�5      ��  �@�FocusVisualStyle 61   Z� �� 5       � ��
 ��  �6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Border��5      $ 2q�5       . $��0,0,0,4q�5   6   
��� � �._�5      �� 5      5      5      5      5      .��5      � -   5         �Name$
 Grid��5      ��5   
   �� 5      	 �� EndPoint$	 0.5,1&�6"   
 �� 
StartPoint$
 0.5,0&�63   .��5      �  � Color$ #1E222D��6    � Offset$ 0Q�6/   � 5      $ #95A493��6   $ 1Q�6/   5        � ColumnDefinitions 5"   
   �� 5#      $��* �6   �� 5%      $
��2.7* �6   .+�5(   
   � -   5        $ MainInfoGrid��5(      $��0��6%    � RowDefinitions 5)      �� 5*      �� 5+      �� 5,      �� 5-      �� 5.      .+�51      �� -   5         ��Name$ MessageLabel��51      $
��Left=�6*   $	��Top=�6E   $��75��6]   $	��365��6i   $��1��6u   $��6��6�   .��52      �� $
��Wrap=�6   $��60��60   $	��355��6<   53      �� 54      -   5        $ 	NameLabel��54   #   $
��Name��6   $��21,10,-38,0q�66   $	��Top=�6K   �� 55      -   5         ��Name$ NameBox��55      $
��Left=�6'   $��30��6B   $��	21,44,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��215��6�   �� 56      -   5        $ LastNameLabel��56   (   $��	Last name��6   $
��Left=�6?   $��21,10.2,0,0q�6Z   $��1��6o   $	��Top=�6|   $	��215��6�   �� 57      -   5        $ LastNameBox��57      $
��Left=�6+   $��30��6F   $��21,41.2,0,0q�6R   $��1��6g   $
 Wrap=�6t   $	��Top=�6�   $	��215��6�   �� 58      -   5        $ WorkExperienceLabel��58   .   $��Work experience��6   $
��Left=�6K   $��
21,9.4,0,0q�6f   $��2��6z   $	��Top=�6�   $	��215��6�   �� 59      -	   5        $ WorkExperinceBox��59      $
��Left=�60   $��30��6K   $��21,40.4,0,0q�6W   $��2��6l   $
 Wrap=�6y   $	��Top=�6�   $	��215��6�   �� 5:      -
   5        $ AccountLabel��5:   &   $��Account��6   $
��Left=�6<   $��
21,9.6,0,0q�6W   $��3��6k   $	��Top=�6x   $	��215��6�   �� 5;      -   5         ��Name$ AccountComboBox��5;      $
��Left=�60   $��21,43.6,0,0q�6K   $��3��6`   $	��Top=�6m   $	��215��6�   $��30��6�   5<      � 5=   
   -   5        $ DetailsGrid��5=      $��1��6$    5>      �� 5?      �� 5@      .+�5B      � -   5        $ ClinicsGrid��5B       5C      �� 5D      $
��0.4* �6'   �� 5E      �� 5F      $
��0.7* �6'   �� 5G      �� 5H      $
��0.2* �6'    5J      �� 5K      �� 5L      �� 5M      �� 5N      �� 5O      .+�5R      �� -   5         ��Name$ ClinicsListBox��5R      $��2��62   $
��Left=�6B   $	��300��6]   $��88,25,0,-115q�6j   $��5��6�   $	��Top=�6�   $	��210��6�   $��Stretch=�6�   #��[  6�   $��2��6  �� 5S      -   5        $ ClinicsLabel��5S   +   $��Clinics��6   $��3��6A   $
��Left=�6Q   $	��Top=�6l   $��92��6�   5U      � 5V      -   5        $ MedicalTitlesGrid��5V      $��1��6.    5W      �� 5X      $
��0.4* �6'   �� 5Y      �� 5Z      $
��0.7* �6'   �� 5[      �� 5\      $
��0.2* �6'    5^      �� 5_      �� 5`      �� 5a      �� 5b      �� 5c      .+�5g      �� -   5        $ MedicalTitlesListBox��5g      $��2��68   $	��300��6H   $��88,20,0,-110q�6U   $��5��6k   $	��Top=�6|   $��Stretch=�6�   #��[  6�   $��2��6�   �� 5h      -   5        $ MedicalTitleLabel��5h   1   $��Medical titles��6   $��3��6L   $
��Left=�6\   $	��Top=�6w   $	��165��6�   5i      5j      5l      5m      
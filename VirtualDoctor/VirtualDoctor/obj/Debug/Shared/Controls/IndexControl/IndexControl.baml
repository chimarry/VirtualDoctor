   M S B A M L   `   `   `  ����H  DVirtualDoctor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:VirtualDoctor.Shared.ControlsVirtualDoctor.Shared.Controls  5      M+clr-namespace:VirtualDoctor.Shared.ControlsVirtualDoctor.Shared.Controls  5      o<clr-namespace:VirtualDoctor.Shared.Controls.DataGridControls.VirtualDoctor.Shared.Controls.DataGridControls  5   	   =    7VirtualDoctor.Shared.Controls.IndexControl.IndexControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:VirtualDoctor.Shared.Controls     5      :my+clr-namespace:VirtualDoctor.Shared.Controls     5      Mctrl<clr-namespace:VirtualDoctor.Shared.Controls.DataGridControls     5   	   .��5      � -   5          �Name$
  Grid��5      ��5   
   �� 5       �� ImageSource$d ^C:\Users\PC\Desktop\Svastara\VSProjects\VirtualDoctor\VirtualDoctor\Shared\Images\ThemeDNA.jpg��6    j� Stretch$ UniformToFill=�6�   6�    � RowDefinitions 5   
   �� 5      $	��11* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��5* �6   �� 5      $��* �6   .+�5   
   4   .VirtualDoctor.Shared.Controls.TranslateControl  -   5          Name$ 	Translate��5      $��2��61   $	��Top=�6A   $��2,4,10,0q�6Y   $��1��6k   6z   �� 5   
   -   5         ��Name$ ButtonsPanel��5      $��Right=�6+   $	��479��6G   $��-6,20,0,-49q�6T   $	��Top=�6i   $	��120��6�   $��2��6�   .+�5      1   +VirtualDoctor.Shared.Controls.GoBackControl  -   5          Name$ GoBack��5      $��28��6/   $��Right=�6<   $	��120��6X   �� 5      $	��130��6   �� 5      -   5         ��Name$ CreateButton��5      ���#7d9e7f
�������$
��Bold"�6V   $��Right=�6i   $	��120��6�   $��28��6�   .��5      �� Create6%   5       �� 5!      $��60��6   �� 5"      -   5        $ DeleteButton��5"      ���#7d9e7f
�������$
��Bold"�6�   $��Right=�6�   $	��120��6�   $��28��6�   {�6.   �� *SelectedItems.Count+.��5#      �� Delete6%   5$      �� 5%      $��60��6   �� 5&      -   5        $ 
EditButton��5&      ���#7d9e7f
�������$
��Bold"�6T   $��Right=�6g   $	��120��6�   $��28��6�   {�5'      �� *SelectedItems.Count+.��5(      �� Edit6"   5)      �� 5*      $��60��6   �� 5+      -   5        $ DetailsButton��5+      ���#7d9e7f
�������$
��Bold"�6W   $��Right=�6j   $	��120��6�   $��28��6�   {�5,      �� *SelectedItems.Count+.��5-      �� �� 6   $�Details��6!   63   5.      5/      �� 50   
   -	   5        	 ��Name$	 MessageLabel��50      $��2��6&   $
��Left=�66   $��2,50,0,0q�6Q   $	��Top=�6c   
 J� RenderTransformOrigin$
 1.797,1.169&�6{   $	��207��6�   $	��110��6�   .��51      �� $	��207��6   $	��110��6%   63   52      54      56      
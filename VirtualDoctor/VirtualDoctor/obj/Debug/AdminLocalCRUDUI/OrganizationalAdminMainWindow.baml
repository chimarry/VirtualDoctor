   M S B A M L   `   `   `  ����H  DVirtualDoctor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:VirtualDoctor.AdminLocalCRUDUIVirtualDoctor.AdminLocalCRUDUI  5   	   M+clr-namespace:VirtualDoctor.Shared.ControlsVirtualDoctor.Shared.Controls  5   <   B    <VirtualDoctor.AdminLocalCRUDUI.OrganizationalAdminMainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:VirtualDoctor.AdminLocalCRUDUI     5   	   :my+clr-namespace:VirtualDoctor.Shared.Controls     5   <     � Title$  dr Name LastName��6   $
��Auto��6!   $
��Auto��6/   .��5
      � -   5         �Name$
 Grid��5
       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      $��1* �6   ��5   
   �� 5       �� ImageSource$d ^C:\Users\PC\Desktop\Svastara\VSProjects\VirtualDoctor\VirtualDoctor\Shared\Images\ThemeDNA.jpg��6    j� Stretch$ UniformToFill=�6�   6�   .+�5   
   6   0VirtualDoctor.Shared.Controls.RoundButtonControl  -   5          Name$
 Role��5   "   6   0VirtualDoctor.Shared.Controls.RoundButtonControl   MouseDoubleClick$ Role_MouseDoubleClick��6N   $��1��60   $��2��6@   6N     5   
   -   5        $ Clinic��5   "   $ Clinic_MouseDoubleClick��6O   $��0��62   $��2��6B   6O     5   
   -   5        $ Place��5   "   $ Place_MouseDoubleClick��6N   $��2��61   $��2��6A   6N     5    
   -   5        $ Doctor��5    "   $ Doctor_MouseDoubleClick��6O   $��2��62   $��1��6B   6O     5!   
   -   5        $ MedicalTitle��5!   "   $# MedicalTitle_MouseDoubleClick��6U   $��0��68   $��1��6H   6U   ;   5VirtualDoctor.Shared.Controls.VirtualAssistantControl  5"   
   -   5          Name$ VirtualAssistant��5"   %   $��4��6?   $��2��6O   $��0��6`   4   .VirtualDoctor.Shared.Controls.TranslateControl  5#   
   -   5        	  Name$	 	Translate��5#      $��3��61   $��3��6A   $��Bottom=�6N   $��Right=�6i   5$      5&      
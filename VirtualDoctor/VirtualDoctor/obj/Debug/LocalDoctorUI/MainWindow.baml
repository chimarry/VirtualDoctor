   M S B A M L   `   `   `  ����H  DVirtualDoctor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:VirtualDoctor.Shared.ControlsVirtualDoctor.Shared.Controls  5   9   ,    &VirtualDoctor.LocalDoctorUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :my+clr-namespace:VirtualDoctor.Shared.Controls     5   9     � Title$  dr Name LastName��6   $
��Auto��6   $
��Auto��6,   .��5      � -   5         �Name$
 Grid��5       � RowDefinitions 5   
   �� 5	      �� 5
      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      $
��1.5* �6   ��5   
   �� 5       �� ImageSource$d ^C:\Users\PC\Desktop\Svastara\VSProjects\VirtualDoctor\VirtualDoctor\Shared\Images\ThemeDNA.jpg��6    j� Stretch$ UniformToFill=�6�   6�   .+�5   
   6   0VirtualDoctor.Shared.Controls.RoundButtonControl  -   5          Name$ PatientControl��5   "   6   0VirtualDoctor.Shared.Controls.RoundButtonControl   MouseDoubleClick$% PatientControl_MouseDoubleClick��6W   $��0��6:   $��2��6J   6W     5   
   -   5        $ Doctors��5   "   $ Doctors_MouseDoubleClick��6P   $��2��63   $��2��6C   6P     5   
   -   5        $ MedicalRecordsReview��5   "   $+ %MedicalRecordsReview_MouseDoubleClick��6]   $��1��6@   $��1��6P   6]   ;   5VirtualDoctor.Shared.Controls.VirtualAssistantControl  5   
   -   5          Name$ VirtualAssistant��5   %   $��1��6?   $��2��6O   $��2��6\   4   .VirtualDoctor.Shared.Controls.TranslateControl  5   
   -   5        	  Name$	 	Translate��5      $��3��61   $��3��6A   $��Bottom=�6N   $��Right=�6i   5      5      
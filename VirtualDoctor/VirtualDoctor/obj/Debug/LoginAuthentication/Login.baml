   M S B A M L   `   `   `  ����H  DVirtualDoctor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:VirtualDoctor.LoginAuthentication!VirtualDoctor.LoginAuthentication  5   	   M+clr-namespace:VirtualDoctor.Shared.ControlsVirtualDoctor.Shared.Controls  5   	   -    'VirtualDoctor.LoginAuthentication.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:VirtualDoctor.LoginAuthentication     5   	   :my+clr-namespace:VirtualDoctor.Shared.Controls     5   	     � Title$  Login��5	   	   .��5      � -   5         �Name$
 Grid��5      ��5   
   �� 5       �� ImageSource$d ^C:\Users\PC\Desktop\Svastara\VSProjects\VirtualDoctor\VirtualDoctor\Shared\Images\ThemeDNA.jpg��6    j� Stretch$ UniformToFill=�6�   6�    � ColumnDefinitions 5   
   �� 5      $
��0.8* �6   �� 5      $
��0.2* �6    � RowDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��0.6* �6   6,   .+�5   
   �� $��0��6   $
��Left=�6%   $	��364��6@   $��
105,10,0,0q�6M   $��1��6a   $	��Top=�6n   $	��285��6�   .+�5      �� -   5         ��Name$ 
EmailLabel��5      $��Email��6)   $��
22,0,105,0q�69   $��Center=�6M   
�������$
��Bold"�6}   $	��158��6�   $��32��6�   $��12(�6�   �� 5      -   5         ��Name$ EmailBox��5      $��30��6(    �� TextWrapping$
 Wrap=�64   $��	22,0,10,0q�6H   $��Center=�6[   $
��Left=�6}   6�   �� 5      $��41��6   $��	22,0,10,0q�6%   �� 5      -   5        $ PasswordLabel��5      $��Password��6+   $��	22,0,10,0q�6>   
�������$
��Bold"�6d   $��31��6v   $��12(�6�   G� 5      -   5        	 G�Name$	 PasswordBox��5      $��30��6/   $��	22,0,10,0q�6;   $��Center=�6N   $
��Left=�6p   6�   �� 5       $��71��6   $��	22,0,10,0q�6$   �� 5"      $	��126��6   $��	22,0,10,0q�6&   .+�5#      �� -   5        
 ��Name$
 LoginButton��5#      $��Login��6.   ���#7d9e7f
�������$
��Bold"�6f   $��1��6y   $��Right=�6�   $��8,-1,0,0q�6�   $	��Top=�6�   $	��120��6�   $��30��6�   6�   �� 5$      $��36��6   6*   5&      5(      ;   5VirtualDoctor.Shared.Controls.VirtualAssistantControl  5)   
   -   5          Name$ VirtualAssistant��5)   %   $	��168��6?   $	��Top=�6L   $��1��6d   4   .VirtualDoctor.Shared.Controls.TranslateControl  5*   
   $��1��6   $��Right=�6.   $��33��6J   $��1��6W   $��Bottom=�6d   $	��100��6   �� 5+   
   -   5        $ 
ErrorLabel��5+   5   
���  ��$
��Bold"�6!   $
��Left=�6I   $��
395,77,0,0q�6d   $��1��6x   $	��Top=�6�   $	��323��6�   $	��125��6�   $��2��6�   .��5,      �� -	   5         ��Name$ 	TextBlock��5,      $
��Wrap=�6+   6A   5-      5.      5/      
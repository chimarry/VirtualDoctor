   M S B A M L   `   `   `  ����  VirtualDoctor6    0VirtualDoctor.Shared.Controls.RoundButtonControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      JCustom;http://schemas.microsoft.com/winfx/2006/xaml/composite-font   5      -   5          >�Name$  RoundButton��5      $	��100��5      $	��100��6    � 	Resources 5	       	  Round �� Property �� Value  	HalfRound  GlassButton �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty	 O� KeyTime
 O� Value ��Name � RowDefinitions J� Opacity �� RelativeTransform �� CenterX �� CenterY �� ScaleX �� ScaleY �� AngleX �� AngleY �� CenterX �� CenterY �� Angle �� CenterX �� CenterY T� X T� Y � Color � Offset ��Name �� Triggers  P� Property! P� Value" �� 
TargetName# N� EnterActions  	Timeline1$ N� ExitActions% ��Name  	Timeline2��%  &	        &	 L     &	 �     7  7  �� 5
   
   .�5      ��  �@��CornerRadius$	 500��64   5      �� 5   
   .�5      ��  �@��CornerRadius$ 500,500,0,0��64   5      �� 5   
   " ��6.    5      ���� 5      	Timeline1 .��5      U� $ 00:00:00X�64   $ 
GlowBorder��6I   $ (UIElement.Opacity)�6l   .\�5      �� $	 00:00:00.3000000��6/   $
 1Q�6J   5      5      �� 5      	Timeline2 .��5      U� $ 00:00:00X�64   $ 
GlowBorder��6I   $ (UIElement.Opacity)�6l   .\�5      �� $	 00:00:00.3000000��6/   $
 0Q�6J   5      5      5      .R�5       �� $ BorderOutline��6g   ���#7d9e7f$
��Auto��6,   $
��Auto��69   #���   6G   ._�5#      �� $ border��6   #���   6)   $
��Auto��6I   ._�5$      �  5&      �� 5'      $
��0.5* �6,   �� 5(      $
��0.5* �6,   .+�5*      �� $ 
GlowBorder��6\   $ 0Q�6!   $��Stretch=�6-   $��0,0,0,0q�6K   #���   6p   $
��Auto��6�   $��2��6�   ��5+      
� 5,   "    5-   &   V� 5.   *   .~�5/   .   �� $	 0.5Q�6D   $	 0.5Q�6R   $ 1.633Q�6`   $ 0.652Q�6o   �� 50   .   $ 0Q�6C   $ 0Q�6N   $	 0.5Q�6Y   $	 0.5Q�6g   �� 51   .   $ 0Q�6E   $	 0.5Q�6O   $	 0.5Q�6]   T� 52   .   $ 0.022Q�6H   $ 0.452Q�6R   53   +   .��55   &   � $ 	#7Fffffff��6:   $ 0Q�6L   � 56   &   $ 	#007D9E7F��6:   $ 1Q�6L   57   #   59      �� 5:      $ contentPresenter��6�   $��Center=�6+   $��0,0,0,0q�6H   $��Center=�6Y   $��2��6t   6�   5<      5=      5>       5?      P� 5@        � ��! . . �5B      �� $" border��60    �@J�Opacity$ 1Q�6D   �� 5C      $" border��63    � �� �	#4C0000006G   �� 5D      $" 
GlowBorder��60    �@J�Opacity$ 0Q�6H   �� 5E      $" 
GlowBorder��63    � y�$ Hidden=�6K   5F      P� 5H        �@J�IsMouseOver! . # 5I      �� 5J      8��  6*   $ 5L      �� 5M      $% Timeline2_BeginStoryboard��6*   8�� 6M   5O      5Q      5R      & � Triggers& 5T      :� 5U   
   ' :� RoutedEvent$' ButtonBase.Click��6   ( :� 
SourceName$( Button��66   .��5X      � -   5        ) �Name$) 
LayoutRoot��5X      .+�5Y   
   �� -   5        * ��Name$* Button��5Y   `   
�������
���  ��#���  67   .��5Z      �� -   5        + ��Name$+ TextProperities��5Z      $	��100��61   6?   5[      5\      5]      
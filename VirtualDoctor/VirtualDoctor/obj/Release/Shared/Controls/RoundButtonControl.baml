   M S B A M L   `   `   `  ����   VirtualDoctor6    0VirtualDoctor.Shared.Controls.RoundButtonControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     JCustom;http://schemas.microsoft.com/winfx/2006/xaml/composite-font   -     >�Name$  RoundButton��$	��100��$	��100�� � 	Resources  	  Round �� Property �� Value  	HalfRound  GlassButton �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty	 O� KeyTime
 O� Value ��Name � RowDefinitions J� Opacity �� RelativeTransform �� CenterX �� CenterY �� ScaleX �� ScaleY �� AngleX �� AngleY �� CenterX �� CenterY �� Angle �� CenterX �� CenterY T� X T� Y � Color � Offset ��Name �� Triggers  P� Property! P� Value" �� 
TargetName# N� EnterActions  	Timeline1$ N� ExitActions% ��Name  	Timeline2��%�  &	        &	 ,     &	 `     7  7  �� .���  �@��CornerRadius$	 500���� .���  �@��CornerRadius$ 500,500,0,0���� " �� ���� 	Timeline1 .��U� $ 00:00:00X�$ 
GlowBorder��$ (UIElement.Opacity)�.\��� $	 00:00:00.3000000��$
 1Q��� 	Timeline2 .��U� $ 00:00:00X�$ 
GlowBorder��$ (UIElement.Opacity)�.\��� $	 00:00:00.3000000��$
 0Q�.R��� $ BorderOutline�����#7d9e7f$
��Auto��$
��Auto��#���   ._��� $ border��#���   $
��Auto��._��  �� $
��0.5* ��� $
��0.5* �.+��� $ 
GlowBorder��$ 0Q�$��Stretch=�$��0,0,0,0q�#���   $
��Auto��$��2����
�  V� .~��� $	 0.5Q�$	 0.5Q�$ 1.633Q�$ 0.652Q��� $ 0Q�$ 0Q�$	 0.5Q�$	 0.5Q��� $ 0Q�$	 0.5Q�$	 0.5Q�T� $ 0.022Q�$ 0.452Q�.��� $ 	#7Fffffff��$ 0Q�� $ 	#007D9E7F��$ 1Q��� $ contentPresenter��$��Center=�$��0,0,0,0q�$��Center=�$��2�� P�   � ��! . . ��� $" border�� �@J�Opacity$ 1Q��� $" border�� � �� �	#4C000000�� $" 
GlowBorder�� �@J�Opacity$ 0Q��� $" 
GlowBorder�� � y�$ Hidden=�P�   �@J�IsMouseOver! . # �� 8��  $ �� $% Timeline2_BeginStoryboard��8�� & � Triggers& :� ' :� RoutedEvent$' ButtonBase.Click��( :� 
SourceName$( Button��.��� -   ) �Name$) 
LayoutRoot��.+��� -   * ��Name$* Button��
�������
���  ��#���  .���� -   + ��Name$+ TextProperities��$	��100��
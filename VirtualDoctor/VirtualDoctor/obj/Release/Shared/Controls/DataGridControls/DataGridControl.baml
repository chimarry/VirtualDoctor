   M S B A M L   `   `   `  ����   VirtualDoctorD    >VirtualDoctor.Shared.Controls.DataGridControls.DataGridControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� -     �Name$
  Grid�� � ColumnDefinitions �� �� �� �� �� �� ��  � RowDefinitions �� �� �� �� �� �� �� �� .+��� -    ��Name$ 
StackPanel��$��1��$��0��$��2��$��5��$��Bottom=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ #1E222D�� � Offset$ 0Q�� $ #95A493��$ 1Q�.+��� -   	 ��Name$	 DataGridTitle��
�������
 �� Padding$
 2q�$��Center=�$��22(� �� TextAlignment$ Center=���  �� Orientation$ 
Horizontal=�$��6q�$��Center=�.+��� -    ��Name$ 	Backwards��$��4q�$��6q����#1E222D
�������.���� �� -   $ First��$��4q�$��6q����#1E222D
�������.���� � $��6q�$��Center=�$��Center=�.+��� -    ��Name$ PageInfo��
��������� -   $
 Last��$��4q�$��6q����#1E222D
�������.���� �� -   $ Forward��$��4q�$��6q����#1E222D
�������.���� � $��2��$��1��$��5��$��5�� �� $
��357* ��� $
��214* �.+�&   System.Windows.Controls.DataGrid  -	     Name$ DataGrid��   AutoGenerateColumns .    
IsReadOnly .  $��2��   ���� $ 0.5,1&�$ 0.5,0&�.��� $ #1E222D��$ 0Q�� $ #95A493��$ 1Q�
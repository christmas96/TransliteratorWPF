   M S B A M L   `   `   `  ����   Transliteration(    "Transliteration.Views.TranslitView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $	��800��.��� $��Stretch=�  � RowDefinitions  �� $��50 ��� $	��100 ��� $	��200 ��� $	��100 ��� $��* � � ColumnDefinitions �� $��50 ��� $	��250 ��� $	��200 ��� $	��250 ��� $��50 �.+��� $��0��$��1��$��Close��$	��100��$��40��$
��Left=�$��Center=�$
��10,0q����� *CloseCommand+�� $��3��$��0��$	��100��$��40��$��Right=�$��Log Out��$
��10,0q����� *LogOutCommand+�� $��0��$��1��$
��Left=�$��10,20q����� *TranslitLabelText+�� $��0��$��3��$
��Left=�$��10,20q����� *TranslitLabelText+�� $��2��$��1��$��10,20q�$��Transliterate������ *TranslitCommand+�� $��2��$��3��$��10,20q�$��Transliteration history������ *HistoryCommand+�� $��1��$��1��$��3��$��10,20q� �� TextWrapping$
 Wrap=�$��Disabled=�$
��Auto=���. ���� *	EnterText+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� $��3��$��1��$��3��$��10,20q�$
 Wrap=�$��Disabled=�$
��Auto=���. ���� *TranslitText+$ PropertyChanged=�$ TwoWay=�&   System.Windows.Controls.DataGrid  $��1��$��3��$��4��$��
10,0,10,20q�$��0q�$	��Top=�$��Hidden=�$   HorizontalScrollBarVisibility$ Disabled=���.    AutoGenerateColumns .  ���� *	Translits+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 110 
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Date+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=�  $) #Оригінальний текст��$		 290 
 .  �� *	EnterText+ �� .���  � ��$
 Wrap=�  $1 +Транслітерований текст��$	 * 
 .  �� *TranslateText+ �� .���  � ��$
 Wrap=�
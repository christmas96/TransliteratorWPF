   M S B A M L   `   `   `  ����  Transliteration(    "Transliteration.Views.TranslitView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��800��5   0   .��5	      � $��Stretch=�6     � RowDefinitions  5
   
   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $	��200 �6   �� 5      $	��100 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��250 �6   �� 5      $	��200 �6   �� 5      $	��250 �6   �� 5      $��50 �6   .+�5   
   �� $��0��5      $��1��5      $��Close��5      $	��100��5      $��40��5      $
��Left=�5      $��Center=�5      $
��10,0q�5       ��5!      �� *CloseCommand+�� 5"   
   $��3��5#      $��0��5$      $	��100��5%      $��40��5&      $��Right=�5'      $��Log Out��5(      $
��10,0q�5)      ��5*      �� *LogOutCommand+�� 5+   
   $��0��5,      $��1��5-      $
��Left=�5.      $��10,20q�5/      ��50      �� *TranslitLabelText+�� 51   
   $��0��52      $��3��53      $
��Left=�54      $��10,20q�55      ��56      �� *TranslitLabelText+�� 57   
   $��2��58      $��1��59      $��10,20q�5:      $��Transliterate��5;      ��5<      �� *TranslitCommand+�� 5=   
   $��2��5>      $��3��5?      $��10,20q�5@      $��Transliteration history��5A      ��5B      �� *HistoryCommand+�� 5C   
   $��1��5D      $��1��5E      $��3��5F      $��10,20q�5G       �� TextWrapping$
 Wrap=�5I      $��Disabled=�5J      $
��Auto=�5K      ��. ��5H      �� *	EnterText+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5L      �� 5M   
   $��3��5N      $��1��5O      $��3��5P      $��10,20q�5Q      $
 Wrap=�5S      $��Disabled=�5T      $
��Auto=�5U      ��. ��5R      �� *TranslitText+$ PropertyChanged=�$ TwoWay=�5V      &   System.Windows.Controls.DataGrid  5W   
   $��1��5X      $��3��5Y      $��4��5Z      $��
10,0,10,20q�5[      $��0q�5\      $	��Top=�5]      $��Hidden=�5^      $   HorizontalScrollBarVisibility$ Disabled=�5_      ��.    AutoGenerateColumns .  ��5a      �� *	Translits+   Columns 5c      0  *System.Windows.Controls.DataGridTextColumn  5d      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 110 6L   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Date+   ElementStyle 5e      �� 5f      .�5g      ��  �� Property � �� �� Value$
 Wrap=�6G   5h      5j        5k      $) #Оригінальний текст��6%   $		 290 6_   
 .  6A   �� *	EnterText+ 5l      �� 5m      .�5n      ��  � ��$
 Wrap=�6G   5o      5q        5r      $1 +Транслітерований текст��6%   $	 * 6g   
 .  6E   �� *TranslateText+ 5s      �� 5t      .�5u      ��  � ��$
 Wrap=�6G   5v      5x      5z      5{      5|      
   M S B A M L   `   `   `  ���� A  =PA3000, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PA3000PA3000       PA3000.SearchInsurancePage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:PA3000     $	��600��$	��800��  N� Title$  SearchInsurancePage��.��� $��Stretch=�$��Stretch=� � RowDefinitions �� $��1* ��� $��1* �.+�� $��0�� � ColumnDefinitions �� $��250px ��� $��1* �.+�� $��0�� �� $
��50px ��� $
��40px ��� $
��50px ��� $��1* �.+��� -    ��Name$ searchTb��$��1��$��
10,5,10,10q��� -    ��Name$ 	searchBtn��$��2��$��Suchen��$��Stretch=�$��10q�� $��1��.+�&   System.Windows.Controls.DataGrid  -     Name$ InsuranceDg��$��Stretch=�$	��Top=�$	��300��   
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *InsuranceId+  
   MinWidth$	
 200Q�$ * 	 �� *Name+� $��1��.+��� 
��������� -   $ NameTb��$
��Left=�$��23��$��
148,60,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��188�� J� RenderTransformOrigin$ 0.172,-1.173&��� $��Bezeichnung��$
��Left=�$��	23,60,0,0q�$	��Top=�$ 0.737,0.192&��� $��Krankenkasse anpassen��$��326,10,374,0q�$	��Top=�$��Center=��� -   $��	Speichern��$
��Left=�$��148,243,0,0q�$	��Top=�$	��188��$ 	1.733,1.5&�
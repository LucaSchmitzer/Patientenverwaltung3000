   M S B A M L   `   `   `  ���� A  =PA3000, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PA3000PA3000       PA3000.SearchInsurancePage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:PA3000     $	��600��$	��800��  N� Title$  SearchInsurancePage��.��� $��Stretch=�$��Stretch=�
������� � RowDefinitions �� $��1* ��� $��1* �.+�� $��0�� � ColumnDefinitions �� $��250px ��� $��1* �.+�� $��0�� �� $
��50px ��� $
��40px ��� $
��50px ��� $��1* �.+��� -    ��Name$ searchTb��$��10,41,10,24q�$��2���� -    ��Name$ 	searchBtn��$��2��$��Suchen��$��Stretch=�$��
10,0,10,28q��� -   $ btCreateInsurance��$��Anlegen��$
��Left=�$��	80,10,0,0q�$��3��$	��Top=�$��75�� J� RenderTransformOrigin$ 
0.344,-1.4&�� $��1��.+�&   System.Windows.Controls.DataGrid  -     Name$ InsuranceDg��$��Stretch=�$	��Top=�$	��300��   
IsReadOnly . $��0,0,82,0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 30 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *InsuranceId+     MinWidth$	 200Q�$	 * 
 �� *Name+� $��1��.+��� .+��� $	��600��$	��800��.+��� $
��Name��$
��Left=�$��	23,60,0,0q�$	��Top=�$ 0.737,0.192&��� -    ��Name$ 	cbPrivate��$��Private Kasse�� �� Left$	 505��
 �� Top$ 66��$ 0.345,0.103&��� $��
Hauptsitz:��$ 23��$	 120���� $��Land:��$ 23��$	 165��$ -0.211,0.038&�$	��107���� -   $ 	tbCountry��$��23��$	 148�� �� TextWrapping$
 Wrap=�$	 165��$	��277���� -   $ tbCity��$��23��$	 148��$
 Wrap=�$	 207��$	��277���� $��Stadt:��$ 23��$	 207��$ -0.211,0.038&�$	��107���� $
��PLZ:��$ 23��$	 238��$ -0.211,0.038&�$	��107���� -   $ tbZip��$��23��$	 148��$
 Wrap=�$	 241��$	��119���� $��Straße:��$	 446��$	 162��$ -0.211,0.038&�$��78���� -	   $ tbStreet��$��23��$	 505��$
 Wrap=�$	 162��$	��251���� $��Hausnummer:��$	 446��$	 204��$ -0.211,0.038&�$��84���� -
   $ tbStreetnumber��$��23��$	 535��$
 Wrap=�$	 210��$��71��$ 1.155,0.478&��� -   $ NameTb��$
��Left=�$��23��$��
148,60,0,0q�$
 Wrap=�$	��Top=�$	��275��$ 0.172,-1.173&��� $��Krankenkasse anpassen��$��340,10,329,0q�$	��Top=�$��Center=�$	��165���� -   $��	Speichern��$
��Left=�$��340,259,0,0q�$	��Top=�$	��165��$ 	1.733,1.5&�
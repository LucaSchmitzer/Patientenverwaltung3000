   M S B A M L   `   `   `  ���� A  =PA3000, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PA3000PA3000      PA3000.Initialpage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:PA3000     $	��600��$	��800��  N� Title$  SearchPatientPage��.��� $��Stretch=�$��Stretch=�
������� � RowDefinitions �� $��1* ��� $��1* �.+�� $��0�� � ColumnDefinitions �� $��250px ��� $��1* �.+�� $��0�� �� $
��50px ��� $
��40px ��� $
��50px ��� $��1* �.+��� -    ��Name$ searchTb��$��1��$��
10,5,10,10q��� -    ��Name$ 	searchBtn��$��2��$��Suchen��$��Stretch=�$��10,10,10,18q� J� RenderTransformOrigin$ 0.585,0.437&��� -   $��Anlegen��$
��Left=�$��	83,10,0,0q�$��3��$	��Top=�$��75��� $��1��.+�&   System.Windows.Controls.DataGrid  -     Name$ 	patientDg��$��Stretch=�$	��Top=�$	��290��   
IsReadOnly . $��
10,10,53,0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 30 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *	PatientId+     MinWidth$	 200Q�$	 * 
 �� *	FirstName+  $	 200Q�$	 * 
 �� *
LastName+� $��1��.+��� .+��� $��Krankenkasse:�� �� Left$ 23��
 �� Top$	 135��$ -0.211,0.038&�$	��107���� -   $ FirstnameTb��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��277��$ 0.172,-1.173&�$	 148��$ 60���� -   $ 
LastnameTb��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��277��$	 148��$ 99���� $��Vorname��$
��Left=�$��	23,60,0,0q�$	��Top=�$ 0.737,0.192&��� $��Nachname��$
��Left=�$��	23,99,0,0q�$	��Top=��� $��Patient anpassen��$��326,10,374,0q�$	��Top=�$��Center=��� -   $��	Speichern��$
��Left=�$	��Top=�$	��188��$ 	1.733,1.5&�$	 461��$	 264���� -    ��Name$ InsuranceCb��$	��277��$	 148��$	 139���� $��Geburtsdatum:��$	 461��$ 60��$ 0.579,0.462&�$	��102��(  "System.Windows.Controls.DatePicker  -	     Name$ 
BirthdayDp��$	 563��$ 62��$	��181���� $��Angelegt am:��$	 461��$ 96��$	��102���� -
   $ CreatedDateTb��$��23��$	 563��$
 Wrap=�$ 99��$	��181�� �� 
IsReadOnly . �� $��Land:��$ 23��$	 180��$ -0.211,0.038&�$	��107���� -   $ 	tbCountry��$��23��$	 148��$
 Wrap=�$	 180��$	��277���� $��Stadt:��$ 23��$	 219��$ -0.211,0.038&�$	��107���� -   $ tbCity��$��23��$	 148��$
 Wrap=�$	 219��$	��277���� $
��PLZ:��$ 23��$	 264��$ -0.211,0.038&�$	��107���� -   $ tbZip��$��23��$	 148��$
 Wrap=�$	 264��$	��277���� $��Straße:��$	 461��$	 180��$ -0.211,0.038&�$��78���� -   $ tbStreet��$��23��$	 544��$
 Wrap=�$	 180��$	��246���� $��Hausnummer:��$	 455��$	 219��$ -0.211,0.038&�$��84���� -   $ tbStreetnumber��$��23��$	 544��$
 Wrap=�$	 222��$��71��$ 1.155,0.478&��� -   $��Termine anzeigen��$	 470��$	 141��$	��136��
   M S B A M L   `   `   `  ���� A  =PA3000, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PA3000.PagesPA3000.Pages  "    PA3000.Pages.AppointmentPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:PA3000.Pages       N� Title$  AppointmentPage��.��� $��Stretch=�$��Stretch=�
�������.+�&   System.Windows.Controls.DataGrid  -     Name$ appointmentGrid��$
��Left=�$	��480��$��	10,10,0,0q�   
IsReadOnly . $	��Top=�$	��300��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *AppointmentId+     MinWidth$	 200Q�$ *  �� *Description+�� -   $��Suchen��$
��Left=�$��341,119,0,0q�$	��Top=�$	��135���� $��Termin:��$
��Left=�$��315,257,0,0q�$	��Top=�$��66���� $��Beschreibung:��$
��Left=�$��315,317,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.488,1.885&��� $��Datum:��$
��Left=�$��315,291,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -     Name$ dpDate��$
��Left=�$��481,291,0,0q�$	��Top=�$	��252���� -   $��	Erstellen��$
��Left=�$��315,470,0,0q�$	��Top=�$��92��$ 
-0.04,-2.6&�$��17���� -   $��Ändern��$
��Left=�$��514,470,0,0q�$	��Top=�$��75��$ 
0.347,-0.3&�  -   $ dpLowerDate��$
��Left=�$��
481,44,0,0q�$	��Top=�$	��289��  -   $ dpUpperDate��$
��Left=�$��
481,77,0,0q�$	��Top=�$	��289���� $��
Von Datum:��$
��Left=�$��
341,44,0,0q�$	��Top=�$��76���� $��
Bis Datum:��$
��Left=�$��
341,75,0,0q�$	��Top=�$ 0.132,0.538&�$��69���� -   	 ��Name$	 tbDescription��$
��Left=�$��23��$��315,348,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��475��
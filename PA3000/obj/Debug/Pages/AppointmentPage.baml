   M S B A M L   `   `   `  ����A  =PA3000, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PA3000.PagesPA3000.Pages  5      "    PA3000.Pages.AppointmentPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:PA3000.Pages     5        N� Title$  AppointmentPage��5	      .��5      � $��Stretch=�6   $��Stretch=�6'   
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ appointmentGrid��5      $
��Left=�6,   $	��480��6G   $��	10,10,0,0q�6T      
IsReadOnly . $	��Top=�6y   $	��300��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *AppointmentId+  5         MinWidth$	 200Q�6%   $ * 64    6>   �� *Description+5      �� 5   
   -   5        $��Suchen��5      $
��Left=�6"   $��341,119,0,0q�6=   $	��Top=�6R   $	��135��6j   6v   �� 5   
   $��Termin:��6   $
��Left=�6"   $��315,257,0,0q�6=   $	��Top=�6R   $��66��6j   �� 5   
   $��Beschreibung:��6   $
��Left=�6(   $��315,317,0,0q�6C   $	��Top=�6X    J� RenderTransformOrigin$ 0.488,1.885&�6p   �� 5   
   $��Datum:��6   $
��Left=�6!   $��315,291,0,0q�6<   $	��Top=�6Q   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDate��5      $
��Left=�6%   $��481,291,0,0q�6@   $	��Top=�6U   $	��252��6m   6y   �� 5   
   -   5        $��	Erstellen��5      $
��Left=�6%   $��315,470,0,0q�6@   $	��Top=�6U   $��92��6m   $ 
-0.04,-2.6&�6x   $��17��6�   6�   �� 5   
   -   5        $��Ändern��5      $
��Left=�6"   $��514,470,0,0q�6=   $	��Top=�6R   $��75��6j   $ 
0.347,-0.3&�6u   6�     5   
   -   5        $ dpLowerDate��5      $
��Left=�6*   $��
481,44,0,0q�6E   $	��Top=�6Y   $	��289��6q     5   
   -   5        $ dpUpperDate��5      $
��Left=�6*   $��
481,77,0,0q�6E   $	��Top=�6Y   $	��289��6q   �� 5   
   $��
Von Datum:��6   $
��Left=�6%   $��
341,44,0,0q�6@   $	��Top=�6T   $��76��6l   �� 5   
   $��
Bis Datum:��6   $
��Left=�6%   $��
341,75,0,0q�6@   $	��Top=�6T   $ 0.132,0.538&�6l   $��69��6�   �� 5    
   -   5        	 ��Name$	 tbDescription��5       $
��Left=�6)   $��23��6D   $��315,348,0,0q�6P   
 �� TextWrapping$

 Wrap=�6e   $	��Top=�6y   $	��475��6�   6�   5"      5#      
   M S B A M L   `   `   `  ����A  =PA3000, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PA3000PA3000  5   	       PA3000.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PA3000     5   	     � Title$  Patientenanleger3000��5   	   $	��720��6&   $
��1000��63    � 
ResizeMode$ NoResize=�6@   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��120px �6   �� 5      $��1* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��50px �6    �� 5      $
��30px �6    �� 5      $
��40px �6    �� 5      $
��40px �6    �� 5      $
��40px �6    �� 5      $
��30px �6    �� 5      $
��40px �6    �� 5      $
��40px �6    �� 5      $��1* �6    .+�5      �� $��0��6   $��10��6"   $��Stretch=�64   $��Stretch=�6P   
���"�"�6n   �� 5      -   5         ��Name$ searchPatientBtn��5      $��Patient��6/   $��	10,5,10,0q�6A   $��2��6T   $	��Top=�6a   $��25��6y    J� RenderTransformOrigin$ 0.493,0.978&�6�   6�   �� 5!      $��5��6   $�� ��6!   $
��Auto��6-   �� 5"      -   5        $ searchInsuranceBtn��5"      $��Krankenkasse��61   $
��Left=�6H   $��10,5,0,0q�6c   $��6��6u   $	��Top=�6�   $	��100��6�   $��25��6�   $ 0.493,0.978&�6�   6�   5#      � 5%   
   $��1��6   .+�5&      �� $��Stretch=�6   $��Stretch=�61   
�������6P    � 5'      -   5          �Name$ contentFrame��5'      $��Stretch=�6*   $��Stretch=�6F     � Source$ Initialpage.xaml?�6d     � NavigationUIVisibility$ Hidden=�6~   5(      5)      5*      
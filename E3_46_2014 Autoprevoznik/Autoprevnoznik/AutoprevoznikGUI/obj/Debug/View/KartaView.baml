   M S B A M L   `   `   `  ����K  GAutoprevoznikGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AutoprevoznikGUI.ViewAutoprevoznikGUI.View  5      %    AutoprevoznikGUI.View.KartaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:AutoprevoznikGUI.View     5      .��5	      � 
�������.+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  dataGrid��5
         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6S   $��	12,95,0,0q�6n   $	��Top=�6�   $	��455��6�   $	��848��6�   
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6%      Header$ Sediste��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *	sediste+  5      $ * 6%   $ Datum��6/    6>   �� *	datum_kup+ �� StringFormat$ {0:dd. MMMM yyyy}��  5      $ 60 6%   $
 Cena��60    6>   �� *cena+  5      $ * 6%   $ Relacija��6/    6A   �� *
relacija+  5      $ * 6%   $ Registracija��6/    6E   �� *Putuje_Autobus_reg+  5      $ * 6%   $ 	Br Linije��6/    6B   �� *Putuje_Linija_br_linije+  5      $ * 6%   $ Datum polaska��6/    6F   �� *Putuje_dv_polaska+$ {0:dd. MMMM yyyy hh:mm}��  5      $ * 6%   $ Mbr Putnika��6/    6D   �� *Putnik_mbr_p+5      �� 5   
   -   5         ��Name$ 	Addbutton��5      $��Dodaj��6D   $
��Left=�6T   $��	35,23,0,0q�6o   $	��Top=�6�   $	��110��6�   $��29��6�   ��6%   �� *
AddCommand+6�   �� 5   
   -   5        $ 
Editbutton��5      $��Izmeni��6F   $
��Left=�6W   $��
269,23,0,0q�6r   $	��Top=�6�   $	��111��6�   $��29��6�   ��6&   �� *EditCommand+6�   �� 5   
   -   5        $ Removebutton��5      $��Izbrisi��6J   $
��Left=�6\   $��
508,23,0,0q�6w   $	��Top=�6�   $	��107��6�   $��29��6�   ��6(   �� *RemoveCommand+6�   �� 5      -   5        $ Refreshbutton��5      $��Osvezi��6&   $
��Left=�6Z   $��
752,24,0,0q�6u   $	��Top=�6�   $	��111��6�   $��29��6�   ��67   �� *RefreshCommand+6�   �� 5   
   -   5        	 ��Name$	 	StatusBar��5      $��Bottom=�6'   $
��Left=�6?   $��27��6Z   $��	0,560,0,0q�6f   $	��Top=�6y   $	��890��6�   ��5      �� 5      .R�5      � 
 � ColumnDefinitions
 5      �� 5       $
��Auto �6/   5"      5#      .@�5%      �� .��5&      �� -   5        $��result��5&      5'      5(      5)      5*      
   M S B A M L   `   `   `  ����K  GAutoprevoznikGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AutoprevoznikGUI.ViewAutoprevoznikGUI.View  5      &     AutoprevoznikGUI.View.TabeleView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:AutoprevoznikGUI.View     5      .��5	      � 
�������.+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  dataGridVozi��5
         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6W   $��	12,95,0,0q�6r   $	��Top=�6�   $	��455��6�   $	��114��6�   
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$	 Mbr��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Mbr+  5      $ * 6%   $	 Reg��6/    6<   �� *Id+5        5   
   -   5        $  dataGridProdaje��5       .  .  $
��Left=�6Z   $��
131,95,0,0q�6u   $	��Top=�6�   $	��455��6�   $	��332��6�   
������� 5        5      $ 50 6%   $
 MbrK��60    6>   �� *Mbr+  5      $ 50 6%   $
 MbrP��60    6>   �� *Karta+  5      $ 50 6%   $	 Reg��60    6=   �� *Id+  5      $ 50 6%   $ Linija��60    6@   �� *Linija+  5      $ * 6%   $ Polazak��6/    6@   �� *	Polazak+ �� StringFormat$ {0:dd. MMMM yyyy hh:mm}��5        5   
   -   5        $  dataGridProverava��5       .  .  $
��Left=�6\   $��
468,95,0,0q�6w   $	��Top=�6�   $	��455��6�   $	��397��6�   
������� 5        5      $ 50 6%   $
 MbrK��60    6>   �� *Mbr+  5      $ 50 6%   $
 MbrP��60    6>   �� *Karta+  5      $ 50 6%   $	 Reg��60    6=   �� *Id+  5       $ 50 6%   $ Linija��60    6@   �� *Linija+  5!      $ * 6%   $ Polazak��6/    6@   �� *	Polazak+$ {0:dd. MMMM yyyy hh:mm}��5#      �� 5'   
   -   5         ��Name$ Refreshbutton��5'      $��Osvezi��6(   $
��Left=�6\   $��
749,23,0,0q�6w   $	��Top=�6�   $	��111��6�   $��28��6�   ��69   �� *RefreshCommand+6�   �� 5(   
   -   5        	 ��Name$	 	StatusBar��5(      $��Bottom=�6'   $
��Left=�6?   $��27��6Z   $��	0,560,0,0q�6f   $	��Top=�6y   $	��890��6�   ��5)      �� 5*      .R�5+      � 
 � ColumnDefinitions
 5,      �� 5-      $
��Auto �6/   5/      50      .@�52      �� .��53      �� -   5        $��result��53      54      55      �� 56   
   $��Vozi:��6   $
��Left=�6    $��	12,64,0,0q�6;   $	��Top=�6N   �� 57   
   $��Prodaje:��6   $
��Left=�6#   $��
131,64,0,0q�6>   $	��Top=�6R   �� 58   
   $��
Proverava:��6   $
��Left=�6%   $��
468,64,0,0q�6@   $	��Top=�6T   59      5:      
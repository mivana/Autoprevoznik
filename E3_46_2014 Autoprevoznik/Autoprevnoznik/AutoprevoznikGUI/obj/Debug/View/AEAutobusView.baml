   M S B A M L   `   `   `  ����K  GAutoprevoznikGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AutoprevoznikGUI.ViewAutoprevoznikGUI.View  5   	   )    #AutoprevoznikGUI.View.AEAutobusView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AutoprevoznikGUI.View     5   	     � Title$  Autobus��5   	   $	��550��6   $	��365��6&   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Dodaj nov autobus:��6   $
��Left=�6<   $��	27,10,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ 	label_reg��5      $��Registracija*��6#   $
��Left=�6;   $��	27,43,0,0q�6V   $	��Top=�6i   �� 5   
   -   5         ��Name$ tbRegistracija��5      $
��Left=�6*   $��23��6E   $��152,47,-39,0q�6Q    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��179��6�   �� 5   
   -   5        $ errorReg��5      
���  ��$��11(�63   $
��Left=�6A   $��
152,66,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ label_Model��5      $��Model��6%   $
��Left=�65   $��
27,100,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ tbModel��5      $
��Left=�6#   $��23��6>   $��152,104,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��179��6�   �� 5   
   -   5        $ label_mesta��5      $��
Broj mesta��6%   $
��Left=�6:   $��
27,159,0,0q�6U   $	��Top=�6i   �� 5   
   -   5        $ tbBrojMesta��5      $
��Left=�6'   $��23��6B   $��152,162,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��179��6�   �� 5   
   -	   5        $ errorBrMesta��5      
���  ��$��11(�67   $
��Left=�6E   $��152,181,0,0q�6`   $	��Top=�6u   �� 5   
   -
   5        $ label_datum��5      $��Datum Registracije��6%   $
��Left=�6B   $��
27,218,0,0q�6]   $	��Top=�6q   &   System.Windows.Controls.Calendar  5   
   -   5          Name$ 	datum_reg��5      $
��Left=�6&   $��153,223,0,0q�6A   $	��Top=�6V   �� 5   
   -   5         ��Name$ 	button_ok��5      $
��Left=�6G   $��206,446,0,-52q�6b   $	��Top=�6y   $��35��6�   $��35��6�   
������ ��6$   �� *AddEditCommand+��5      �� 5       �� ImageSource$: 4/AutoprevoznikGUI;component/Images/Button_13-128.png��6   5      �� 5   
   -   5        $ button_cancel��5      $
��Left=�6J   $��285,446,0,-52q�6e   $	��Top=�6|   $��35��6�   $��35��6�   
������ ��6(   �� *CancelCommand+��5       �� 5!      $: 4/AutoprevoznikGUI;component/Images/Button_12-256.png��6   5#      5$      5%      
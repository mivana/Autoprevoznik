   M S B A M L   `   `   `  ����K  GAutoprevoznikGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AutoprevoznikGUI.ViewAutoprevoznikGUI.View  5   	   '    !AutoprevoznikGUI.View.AEKartaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AutoprevoznikGUI.View     5   	     � Title$  AEKartaView��5   	   $	��400��6   $	��430��6*   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Dodaj novu Kartu:��6   $
��Left=�6;   $��	27,10,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $ label_putnik��5      $��Putnik*��6&   $
��Left=�68   $��	58,41,0,0q�6S   $	��Top=�6f   �� 5   
   -   5         ��Name$ CBPutnik��5      $
��Left=�6%   $��
148,44,0,0q�6@   $	��Top=�6T   $	��201��6l   $��21��6x   �� 5   
   -   5        $ errorPutnik��5      
���  ��$��11(�66   $
��Left=�6D   $��
152,66,0,0q�6_   $	��Top=�6s   �� 5   
   -   5        $ label_Rutina��5      $��Ruta i Vreme*��6&   $
��Left=�6>   $��	58,84,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5        $ CBRuta��5      $
��Left=�6#   $��
148,89,0,0q�6>   $	��Top=�6R   $	��201��6j   $��21��6v   �� 5   
   -   5        $ 	errorRuta��5      
���  ��$��11(�64   $
��Left=�6B   $��152,110,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $ 
label_cena��5      $
��Cena��6$   $
��Left=�63   $��
58,138,0,0q�6N   $	��Top=�6b   �� 5   
   -	   5         ��Name$ tbCena��5      $
��Left=�6"   $��23��6=   $��148,141,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��201��6�   �� 5   
   -
   5        $ 	errorCena��5      
���  ��$��11(�64   $
��Left=�6B   $��152,164,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $ label_relacija��5      $��Relacija��6(   $
��Left=�6;   $��
58,189,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ 
tbRelacija��5      $
��Left=�6&   $��23��6A   $��148,192,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��201��6�   �� 5   
   -   5         ��Name$ 	button_ok��5      $
��Left=�6G   $��254,295,0,0q�6b   $	��Top=�6w   $��35��6�   $��35��6�   
������ ��6$   �� *AddEditCommand+��5      �� 5       �� ImageSource$: 4/AutoprevoznikGUI;component/Images/Button_13-128.png��6   5      �� 5    
   -   5        $ button_cancel��5       $
��Left=�6J   $��333,295,0,0q�6e   $	��Top=�6z   $��35��6�   $��35��6�   
������ ��6(   �� *CancelCommand+��5!      �� 5"      $: 4/AutoprevoznikGUI;component/Images/Button_12-256.png��6   5$      5'      5(      
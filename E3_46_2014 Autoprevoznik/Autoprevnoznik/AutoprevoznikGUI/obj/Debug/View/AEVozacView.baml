   M S B A M L   `   `   `  ����K  GAutoprevoznikGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AutoprevoznikGUI.ViewAutoprevoznikGUI.View  5   	   '    !AutoprevoznikGUI.View.AEVozacView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AutoprevoznikGUI.View     5   	     � Title$  AEVozacView��5   	   $	��350��6   $	��400��6*   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Dodaj novog vozaca:��6   $
��Left=�6=   $��	27,10,0,0q�6X   $	��Top=�6k   �� 5   
   -   5        $ label_br_doz��5      $��Broj Dozvole��6&   $
��Left=�6=   $��	61,53,0,0q�6X   $	��Top=�6k   �� 5   
   -   5         ��Name$ br_doz��5      $
��Left=�6"   $��21��6=   $��
151,57,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��201��6�   �� 5   
   -   5        $ errorDoz��5      
���  ��$��11(�63   $
��Left=�6A   $��
155,78,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ label_kategorije��5      $��
Kategorije��6*   $
��Left=�6?   $��
61,108,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5        $ 
kategorije��5      $
��Left=�6&   $��22��6A   $��151,109,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��201��6�   �� 5   
   -   5         ��Name$ 	button_ok��5      $
��Left=�6G   $��214,166,0,0q�6b   $	��Top=�6w   $��35��6�   $��35��6�   
������ ��6$   �� *AddEditCommand+��5      �� 5       �� ImageSource$: 4/AutoprevoznikGUI;component/Images/Button_13-128.png��6   5      �� 5   
   -   5        $ button_cancel��5      $
��Left=�6J   $��293,166,0,0q�6e   $	��Top=�6z   $��35��6�   $��35��6�   
������ ��6(   �� *CancelCommand+��5      �� 5      $: 4/AutoprevoznikGUI;component/Images/Button_12-256.png��6   5      5      5      
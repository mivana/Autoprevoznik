   M S B A M L   `   `   `  ����K  GAutoprevoznikGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AutoprevoznikGUI.ViewAutoprevoznikGUI.View  5   	   (    "AutoprevoznikGUI.View.AEGarazaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AutoprevoznikGUI.View     5   	     � Title$  AEGarazaView��5   	   $	��450��6   $	��430��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Dodaj novu garazu:��6   $
��Left=�6<   $��	27,10,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ label_id_garaze��5      $��
Id Garaze*��6)   $
��Left=�6>   $��	55,44,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5         ��Name$ 
tbIdGaraze��5      $
��Left=�6&   $��23��6A   $��152,47,-39,0q�6M    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��179��6�   �� 5   
   -   5        $ errorId��5      
���  ��$��11(�62   $
��Left=�6@   $��
152,66,0,0q�6[   $	��Top=�6o   �� 5   
   -   5        $ label_ime_naselja��5      $��Ime Naselja*��6+   $
��Left=�6B   $��	55,93,0,0q�6]   $	��Top=�6p   �� 5   
   -   5         ��Name$ CBImeNaselja��5      $
��Left=�6)   $��
152,97,0,0q�6D   $	��Top=�6X   $	��179��6p   �� 5   
   -   5        $ errorNaselje��5      
���  ��$��11(�67   $
��Left=�6E   $��152,119,0,0q�6`   $	��Top=�6u   �� 5   
   -   5        $ label_kapacitet��5      $��	Kapacitet��6)   $
��Left=�6=   $��
55,142,0,0q�6X   $	��Top=�6l   �� 5   
   -	   5        $ tbKapacitet��5      $
��Left=�6'   $��23��6B   $��152,145,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��179��6�   �� 5   
   -
   5        $ errorKapacitet��5      
���  ��$��11(�69   $
��Left=�6G   $��152,173,0,0q�6b   $	��Top=�6w   �� 5   
   -   5         ��Name$ 	button_ok��5      $
��Left=�6G   $��250,326,0,0q�6b   $	��Top=�6w   $��35��6�   $��35��6�   
������ ��6$   �� *AddEditCommand+��5      �� 5       �� ImageSource$: 4/AutoprevoznikGUI;component/Images/Button_13-128.png��6   5      �� 5   
   -   5        $ button_cancel��5      $
��Left=�6J   $��329,326,0,0q�6e   $	��Top=�6z   $��35��6�   $��35��6�   
������ ��6(   �� *CancelCommand+��5      �� 5      $: 4/AutoprevoznikGUI;component/Images/Button_12-256.png��6   5!      5#      5$      
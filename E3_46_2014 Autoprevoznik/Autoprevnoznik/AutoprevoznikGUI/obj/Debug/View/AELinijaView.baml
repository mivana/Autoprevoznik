   M S B A M L   `   `   `  ����K  GAutoprevoznikGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AutoprevoznikGUI.ViewAutoprevoznikGUI.View  5   	   (    "AutoprevoznikGUI.View.AELinijaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AutoprevoznikGUI.View     5   	     � Title$  AELinijaView��5   	   $	��350��6   $	��400��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Dodaj novu liniju:��6   $
��Left=�6<   $��	27,10,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ label_br_linije��5      $��Broj Linije*��6)   $
��Left=�6@   $��	27,43,0,0q�6[   $	��Top=�6n   �� 5   
   -   5         ��Name$ 
tbBrLinije��5      $
��Left=�6&   $��23��6A   $��152,47,-39,0q�6M    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��179��6�   �� 5   
   -   5        $ errorBr��5      
���  ��$��11(�62   $
��Left=�6@   $��
152,66,0,0q�6[   $	��Top=�6o   �� 5   
   -   5        $ label_ime_linije��5      $��
Ime Linije��6*   $
��Left=�6?   $��	27,92,0,0q�6Z   $	��Top=�6m   �� 5   
   -   5        $ tbImeLinije��5      $
��Left=�6'   $��23��6B   $��
152,87,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $	��179��6�   �� 5   
   -   5        $ label_naselje��5      $��Prolazi kroz Naselja��6'   $
��Left=�6F   $��
27,140,0,0q�6a   $	��Top=�6u   �� 5   
   -   5         ��Name$ 	LBNaselje��5       �� SelectionMode$ Multiple=�6%   $
��Left=�6>   $	��100��6Y   $��152,140,0,0q�6f   $	��Top=�6{   $	��179��6�   �� 5   
   -	   5        $ errorNaselje��5      
���  ��$��11(�67   $
��Left=�6E   $��152,240,0,0q�6`   $	��Top=�6u   �� 5   
   -
   5         ��Name$ 	button_ok��5      $
��Left=�6G   $��257,258,0,0q�6b   $	��Top=�6w   $��35��6�   $��35��6�   
������ ��6$   �� *AddEditCommand+��5      �� 5       �� ImageSource$: 4/AutoprevoznikGUI;component/Images/Button_13-128.png��6   5      �� 5   
   -   5        $ button_cancel��5      $
��Left=�6J   $��336,258,0,0q�6e   $	��Top=�6z   $��35��6�   $��35��6�   
������ ��6(   �� *CancelCommand+��5      �� 5      $: 4/AutoprevoznikGUI;component/Images/Button_12-256.png��6   5       5#      5$      
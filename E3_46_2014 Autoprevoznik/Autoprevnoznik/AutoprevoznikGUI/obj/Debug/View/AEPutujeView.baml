   M S B A M L   `   `   `  ����K  GAutoprevoznikGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AutoprevoznikGUI.ViewAutoprevoznikGUI.View  5   	   (    "AutoprevoznikGUI.View.AEPutujeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AutoprevoznikGUI.View     5   	     � Title$  AEPutujeView��5   	   $	��450��6   $	��730��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Dodaj novi polazak rute:��6   $
��Left=�6B   $��	27,10,0,0q�6]   $	��Top=�6p   �� 5   
   -   5        $ 	label_reg��5      $��Registracija*��6#   $
��Left=�6;   $��	58,41,0,0q�6V   $	��Top=�6i   �� 5   
   -   5         ��Name$ CBReg��5      $
��Left=�6"   $��
148,44,0,0q�6=   $	��Top=�6Q   $	��201��6i   $��21��6u   �� 5   
   -   5        $ errorReg��5      
���  ��$��11(�63   $
��Left=�6A   $��
152,66,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ label_brLinije��5      $��Broj Linije*��6(   $
��Left=�6?   $��
380,39,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5        $ CBLinije��5      $
��Left=�6%   $��
470,44,0,0q�6@   $	��Top=�6T   $	��201��6l   $��21��6x   �� 5   
   -   5        $ errorLinija��5      
���  ��$��11(�66   $
��Left=�6D   $��
479,66,0,0q�6_   $	��Top=�6s   �� 5   
   -   5        $ label_datumPolaska��5      $��Datum Polaska*��6,   $
��Left=�6E   $��	58,90,0,0q�6`   $	��Top=�6s   &   System.Windows.Controls.Calendar  5   
   -	   5          Name$ tb_datumPolaska��5      $
��Left=�6,   $��
170,87,0,0q�6G   $	��Top=�6[   �� 5   
   -
   5        $ label_vremeSat��5      $��Vreme Polaska*��6(   $
��Left=�6A   $��
59,277,0,0q�6\   $	��Top=�6p   �� 5   
   -   5         ��Name$ tbSat��5      $
��Left=�6!   $��23��6<   $��170,280,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $��34��6�   �� 5   
   -   5        $ errorDVPolaska��5      
���  ��$��11(�69   $
��Left=�6G   $��
70,311,0,0q�6b   $	��Top=�6v   �� 5   
   -   5        $ label_Minut��5      $��:��6%   $
��Left=�61   $��202,277,0,0q�6L   $	��Top=�6a    J� RenderTransformOrigin$ -0.301,0.032&�6y   �� 5   
   -   5        $ tbMinut��5      $
��Left=�6#   $��23��6>   $��215,280,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $��34��6�   �� 5   
   -   5        $ label_datumDolaska��5      $��Datum Dolaska��6,   $
��Left=�6D   $��
380,90,0,0q�6_   $	��Top=�6s     5   
   -   5        $ tb_datumDolaska��5      $
��Left=�6,   $��
492,90,0,0q�6G   $	��Top=�6[   �� 5    
   -   5        $ label_vremeSatDolaska��5       $��Vreme Dolaska��6/   $
��Left=�6G   $��390,277,0,0q�6b   $	��Top=�6w   �� 5!   
   -   5        $ tbSatDolaska��5!      $
��Left=�6(   $��23��6C   $��493,280,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $��34��6�   �� 5"   
   -   5        $ label_MinutDolaska��5"      $��:��6,   $
��Left=�68   $��525,277,0,0q�6S   $	��Top=�6h   $ -0.301,0.032&�6�   �� 5#   
   -   5        $ tbMinutDolaska��5#      $
��Left=�6*   $��23��6E   $��538,280,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $��34��6�   �� 5$   
   -   5        $ errorDVDolaska��5$      
���  ��$��11(�69   $
��Left=�6G   $��401,311,0,0q�6b   $	��Top=�6w   �� 5%   
   $
��Left=�6   $��93��6/   $��243,158,0,0q�6;   $	��Top=�6P   $	��241��6h   $ 0.5,0.5&�6t   z�5&      V� 5'      .~�5(      �� �� 5)      �� 5*       �� Angle$	 -90Q�6&   T� 5+      5,      5.      �� 50   
   -   5         ��Name$ 	button_ok��50      $
��Left=�6G   $��557,347,0,0q�6b   $	��Top=�6w   $��35��6�   $��35��6�   
������ ��6$   �� *AddEditCommand+��51      �� 52      	 �� ImageSource$:	 4/AutoprevoznikGUI;component/Images/Button_13-128.png��6   54      �� 55   
   -   5        $ button_cancel��55      $
��Left=�6J   $��636,347,0,0q�6e   $	��Top=�6z   $��35��6�   $��35��6�   
������ ��6(   �� *CancelCommand+��56      �� 57      $:	 4/AutoprevoznikGUI;component/Images/Button_12-256.png��6   59      5=      5>      
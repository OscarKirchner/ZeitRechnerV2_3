   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Icon$0 *./Resources/Icon/icons8-timezone-+2-40.png��5       � Title$ ZeitRechner��5	   	   $��555.091��6   $��890.102��6.    � 
ResizeMode$ NoResize=�6l   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��365* �6   .+�5   
   �� -   5         ��Name$ canvas��5      $��Stretch=�6!   $��Stretch=�6?   $��2��6[   5      �� 5   
   -   5         ��Name$ button1��5       � ToolTip$ Schließen [ESC]��6"   $��
Schließen��6<   $
��Left=�6P   $��
574,41,0,0q�6k   $	��Top=�6   $��99��6�   $	��403��6�   $��1��6�   �� 5   
   -   5         ��Name$ Boarder2��5   9   
���   �$��1q�6%   $
��Left=�6K   $	��410��6f   $��	26,41,0,0q�6s   $	��Top=�6�   $	��677��6�   $��2��6�   ._�5      �� -   5        $ Boarder1��5   )   
���   �$��1q�6;   $
��Left=�6O   $	��365��6j   $��
375,32,0,0q�6w   $	��Top=�6�   $	��291��6�   5      �� 5   
   -   5        	 ��Name$	 textBox1��5      $
��Left=�6$   $��23��6?   $��	60,83,0,0q�6K   
 �� TextWrapping$

 Wrap=�6^   $
��0,00��6r   $	��Top=�6~   $��69��6�   6�   �� 5   
   -   5         ��Name$ label2��5      $��	Ergebnis:��6    $
��Left=�64   $��
252,73,0,0q�6O   $	��Top=�6c   $��1��6{   �� 5   
   -   5        $	 textBox2��5       �� 	MaxLength$ 2��6$   $
��Left=�6g   $��23��6�   $��
60,147,0,0q�6�   $

 Wrap=�6�   $��08��6�   $	��Top=�6�   $��23��6�    J� RenderTransformOrigin$ -0.277,0.502&�6�   �� 5   
   -	   5        $ label3��5      $ zB. 08 : 30 oder 07 : 48��6    $��Beginn heute��6C   $
��Left=�6Z   $��
40,120,0,0q�6u   $	��Top=�6�   �� 5   
   -
   5        $	 textBox3��5      $ 2��6Y   $
��Left=�6g   $��23��6�   $��106,147,0,0q�6�   $

 Wrap=�6�   $��00��6�   $	��Top=�6�   $��23��6�   �� 5   
   -   5        $ label4��5      $��:��6    $
��Left=�6,   $��
88,143,0,0q�6G   $	��Top=�6[   �� 5   
   -   5        $ label5��5      $
��Left=�6    $��	40,56,0,0q�6;   $	��Top=�6N   $	��286��6f   $��2��6r   �� 5   
   -   5        $ label6��5      $ zB. 30 oder 50��6    $��Pause heute in Minuten��69   $
��Left=�6Z   $��
40,179,0,0q�6u   $	��Top=�6�   $��2��6�   �� 5   
   -   5        $	 textBox4��5      $
��Left=�6Y   $��23��6t   $��
60,206,0,0q�6�   $

 Wrap=�6�   $��30��6�   $	��Top=�6�   $��69��6�   �� 5   
   -   5        $ label7��5      $> 8Weitere Infos: Einstellungen> Tipps & Tricks> ganz unten��6!   $����Durch kleine Rundungsfehler kann es zu Verschiebungen kommen, weswegen manchmal eine Minute auf das Ergebnis aufgeschlagen wird.��6i   $��8(�6�   $
��Left=�6  $��
69,469,0,0q�6  $	��Top=�61  $��2��6I  �� 5    
   -   5        $ label99��5       $> 8Weitere Infos: Einstellungen> Tipps & Tricks> ganz unten��6!   $w��qEs kann zu minimalen Ungenauigkeiten von max. +1 Minute kommen. Genaueres unter Info*. Alle Angaben ohne Gewähr.��6h   $��8(�6�   $
��Left=�6�   $��
69,483,0,0q�6  $	��Top=�6   $��2��68  �� 5!   
   -   5        $ label8��5!      $q kEine Anleitung, wie dieses Programm funktioniert, findest du im Einstellungsmenu im Reiter 'Über uns/Info'��6    $m��gZeitrechner, um geringe Überstunden( bis max. 4h) oder geringe Minusstunden( bis max. -4h) zu checken:��6�   $
��Left=�6  $��	10,10,0,0q�6!  $	��Top=�64  $��2��6L  �� 5"   
   -   5        $ label9��5"      $ zB. 16 : 45��6    $ ��Wann magst du heute gehen?��66   $
��Left=�6[   $��
40,264,0,0q�6v   $	��Top=�6�   $��2��6�   �� 5#   
   -   5        $	 textBox5��5#      $ 2��6$   $
��Left=�62   $��23��6�   $��
60,291,0,0q�6�   $

 Wrap=�6�   $��17��6�   $	��Top=�6�   $��23��6�   �� 5$   
   -   5        $	 textBox6��5$      $ 2��6$   $
��Left=�6g   $��23��6�   $��106,291,0,0q�6�   $

 Wrap=�6�   $��00��6�   $	��Top=�6�   $��23��6�   �� 5%   
   -   5        $	 textBox5_Copy1��5%      $
��Left=�6*   $��23��6E   $��
60,350,0,0q�6Q   $

 Wrap=�6e   $	��2,5��6y   $	��Top=�6�   $��69��6�   6�   �� 5&   
   -   5        $	 textBox5_Copy��5&      $
��Left=�6[   $��23��6v   $��
60,404,0,0q�6�   $

 Wrap=�6�   $��8��6�   $	��Top=�6�   $��69��6�   �� 5'   
   -   5        $ button2��5'      $ Enter��6"   $
��Left=�62   $��
172,78,0,0q�6M   $	��Top=�6a   $��65��6y   $	��349��6�   $��1��6�   .��5(      �� 	Auswerten�� 6"   ( Enter ↩ )6:   5)      �� 5*   
   -   5         ��Name$ 
textBox161��5*       �� Left$	 568��6(   $
��Wrap=�6:   $�� ��6N   
 �� Top$	 421��6W   $��1��6h   $��252,48,213,396q�6x   �� 5+   
   -   5        $ label10��5+      $��:��6!   $
��Left=�6-   $��
88,287,0,0q�6H   $	��Top=�6\   �� 5,   
   -   5        $ label11��5,      $/��)-----------------------------------------��6!   $
��Left=�6U   $��
40,234,0,0q�6p   $	��Top=�6�   $��2��6�   �� 5-   
   -   5        $ button��5-      $ Einstellungsmenu [I/E]��6!   $	��⚙��6B   $��20(�6N   $
��Left=�6\   $��
26,464,0,0q�6w   $	��Top=�6�   $��38��6�   $��40��6�   $ 	0.3,2.909&�6�   �� 5.   
   -   5        $ label9_Copy��5.      $* $= WuschZeitguthaben, zB. 0 oder 2,75��6%   $ ��Was ist dein Wunschfaktor?��6T   $
��Left=�6y   $��
40,319,0,0q�6�   $	��Top=�6�   $��2��6�   �� 5/   
   -   5        $ label9_Copy1��5/      $	��Uhr��6&   $
��Left=�64   $��134,143,0,0q�6O   $	��Top=�6d   $��41��6|   $��2��6�   �� 50   
   -   5        $ label9_Copy2��50      $	��Uhr��6&   $
��Left=�64   $��134,287,0,0q�6O   $	��Top=�6d   $��41��6|   $��2��6�   �� 51   
   -   5        $ label5_Copy��51      $
��Left=�6%   $��	40,56,0,0q�6@   $	��Top=�6S   $	��286��6k   $��2��6w   �� 52   
   -    5        $ label5_Copy1��52      $
��Left=�6&   $��
129,79,0,0q�6A   $	��Top=�6U   $	��197��6m   $��32��6y   $��2��6�   �� 53   
   -!   5        $ label3_Copy��53      $A ;EasterEgg: Hier Doppelklick für Neustart und Modus-Wechsel��6U   $
��Left=�6�   $��574,480,0,0q�6�   $	��Top=�6�   $��1��6�   $ 2,-0.5&�6�   �� 54   
   -"   5        $ label9_Copy3��54      $( "zB.: 8 oder 5,05 (= 5 h und 5 min)��6&   $1��+Wie viele Stunden willst du Heute arbeiten?��6S   $
��Left=�6�   $��
40,378,0,0q�6�   $	��Top=�6�   $��2��6�   �� 55   
   -#   5        $ label9_Copy4��55      $*��$(zb. 8h 35 min = 8,35 | exkl. Pause)��6&   $
��Left=�6U   $��129,400,0,0q�6p   $	��Top=�6�   $	��224��6�   $��2��6�   57      58      
   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1       WpfApplication1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication1     -     � WindowStartupLocation$  CenterScreen=� � Icon$0 *./Resources/Icon/icons8-timezone-+2-40.png�� � Title$ ZeitRechner��$��555.091��$��890.102�� � 
ResizeMode$ NoResize=�.���  � ColumnDefinitions �� $	��77* ��� $
��365* �.+��� -    ��Name$ canvas��$��Stretch=�$��Stretch=�$��2���� -    ��Name$ button1�� � ToolTip$ Schließen [ESC]��$��
Schließen��$
��Left=�$��
574,41,0,0q�$	��Top=�$��99��$	��403��$��1���� -    ��Name$ Boarder2��
���   �$��1q�$
��Left=�$	��410��$��	26,41,0,0q�$	��Top=�$	��677��$��2��._��� -   $ Boarder1��
���   �$��1q�$
��Left=�$	��365��$��
375,32,0,0q�$	��Top=�$	��291���� -   	 ��Name$	 textBox1��$
��Left=�$��23��$��	60,83,0,0q�
 �� TextWrapping$

 Wrap=�$
��0,00��$	��Top=�$��69���� -    ��Name$ label2��$��	Ergebnis:��$
��Left=�$��
252,73,0,0q�$	��Top=�$��1���� -   $	 textBox2�� �� 	MaxLength$ 2��$
��Left=�$��23��$��
60,147,0,0q�$

 Wrap=�$��08��$	��Top=�$��23�� J� RenderTransformOrigin$ -0.277,0.502&��� -	   $ label3��$ zB. 08 : 30 oder 07 : 48��$��Beginn heute��$
��Left=�$��
40,120,0,0q�$	��Top=��� -
   $	 textBox3��$ 2��$
��Left=�$��23��$��106,147,0,0q�$

 Wrap=�$��00��$	��Top=�$��23���� -   $ label4��$��:��$
��Left=�$��
88,143,0,0q�$	��Top=��� -   $ label5��$
��Left=�$��	40,56,0,0q�$	��Top=�$	��286��$��2���� -   $ label6��$ zB. 30 oder 50��$��Pause heute in Minuten��$
��Left=�$��
40,179,0,0q�$	��Top=�$��2���� -   $	 textBox4��$
��Left=�$��23��$��
60,206,0,0q�$

 Wrap=�$��30��$	��Top=�$��69���� -   $ label7��$> 8Weitere Infos: Einstellungen> Tipps & Tricks> ganz unten��$����Durch kleine Rundungsfehler kann es zu Verschiebungen kommen, weswegen manchmal eine Minute auf das Ergebnis aufgeschlagen wird.��$��8(�$
��Left=�$��
69,469,0,0q�$	��Top=�$��2���� -   $ label99��$> 8Weitere Infos: Einstellungen> Tipps & Tricks> ganz unten��$w��qEs kann zu minimalen Ungenauigkeiten von max. +1 Minute kommen. Genaueres unter Info*. Alle Angaben ohne Gewähr.��$��8(�$
��Left=�$��
69,483,0,0q�$	��Top=�$��2���� -   $ label8��$q kEine Anleitung, wie dieses Programm funktioniert, findest du im Einstellungsmenu im Reiter 'Über uns/Info'��$m��gZeitrechner, um geringe Überstunden( bis max. 4h) oder geringe Minusstunden( bis max. -4h) zu checken:��$
��Left=�$��	10,10,0,0q�$	��Top=�$��2���� -   $ label9��$ zB. 16 : 45��$ ��Wann magst du heute gehen?��$
��Left=�$��
40,264,0,0q�$	��Top=�$��2���� -   $	 textBox5��$ 2��$
��Left=�$��23��$��
60,291,0,0q�$

 Wrap=�$��17��$	��Top=�$��23���� -   $	 textBox6��$ 2��$
��Left=�$��23��$��106,291,0,0q�$

 Wrap=�$��00��$	��Top=�$��23���� -   $	 textBox5_Copy1��$
��Left=�$��23��$��
60,350,0,0q�$

 Wrap=�$	��2,5��$	��Top=�$��69���� -   $	 textBox5_Copy��$
��Left=�$��23��$��
60,404,0,0q�$

 Wrap=�$��8��$	��Top=�$��69���� -   $ button2��$ Enter��$
��Left=�$��
172,78,0,0q�$	��Top=�$��65��$	��349��$��1��.���� 	Auswerten�� ( Enter ↩ )�� -    ��Name$ 
textBox161�� �� Left$	 568��$
��Wrap=�$�� ��
 �� Top$	 421��$��1��$��252,48,213,396q��� -   $ label10��$��:��$
��Left=�$��
88,287,0,0q�$	��Top=��� -   $ label11��$/��)-----------------------------------------��$
��Left=�$��
40,234,0,0q�$	��Top=�$��2���� -   $ button��$ Einstellungsmenu [I/E]��$	��⚙��$��20(�$
��Left=�$��
26,464,0,0q�$	��Top=�$��38��$��40��$ 	0.3,2.909&��� -   $ label9_Copy��$* $= WuschZeitguthaben, zB. 0 oder 2,75��$ ��Was ist dein Wunschfaktor?��$
��Left=�$��
40,319,0,0q�$	��Top=�$��2���� -   $ label9_Copy1��$	��Uhr��$
��Left=�$��134,143,0,0q�$	��Top=�$��41��$��2���� -   $ label9_Copy2��$	��Uhr��$
��Left=�$��134,287,0,0q�$	��Top=�$��41��$��2���� -   $ label5_Copy��$
��Left=�$��	40,56,0,0q�$	��Top=�$	��286��$��2���� -    $ label5_Copy1��$
��Left=�$��
129,79,0,0q�$	��Top=�$	��197��$��32��$��2���� -!   $ label3_Copy��$A ;EasterEgg: Hier Doppelklick für Neustart und Modus-Wechsel��$
��Left=�$��574,480,0,0q�$	��Top=�$��1��$ 2,-0.5&��� -"   $ label9_Copy3��$( "zB.: 8 oder 5,05 (= 5 h und 5 min)��$1��+Wie viele Stunden willst du Heute arbeiten?��$
��Left=�$��
40,378,0,0q�$	��Top=�$��2���� -#   $ label9_Copy4��$*��$(zb. 8h 35 min = 8,35 | exkl. Pause)��$
��Left=�$��129,400,0,0q�$	��Top=�$	��224��$��2��
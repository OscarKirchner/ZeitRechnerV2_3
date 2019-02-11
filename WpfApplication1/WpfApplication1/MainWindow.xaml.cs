using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WpfApplication1.Rechnungen;
using WpfApplication1.Resources;

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainFrame
    {
        public static IMainFrame Me;
        SnowEngine snow;
        public XmlSerializer xs;
        public List<DefaultWerte> ls;
        LinearGradientBrush linebrush = new LinearGradientBrush();
        DateTime d = DateTime.Now;
        int _Modus = 0;
        bool winter;

        public MainWindow()
        {
            if (!Directory.Exists("C:\\temp\\"))
            {
                Directory.CreateDirectory("C:\\temp\\");
            }

            Me = this;
            InitializeComponent();
            ls = new List<DefaultWerte>();
            xs = new XmlSerializer(typeof(List<DefaultWerte>));
            String.Format("{0:dddd dd MMM YY HH mm}", d);
            string Tag;

            if (d.DayOfWeek.ToString() == "Monday")
            {
                Tag = "Montag";
            }
            else if (d.DayOfWeek.ToString() == "Tuesday")
            {
                Tag = "Dienstag";
            }
            else if (d.DayOfWeek.ToString() == "Wednesday")
            {
                Tag = "Mittwoch";
            }
            else if (d.DayOfWeek.ToString() == "Thursday")
            {
                Tag = "Donnerstag";
            }
            else if (d.DayOfWeek.ToString() == "Friday")
            {
                Tag = "Freitag";
            }
            else if (d.DayOfWeek.ToString() == "Saturday")
            {
                Tag = "Samstag";
            }
            else if (d.DayOfWeek.ToString() == "Sunday")
            {
                Tag = "Sonntag";
            }
            else
            {
                Tag = d.DayOfWeek.ToString();
            }

            textBox161.Text = Tag + ", " + d.ToString();

            try
            {
                FileStream fr = new FileStream(Einstellungen.path, FileMode.OpenOrCreate, FileAccess.Read);
                ls = (List<DefaultWerte>)xs.Deserialize(fr);
                int i = ls.Count;
                i = i - 1;
                textBox1.Text = ls[i].ZeitGuthaben;
                textBox2.Text = ls[i].GekommenH;
                textBox3.Text = ls[i].GekommenM;
                textBox4.Text = ls[i].Pause;
                textBox5.Text = ls[i].WillGehenH;
                textBox6.Text = ls[i].WillGehenM;
                textBox5_Copy1.Text = ls[i].Wunschfaktor;
                textBox5_Copy.Text = ls[i].WunschAStunden;

                if (textBox5_Copy.Text == "")
                {
                    textBox5_Copy.Text = "8";
                }
                if (ls[i].Winter == "True")
                {
                    StartSnow();
                    winter = true;
                }

                if (ls[i].BackColor == "WhiteB")
                {
                    Background = Brushes.White;
                }
                else if (ls[i].BackColor == "DarkGrayB")
                {
                    Background = Brushes.LightGray;
                    button.Background = Brushes.White;
                    button1.Background = Brushes.White;
                    button2.Background = Brushes.White;
                }
                else if (ls[i].BackColor == "GreenB")
                {
                    Background = Brushes.LightGreen;
                }
                else if (ls[i].BackColor == "LightBlueB")
                {
                    Background = Brushes.LightBlue;
                }
                else if (ls[i].BackColor == "RosaB")
                {
                    Background = Brushes.Pink;
                }
                else if (ls[i].BackColor == "LightCoralB")
                {
                    Background = Brushes.LightCoral;
                }
                else if (ls[i].BackColor == "LightYellowB")
                {
                    Background = Brushes.LightGoldenrodYellow;
                }
                else if (ls[i].BackColor == "BlackB")
                {
                    Background = Brushes.DimGray;
                    label10.Foreground = Brushes.Beige;
                    label11.Foreground = Brushes.Beige;
                    label2.Foreground = Brushes.Beige;
                    label3.Foreground = Brushes.Beige;
                    label4.Foreground = Brushes.Beige;
                    label5.Foreground = Brushes.Beige;
                    label6.Foreground = Brushes.Beige;
                    label7.Foreground = Brushes.Beige;
                    label8.Foreground = Brushes.Beige;
                    label9.Foreground = Brushes.Beige;
                    label99.Foreground = Brushes.Beige;
                    label9_Copy.Foreground = Brushes.Beige;
                    label9_Copy1.Foreground = Brushes.Beige;
                    label9_Copy2.Foreground = Brushes.Beige;
                    label9_Copy3.Foreground = Brushes.Beige;
                    label9_Copy4.Foreground = Brushes.Beige;
                    Boarder1.BorderBrush = Brushes.Beige;
                    Boarder2.BorderBrush = Brushes.Beige;
                    button.Background = Brushes.White;
                    button1.Background = Brushes.White;
                    button2.Background = Brushes.White;
                    textBox161.Foreground = Brushes.Beige;
                    label3_Copy.Foreground = Brushes.Beige;
                    label5_Copy1.Foreground = Brushes.Beige;
                }
                else if (ls[i].BackColor == "RealBlackB")
                {
                    Background = Brushes.Black;
                    label10.Foreground = Brushes.Beige;
                    label11.Foreground = Brushes.Beige;
                    label2.Foreground = Brushes.Beige;
                    label3.Foreground = Brushes.Beige;
                    label4.Foreground = Brushes.Beige;
                    label5.Foreground = Brushes.Beige;
                    label6.Foreground = Brushes.Beige;
                    label7.Foreground = Brushes.Beige;
                    label8.Foreground = Brushes.Beige;
                    label9.Foreground = Brushes.Beige;
                    label99.Foreground = Brushes.Beige;
                    label9_Copy.Foreground = Brushes.Beige;
                    label9_Copy1.Foreground = Brushes.Beige;
                    label9_Copy2.Foreground = Brushes.Beige;
                    label9_Copy3.Foreground = Brushes.Beige;
                    label9_Copy4.Foreground = Brushes.Beige;
                    Boarder1.BorderBrush = Brushes.Beige;
                    Boarder2.BorderBrush = Brushes.Beige;
                    button.Background = Brushes.White;
                    button1.Background = Brushes.White;
                    button2.Background = Brushes.White;
                    textBox161.Foreground = Brushes.Beige;
                    label3_Copy.Foreground = Brushes.Beige;
                    label5_Copy1.Foreground = Brushes.Beige;

                }
                else if (ls[i].BackColor == "BuntB")
                {

                    linebrush.StartPoint = new Point(0, 0);
                    linebrush.EndPoint = new Point(0, 1);
                    linebrush.GradientStops.Add(
                        new GradientStop(Colors.Yellow, 0.0));
                    linebrush.GradientStops.Add(
                        new GradientStop(Colors.Red, 0.25));
                    linebrush.GradientStops.Add(
                        new GradientStop(Colors.Blue, 0.75));
                    linebrush.GradientStops.Add(
                        new GradientStop(Colors.LimeGreen, 1.0));
                    Background = linebrush;
                }

                if (ls[i].Modus == "True")
                {
                    label5.Content = "Zeitguthaben wie angegeben (zb. 1,93 oder -0,83)";
                    label5.ToolTip = "= Faktor, wie im inesCRM unter 'Tagespräsenzzeiten' -> 'GL-Saldo std.' angegeben";
                    label3_Copy.Content = "[Modus: Faktor | Alt]";
                    _Modus = 0;
                }
                else if (ls[i].Modus == "False")
                {
                    label5.Content = "Zeitguthaben mit Komma getrennt";
                    label5_Copy1.Content = "(zb. 2:03 = 2,03 oder -1:87 = -1,87)";
                    label5.ToolTip = "= Überstunden, wie im Vertec unter\n'Übersicht Leistungen' -> 'Überzeitsaldo (exkl. Heute) angegeben'";
                    label3_Copy.Content = "[Modus: Uhrzeit | Neu]";
                    _Modus = 1;
                }
                else
                {
                    label5.Content = "Zeitguthaben mit Komma getrennt";
                    label5_Copy1.Content = "(zb. 2:03 = 2,03 oder -1:87 = -1,87)";
                    label5.ToolTip = "= Überstunden, wie im Vertec unter\n'Übersicht Leistungen' -> 'Überzeitsaldo (exkl. Heute) angegeben'";
                    label3_Copy.Content = "[Modus: Uhrzeit | Neu]";
                    _Modus = 1;
                }

                fr.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = "0,00";
                textBox2.Text = "08";
                textBox3.Text = "00";
                textBox4.Text = "30";
                textBox5.Text = "17";
                textBox6.Text = "00";
                textBox5_Copy1.Text = "2,5";
                textBox5_Copy.Text = "8";

                label5.Content = "Zeitguthaben mit Komma getrennt";
                label5_Copy1.Content = "(zb. 2:03 = 2,03 oder -1:87 = -1,87)";
                label5.ToolTip = "= Überstunden, wie im Vertec unter\n'Übersicht Leistungen' -> 'Überzeitsaldo (exkl. Heute) angegeben'";
                label3_Copy.Content = "[Modus: Uhrzeit | Neu]";
                _Modus = 1;
                // StartSnow(); //Kann Ab januar Deaktiviert WERDEN!
            }
            textBox1.Focus();
            textBox1.SelectAll();

            if (Background != Brushes.LightCoral && winter == true)
            {
                MessageBox.Show("Glückwunsch!\n\nNun gibt es 2 Möglichkeiten, wie du auf dieses EasterEgg gekommen bist.\n1.: Ein Bug, den ich noch nicht erkannt habe, oder\n2.: Du hast tatsächlich den Wintermodus drin gehabt und wolltest eine andere Hintergrundfarbe und hattest die schlaue Idee, in der .XML-Datei einfach die Farbe zu ändern. \n\nSolltest du es nur durch zufall bekommen haben, schreib mir bitte eine EMail, ansonsten Hut ab ;) und einen schönen " + Tag + " dir.", "EasterEgg");
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            string completeString = null;
            if (sender is TextBox)
            {
                TextBox tb = ((TextBox)sender);
                string currentText = tb.Text.Remove(tb.SelectionStart, tb.SelectionLength);
                currentText.Insert(tb.CaretIndex, e.Text);
                completeString = currentText.Insert(tb.CaretIndex, e.Text);
            }
            Regex regex = new Regex(@"^([+-]?(((6(,)?)|(6,0{1,2}))|([0-5](,)?)|([0-5],\d{1,2}?))?)$");
            e.Handled = !regex.IsMatch(completeString);
        }
        private void NumberValidationTextBoxOnlyNumber(object sender, TextCompositionEventArgs e)
        {
            string completeString = null;
            if (sender is TextBox)
            {
                TextBox tb = ((TextBox)sender);
                string currentText = tb.Text.Remove(tb.SelectionStart, tb.SelectionLength);
                currentText.Insert(tb.CaretIndex, e.Text);
                completeString = currentText.Insert(tb.CaretIndex, e.Text);
            }
            Regex regex = new Regex(@"^([0-9]{1,3})$");
            e.Handled = !regex.IsMatch(completeString);
        }
        private void NumberValidationTextBoxSpecial(object sender, TextCompositionEventArgs e)
        {
            string completeString = null;
            if (sender is TextBox)
            {
                TextBox tb = ((TextBox)sender);
                string currentText = tb.Text.Remove(tb.SelectionStart, tb.SelectionLength);
                currentText.Insert(tb.CaretIndex, e.Text);
                completeString = currentText.Insert(tb.CaretIndex, e.Text);
            }
            Regex regex = new Regex(@"^((([0-1]?[0-9](,)?)|([0-2]?[0-9],\d{1,2}?))?)$");
            e.Handled = !regex.IsMatch(completeString);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double i = 0;
                double saldo = Convert.ToDouble(textBox1.Text);
                double saldoUV = Convert.ToDouble(textBox1.Text);
                double beginnH = Convert.ToDouble(textBox2.Text);
                double beginnM = Convert.ToDouble(textBox3.Text);
                double beginnH1 = Convert.ToDouble(textBox2.Text);
                double beginnM1 = Convert.ToDouble(textBox3.Text);
                double beginnH2 = Convert.ToDouble(textBox2.Text);
                double beginnM2 = Convert.ToDouble(textBox3.Text);
                double pause = Convert.ToDouble(textBox4.Text);
                double zielZeitH = Convert.ToDouble(textBox5.Text);
                double zielZeitM = Convert.ToDouble(textBox6.Text);
                double GewollteAZ = Convert.ToDouble(textBox5_Copy.Text); 
                double nullraush = beginnH + 8;
                double nullrausm = beginnM + pause;
                double faktorraush = 0;
                double faktorrausm = 0;
                double wunschfaktor = Convert.ToDouble(textBox5_Copy1.Text);
                double rechnung = 0;
                double rechnung2 = 0;
                double rechnung3 = 0;
                double neueStunden = 0;
                double neueStundenfaktor = 0;
                double inH = -1;
                double DeinFaktor = 0;
                double saldoMin = 0;
                double inMin = -1;
                String fooNull = "";
                String fooNull2 = "";
                String fooNeg = "";
                String fooNull3 = "";
                String fooNull4 = "";
                String fooNull5 = "";

                if (beginnH < 0 || beginnH > 23 || beginnM < 0 || beginnM >= 60 || zielZeitH < 0 || pause > 180 || zielZeitH > 23 || zielZeitM < 0 || zielZeitM >= 60 || beginnH > zielZeitH || (beginnH == zielZeitH && beginnM > zielZeitM) || GewollteAZ>15 || GewollteAZ<0)
                {

                    MessageBox.Show("Du hast irgendwo eine falsche Uhrzeit angegeben.\n\n- Hast du etwas eingegeben, was außerhalb unserer Zeitrechnung liegt, zB.: 31:45 Uhr oder 12:93 Uhr ?\n\n- Ist die Zeit, wann du heute gehen magst, auch wirklich 'größer' als dein Beginn heute?\n\n- Hast du statt '00:23 Uhr' vielleicht '24:23 Uhr' eingegeben?\n\n- Hast du eine Pausenzeit > 3 Stunden angegeben?\n\n- Hast du vor, Heute über 15 oder unter 0 Stunden zu arbeiten?", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (saldo == 1.61 && _Modus == 0)
                    {
                        MessageBox.Show("Du hast ein EasterEggs gefunden (durch die Eingabe von 1,61 im Faktorfeld).\n\nHier ein TeeTipp: Auch wenn die Meinungen auseinander gehen, was die Wahl des Tees und die Zufuhr von Zucker angeht, habe ich hier mal meine bevorzugte Vorgehensweise für euch: Morgens zum Fitt werden lohnt sich etwas süßes, ein Rooibos/Vanille/Schwarz- oder Früchtetee mit 2 Stück Zucker ist da super! Nach dem Mittagessen ist dann etwas erfrischenderes angesagt, Fenchel und Minze (in allen Variationen) sind meine Favoriten, aber auch Limone/Zitrone ist gut. Bei diesen Tees wird dann auch kein Zucker mehr benötigt. Viel Spaß beim Genießen.", "Glückwunsch", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    if (GewollteAZ > 12)
                    {
                        MessageBox.Show("Du darfst idr. nicht länger als 12 h arbeiten.", "Achtung", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    if (pause > 120 || pause < 30)
                    {
                        MessageBox.Show("Das ist keine gültige Pausenzeit. Diese muss mindestens 30 Minuten betragen, maximal 120 Minuten.\n\nDer Zeitrechner funktioniert trotzdem:\nFalls du unter 6 h gearbeitet hast und deshalb keine Pause machst, ignorier diese Nachricht einfach.\nBeachte bitte, dass es bei Pausen über 2 h zu Fehlern kommen kann.", "Achtung", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    if (saldoUV > 4 || saldoUV < -4 || wunschfaktor < -4 || wunschfaktor > 4 && _Modus == 0)
                    {
                        MessageBox.Show("Alles was mehr als 4 h beträgt ( also Zeitguthaben > 4 oder < -4), kann nicht durch die Gleitzeitregelung ausgeglichen werden sondern muss als Kompensationszeit beantragt werden. Außerdem kann es bei diesem Programm zu Fehlern führen, wenn größere Faktoren angegeben werden.", "Achtung", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    while (nullrausm > 59)
                    {
                        nullrausm = nullrausm - 60;
                        nullraush = nullraush + 1;
                    }

                    if (_Modus == 0)
                    {
                        saldoMin = saldo * 60;
                        if (saldo >= 0)
                        {
                            inH = Math.Floor(saldo);
                            inMin = Math.Floor((saldo - inH) * 60);
                        }
                        else
                        {
                            saldo = saldo * -1;
                            inH = Math.Floor(saldo);
                            inMin = Math.Floor((saldo - inH) * 60);
                            fooNeg = "-";
                        }
                        DeinFaktor = saldoUV;
                    }
                    else if (_Modus == 1)
                    {
                        if (saldo >= 0)
                        {
                            inH = Math.Floor(saldo);
                            inMin = Math.Floor(((saldo - inH) * 100)+0.0000001);
                            saldoMin = inH * 60 + inMin;
                        }
                        else
                        {
                            saldo = saldo * -1;
                            inH = Math.Floor(saldo);
                            inMin = Math.Floor((saldo - inH) * 100);
                            fooNeg = "-";
                            saldoMin = (inH * 60 + inMin) * -1;
                        }
                        DeinFaktor = saldoMin / 60;
                    }

                    rechnung = 480 + pause - saldoMin;
                    rechnung = rechnung / 60;
                    double r_1 = rechnung;
                    rechnung2 = rechnung;
                    rechnung = Math.Floor(rechnung);
                    double r_2 = rechnung;
                    double r2_1 = rechnung2;
                    rechnung3 = rechnung2 - rechnung;
                    double r3_1 = rechnung3;
                    rechnung3 = rechnung3 * 60;
                    double r3_2 = rechnung3 + 1;
                    rechnung3 = Math.Floor(rechnung3);
                    double r3_3 = rechnung3;

                    r3_2 = Math.Floor(r3_2);

                    if (r3_2 >= 0 && r3_2 <= 9)
                    {
                        fooNull2 = "0";
                    }
                    else
                    {
                        fooNull2 = "";

                    }

                    beginnH = beginnH + rechnung;
                    beginnM = beginnM + rechnung3 + 1;

                    if (beginnM >= 60)
                    {
                        beginnM = beginnM - 60;
                        beginnH++;

                    }
                    if (beginnH >= 24)
                    {
                        beginnH = beginnH - 24;
                    }

                    if (beginnM >= 0 && beginnM <= 9)
                    {
                        fooNull = "0";
                    }
                    else
                    {
                        fooNull = "";

                    }

                    double zielZeitGes = (zielZeitH * 60) + zielZeitM;
                    double zzg1 = zielZeitGes;
                    zielZeitGes = zielZeitGes - pause - (beginnH1 * 60 + beginnM1);
                    neueStunden = ((zielZeitGes - 480) + saldoMin);
                    neueStundenfaktor = ((neueStunden / 60));

                    if (zielZeitM <= 0 && zielZeitM <= 9)
                    {
                        fooNull3 = "0";
                    }

                    if (nullrausm >= 0 && nullrausm <= 9)
                    {
                        fooNull4 = "0";
                    }

                    if (wunschfaktor < DeinFaktor)
                    {
                        double nfrechnerB = DeinFaktor - wunschfaktor;
                        double nfrechnerminB = nfrechnerB * 60;
                        if (nfrechnerminB > 0)
                        {
                            nfrechnerminB = Math.Ceiling(nfrechnerminB);

                        }
                        else
                        {
                            nfrechnerminB = Math.Floor(nfrechnerminB);
                        }

                        faktorraush = beginnH2 + 8;
                        faktorrausm = beginnM2 + pause - nfrechnerminB + 1;

                        while (faktorrausm < 0)
                        {

                            if (i == 0)
                            {
                                faktorrausm = faktorrausm + 59;
                                faktorraush = faktorraush - 1;
                                i++;
                            }
                            else
                            {
                                faktorrausm = faktorrausm + 60;
                                faktorraush = faktorraush - 1;
                            }
                        } while (faktorrausm > 59)
                        {
                            faktorrausm = faktorrausm - 61;
                            faktorraush = faktorraush + 1;

                        }

                        if (faktorrausm >= 0 && faktorrausm <= 9)
                        {
                            fooNull5 = "0";
                        }

                    }
                    else if (wunschfaktor == DeinFaktor)
                    {
                        MessageBox.Show("Du hast deinen Wunschfaktor schon erreicht. Um ihn zu halten musst du bis " + nullraush + " : " + fooNull4 + nullrausm + " Uhr bleiben( inkl. angegebener Pausenzeit).", "Achtung", MessageBoxButton.OK, MessageBoxImage.Warning);
                        faktorrausm = nullrausm;
                        faktorraush = nullraush;
                    }
                    else
                    {
                        double nfrechner = wunschfaktor - DeinFaktor;
                        double nfrechnermin = nfrechner * 60;

                        if (nfrechnermin > 0)
                        { nfrechnermin = Math.Ceiling(nfrechnermin); }
                        else
                        { nfrechnermin = Math.Floor(nfrechnermin); }

                        faktorraush = beginnH2 + 8;
                        faktorrausm = beginnM2 + pause + nfrechnermin;

                        while (faktorrausm > 59)
                        {
                            faktorrausm = faktorrausm - 60;
                            faktorraush = faktorraush + 1;
                        }

                        if (faktorrausm >= 0 && faktorrausm <= 9)
                        {
                            fooNull5 = "0";
                        }

                    }

                    WieVielHArbeiten WVHA = new WieVielHArbeiten();
                    string WVHAString = WVHA.WieVielHArbeitenR(beginnH2, beginnM2, pause, GewollteAZ, saldoUV,_Modus);

                    var text = new TextBlock();
                    text.Inlines.Add((new Run("Deine Minuten: ")));
                    text.Inlines.Add(new Bold(new Run(saldoMin + "")));
                    text.Inlines.Add((new Run("     bzw.:  ")));
                    text.Inlines.Add(new Bold(new Run(fooNeg + "")));
                    text.Inlines.Add((new Run(" ")));
                    text.Inlines.Add(new Bold(new Run(inH + "")));
                    text.Inlines.Add((new Run("  : ")));
                    text.Inlines.Add(new Bold(new Run(inMin + "")));
                    text.Inlines.Add((new Run("  [h : min]\nDein Faktor: ")));
                    text.Inlines.Add(new Bold(new Run(DeinFaktor + "")));
                    text.Inlines.Add((new Run("\n\nDu kannst heute um ")));
                    text.Inlines.Add(new Bold(new Run(beginnH + "")));
                    text.Inlines.Add((new Run(" : ")));
                    text.Inlines.Add(new Bold(new Run(fooNull + "")));
                    text.Inlines.Add((new Run("")));
                    text.Inlines.Add(new Bold(new Run(beginnM + "")));
                    text.Inlines.Add((new Run(" Uhr gehen,\n\nmusst also ")));
                    text.Inlines.Add(new Bold(new Run(r_2 + "")));
                    text.Inlines.Add((new Run(" : ")));
                    text.Inlines.Add(new Bold(new Run(fooNull2 + r3_2 + "")));
                    text.Inlines.Add((new Run(" [h : min] arbeiten( inkl. Pause).\n\nUm weder Stunden zu gewinnen, noch zu\nverlieren, musst du bis ")));
                    text.Inlines.Add(new Bold(new Run(nullraush + "")));
                    text.Inlines.Add((new Run(" : ")));
                    text.Inlines.Add(new Bold(new Run(fooNull4 + nullrausm + "")));
                    text.Inlines.Add((new Run(" Uhr\nbleiben( inkl. angegebener Pausenzeit).\n   ----------------------------------------------------   \nWenn du um ")));
                    text.Inlines.Add(new Bold(new Run(zielZeitH + "")));
                    text.Inlines.Add((new Run(" : ")));
                    text.Inlines.Add(new Bold(new Run(fooNull3 + zielZeitM + "")));
                    text.Inlines.Add((new Run(" gehst, hast du insgesamt\n")));
                    text.Inlines.Add(new Bold(new Run(neueStunden + "")));
                    text.Inlines.Add((new Run(" Minuten (bzw. Faktor ")));
                    text.Inlines.Add(new Bold(new Run(neueStundenfaktor + "")));
                    text.Inlines.Add((new Run(" )\nauf deiner Uhr.\n\nWenn du den Faktor ")));
                    text.Inlines.Add(new Bold(new Run(wunschfaktor + "")));
                    text.Inlines.Add((new Run(" haben willst,\nmusst du bis ")));
                    text.Inlines.Add(new Bold(new Run(faktorraush + "")));
                    text.Inlines.Add((new Run(" : ")));
                    text.Inlines.Add(new Bold(new Run(fooNull5 + faktorrausm + "")));
                    text.Inlines.Add((new Run(" Uhr bleiben.")));
                    text.Inlines.Add((new Run(WVHAString + "")));

                    /*label2.Content = "Deine Minuten: " + saldoMin +
                        "     bzw.:  " + fooNeg +
                        " " + inH +
                        " : " + inMin +
                        "  [h : min]\nDein Faktor: " + DeinFaktor +
                        "\n\nDu kannst heute um " + beginnH +
                        " : " + fooNull +
                        "" + beginnM +
                        " Uhr gehen,\n\nmusst also " + r_2 +
                        " : " + fooNull2 + r3_2 +
                        " [h : min] arbeiten( inkl. Pause).\n\nUm weder " +
                        "Stunden zu gewinnen, noch zu\nverlieren, musst du bis " + nullraush +
                        " : " + fooNull4 + nullrausm +
                        " Uhr\nbleiben( inkl. angegebener Pausenzeit).\n   " +
                        "----------------------------------------------" +
                        "   \nWenn du um " + zielZeitH +
                        " : " + fooNull3 + zielZeitM +
                        " gehst, hast du insgesamt\n" + neueStunden +
                        " Minuten (bzw. Faktor " + neueStundenfaktor +
                        " )\nauf deiner Uhr.\n\nWenn du den Faktor " + wunschfaktor +
                        " haben willst,\nmusst du bis " + faktorraush +
                        " : " + fooNull5 + faktorrausm +
                        " Uhr bleiben."; */

                    label2.Content = text;

                    //   MessageBox.Show("saldo "+saldo+"\nsaldomin "+saldoMin+"\nbeginh "+beginnH+"\nbeginnm "+beginnM+"\nrechnung "+rechnung+"\nr_1 "+r_1+"\nr_2 "+r_2+"\nrechnung2 "+rechnung2+"\nr2_1 "+r2_1+"\nrechnung3 "+rechnung3+"\nr3_1 "+r3_1+"\nr3_2 "+r3_2+"\nr3_3 "+r3_3+"\npause "+pause+"\nfooNull "+fooNull+"\nfooNeg "+fooNeg+"\ninH "+inH+"\ninMin "+inMin, "Fehler");
                    //MessageBox.Show("zielzeitH "+zielZeitH+"\nzzm "+zielZeitM+"\nzzg "+zielZeitGes+"\nneuS "+neueStunden+"\nneuSfakt"+neueStundenfaktor+"\nzzg1 "+zzg1, "Fehler");
                    //MessageBox.Show("wunschfaktor: "+wunschfaktor+"\nSaldoUV: "+saldoUV+"\nnfrechner: "+nfrechner+"\nfaktorraush: "+faktorraush+"\nfaktorrausm: "+faktorrausm+"\nfoonull5: "+fooNull5+ "\nnfrechnermin: "+ nfrechnermin+"\nbeginnH2: "+beginnH2+"\nbeginnM2: "+beginnM2);

                }

            }
            catch (FormatException ex)
            {
                label2.Content = "ERGEBNIS = -1";
                MessageBox.Show("Geben sie bitte eine Zahl ein\n\n" + ex, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (OverflowException ov)
            {
                label2.Content = "ERGEBNIS = -1";
                MessageBox.Show("Geben sie bitte eine Zahl ein\n\n" + ov, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Einstellungen Ee = new Einstellungen();
            Ee.ShowDialog();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);            //works for tab into textbox
            EventManager.RegisterClassHandler(typeof(TextBox),
                TextBox.GotFocusEvent,
                new RoutedEventHandler(TextBox_GotFocus));
            //works for click textbox
            EventManager.RegisterClassHandler(typeof(Window),
                Window.GotMouseCaptureEvent,
                new RoutedEventHandler(Window_MouseCapture));
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void Window_MouseCapture(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox != null)
                textBox.SelectAll();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button2_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                Close();
            }
            if (e.Key == Key.I || e.Key == Key.E)
            {
                button_Click(this, e);
            }
            if (e.Key == Key.N)
            {
                if (MessageBox.Show("Bist du sicher, dass du das Programm neustarten willst?", "Neustarten", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            if (e.Key == Key.H || e.Key == Key.A)
            {
                Anleitung An = new Anleitung();
                An.ShowDialog();
            }


        }

        public void StartSnow()
        {
            snow = new SnowEngine(canvas, "pack://application:,,,/Graphics/snow1.png",
"pack://application:,,,/Graphics/snow2.png",
"pack://application:,,,/Graphics/snow3.png",
"pack://application:,,,/Graphics/snow4.png",
"pack://application:,,,/Graphics/snow5.png",
"pack://application:,,,/Graphics/snow6.png",
"pack://application:,,,/Graphics/snow7.png",
"pack://application:,,,/Graphics/snow8.png",
"pack://application:,,,/Graphics/snow9.png");
            Background = Brushes.LightCoral;
            label10.Foreground = Brushes.Black;
            label11.Foreground = Brushes.Black;
            label2.Foreground = Brushes.Black;
            label3.Foreground = Brushes.Black;
            label4.Foreground = Brushes.Black;
            label5.Foreground = Brushes.Black;
            label6.Foreground = Brushes.Black;
            label7.Foreground = Brushes.Black;
            label8.Foreground = Brushes.Black;
            label9.Foreground = Brushes.Black;
            label99.Foreground = Brushes.Black;
            label9_Copy.Foreground = Brushes.Black;
            label9_Copy1.Foreground = Brushes.Black;
            label9_Copy2.Foreground = Brushes.Black;
            label9_Copy3.Foreground = Brushes.Black;
            label9_Copy4.Foreground = Brushes.Black;
            Boarder1.BorderBrush = Brushes.Black;
            Boarder2.BorderBrush = Brushes.Black;
            button.Background = Brushes.LightGray;
            button1.Background = Brushes.LightGray;
            button2.Background = Brushes.LightGray;
            textBox161.Foreground = Brushes.Black;
            label3_Copy.Foreground = Brushes.Black;
            label5_Copy1.Foreground = Brushes.Black;
            snow.Start();
        }

        public void StopSnow()
        {
            Background = Brushes.White;
            snow.Stop();
        }

        private void Window_Closing_1(object sender, CancelEventArgs e)
        {
            try
            {
                Close();
            }
            catch (System.InvalidOperationException)
            {
                Environment.Exit(0);
            }
        }

        public bool IsSnowing()
        {
            if (snow == null)
            {
                return false;
            }
            return snow.IsWorking;
        }

        private void label3_Copy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i = ls.Count;
            i = i - 1;
            FileStream fs = new FileStream(Einstellungen.path, FileMode.OpenOrCreate, FileAccess.Write);
            DefaultWerte sc = new DefaultWerte();
            sc.ZeitGuthaben = ls[i].ZeitGuthaben;
            sc.GekommenH = ls[i].GekommenH;
            sc.GekommenM = ls[i].GekommenM;
            sc.Pause = ls[i].Pause;
            sc.WillGehenH = ls[i].WillGehenH;
            sc.WillGehenM = ls[i].WillGehenM;
            sc.Wunschfaktor = ls[i].Wunschfaktor;
            sc.Winter = ls[i].Winter.ToString();
            sc.BackColor = ls[i].BackColor.ToString();
         
            if (ls[i].Modus == "True")
            {
                sc.Modus = "False";
            }
            else if (ls[i].Modus == "False")
            {
                sc.Modus = "True";
            }

            sc.WunschAStunden = ls[i].WunschAStunden;
            ls.Add(sc);
            xs.Serialize(fs, ls);
            fs.Close();

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.P)
            {
                string s = textBox4.Text;
                textBox4.Focus();
                textBox4.Text = s;
            }
            if (e.Key == Key.Z)
            {
                string s = textBox1.Text;
                textBox1.Focus();
                textBox1.Text = s;
            }
            if (e.Key == Key.B)
            {
                string s = textBox2.Text;
                textBox2.Focus();
                textBox2.Text = s;
            }
            if (e.Key == Key.G)
            {
                string s = textBox5.Text;
                textBox5.Focus();
                textBox5.Text = s;
            }
            if (e.Key == Key.W)
            {
                string s = textBox5_Copy1.Text;
                textBox5_Copy1.Focus();
                textBox5_Copy1.Text = s;
            }
            if (e.Key == Key.S)
            {
                string s = textBox5_Copy.Text;
                textBox5_Copy.Focus();
                textBox5_Copy.Text = s;
            }
            if (e.Key == Key.M)
            {
                string mailto = string.Format("mailto:{0}?Subject={1}&Body={2}", "kirchner.oscar@googlemail.com", "(An-)Frage ZeitrechnerApp", "Hallo Oscar,");
                mailto = Uri.EscapeUriString(mailto);
                Process mailStart = Process.Start(mailto);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfApplication1.Rechnungen;
using WpfApplication1.Resources;

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für Einstellungen.xaml
    /// </summary>
    public partial class Einstellungen : Window
    {
        public XmlSerializer xs;
        public List<DefaultWerte> ls;
        public static string path = "C:\\temp\\ZeitRechnerDefaultEinstellungen.Xml";
        IMainFrame MainFrame;
        public Einstellungen()
        {
            MainFrame = MainWindow.Me;
            InitializeComponent();
            checkBox.IsChecked = MainFrame.IsSnowing(); //Kann Ab januar Deaktiviert WERDEN! NEIN!
            button3.ToolTip = "Hier findest du eine Anleitung,\nwie dieses Programm zu nutzen ist";
            textBox_Copy6.ToolTip ="Weitere Beispiele:\n6h und 10 min = 6,1 oder 6,10\n7h = 7 oder 7,0 oder 7,00";

            TCList.ItemsSource = CreateTCList();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TCList.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Fenster");
            view.GroupDescriptions.Add(groupDescription);

            if (checkBox.IsChecked == true)
            {
                label2_Copy.IsEnabled = false;
                comboBox.IsEnabled = false;
            }
            else
            {
                checkBox.IsChecked = false;
                label2_Copy.IsEnabled = true;
                comboBox.IsEnabled = true;
            }

            Oeffnet();
            ls = new List<DefaultWerte>();
            xs = new XmlSerializer(typeof(List<DefaultWerte>));
            try
            {
                FileStream fr = new FileStream(path, FileMode.Open, FileAccess.Read);
                ls = (List<DefaultWerte>)xs.Deserialize(fr);
                int i = ls.Count;
                i = i - 1;
                textBox.Text = ls[i].ZeitGuthaben;
                textBox_Copy.Text = ls[i].GekommenH;
                textBox_Copy1.Text = ls[i].GekommenM;
                textBox_Copy2.Text = ls[i].Pause;
                textBox_Copy3.Text = ls[i].WillGehenH;
                textBox_Copy4.Text = ls[i].WillGehenM;
                textBox_Copy5.Text = ls[i].Wunschfaktor;
                textBox_Copy6.Text = ls[i].WunschAStunden;

                if (textBox_Copy6.Text == "")
                {
                    textBox_Copy6.Text = "8";
                }
                if (ls[i].Winter == "True")
                {
                    checkBox.IsChecked = true;
                }
                else
                {
                    checkBox.IsChecked = false;
                }

                if (ls[i].BackColor == "WhiteB")
                {
                    comboBox.SelectedItem = WhiteB;
                }
                else if (ls[i].BackColor == "DarkGrayB")
                {
                    comboBox.SelectedItem = DarkGrayB;
                }
                else if (ls[i].BackColor == "GreenB")
                {
                    comboBox.SelectedItem = GreenB;
                }
                else if (ls[i].BackColor == "LightBlueB")
                {
                    comboBox.SelectedItem = LightBlueB;
                }
                else if (ls[i].BackColor == "RosaB")
                {
                    comboBox.SelectedItem = RosaB;
                }
                else if (ls[i].BackColor == "LightCoralB")
                {
                    comboBox.SelectedItem = LightCoralB;
                }
                else if (ls[i].BackColor == "LightYellowB")
                {
                    comboBox.SelectedItem = LightYellowB;
                }
                else if (ls[i].BackColor == "BlackB")
                {
                    comboBox.SelectedItem = BlackB;
                }
                else if (ls[i].BackColor == "RealBlackB")
                {
                    comboBox.SelectedItem = RealBlackB;
                }
                else if (ls[i].BackColor == "BuntB")
                {
                    comboBox.SelectedItem = BuntB;
                }

                if (ls[i].Modus == "True")
                {
                    radioButton.IsChecked = true;
                }
                else if(ls[i].Modus == "False")
                {
                    radioButton_Copy.IsChecked = true;
                }
                else
                {
                    radioButton_Copy.IsChecked = true;
                }

                fr.Close();
            }
            catch (Exception ex)
            {
                //    comboBox.SelectedItem = LightCoralB; //auf weiß ändern im januar
                comboBox.SelectedItem = WhiteB; //auf weiß ändern im januar
                radioButton_Copy.IsChecked = true;

            }
        }


        public void Oeffnet()
        {
            textBlock.Text = "[Changelog:]" +
                 "\n[-v2_0:       Vertec Einführung]*" +
                 "\n-v2_1:        Verschiedene Modus für Uhrzeit oder Faktor" +
                 "\n-v2_1_1:     Bug fixes" +
                 "\n[-v2_1_2:    Bug fixes und graphische Anpassungen]*" +
                 "\n-v2_1_3:     Bug fixes und 'Reset' zu neuer Version festgelegt" +
                 "\n-v2_1_3_1:  Kleinere Anpassungen (graphisch und rechnerisch)" +
                 "\n-v2_1_4:     Tasten-Controlls für Einstellungsmenu hinzugefügt" +
                 "\n-v2_1_5:     Verbesserung d. Darstellung d. 'Tipps & Tricks-Reiter'" +
                 "\n-v2_1_6:     EasterEggs und Anleitung hinzugefügt" +
                 "\n-v2_1_7:     Bug fixes und graphische Anpassungen" +
                 "\n[-v2_1_8:    Scroll-Anpassungen (unter T&T lesen) & PathExist/Create]" +
                 "\n-v2_2:        WunschArbeitsStunden hinzugefügt inkl. Speicherung" +
                 "\n-v2_2_1:     Bug fixes und WunschArbeitsStunden im Faktor-Modus" +
                 "\n-v2_2_2:     Bug fixes und TastenControl-Liste" +
                 "\n-v2_2_3:     Bug fixes und 'Schnell-Modus-Wechsel'" +
                 "\n\n[AlterChangelog:]" +
                 "\n-v1_1:         Hinzufügen der Zeit, wann man gehen möchte" +
                 "\n-v1_1_1:     Keyboard-Kontrolle hinzugefügt" +
                 "\n-v1_1_2:     Bug fixes" +
                 "\n-v1_2:         Wunschfaktor berechnen" +
                 "\n-v1_2_1:     Bug fixes" +
                 "\n-v1_3:         Wunschfaktor auch kleiner als aktueller Faktor möglich" +
                 "\n-v1_3_1:     Bug fixes und Anpassungen der Grenzwerte und" +
                 "\n                  Messageboxen" +
                 "\n-v1_3_2:     Tooltipps mit Beispielen zu den jeweiligen Labels" +
                 "\n                  hinzugefügt und Formulierungen angepasst" +
                 "\n-v1_3_3:     Noch mehr Tasten-Controlls hinzugefügt" +
                 "\n-v1_3_4:     Bug fixes bei Wunschfaktor < Zeitguthaben" +
                 "\n-v1_3_5:     WinterSpecial hinzugefügt" +
                 "\n-v1_3_6:     Feldeingabe auf Numeric beschränkt" +
                 "\n-v1_4:         Einstellungsmenü statt Infobox" +
                 "\n-v1_4_1:     Bug fixes" +
                 "\n-v1_4_2:     Einstellungsmenü Allg. freigeschalten" +
                 "\n-v1_4_3:     Bug fixes und Anpassung in den allg. Einstellungen" +
                 "\n[-v1_5:        Wintermodus optional und Hintergrundfarben]*" +
                 "\n-v1_5_1:     Bug fixes, Neustart nach Speicherung, mehr Farben" +
                 "\n-v1_5_2:     Vorerst Finale Version auch Firmenübergreifend" +
                 "\n-v1_5_3:     Ende, neue Version (v2_0) findet ihr in meinem Transfer oder ihr schreibt mir eine Email." +
                 "\n\nGeplant:" +
                 "\n-Auto-Jump bei den Uhrzeitfeldern" +
                 "\n-Sprachen DE und EN" +
                 "\n-Bei weiteren Ideen: schreibt mir gerne eine Email" +
                 "\n\nMit [..]* gekennzeichnete Versionen wurden nicht öffentlich released." +
                // "\n>Zur Zeit sind alle Ideen umgesetzt. Wenn euch was ein-/auffällt, schreibt mir gerne eine Email." +
                "";
            textBlock1.Text = "" +
                "\nDiese Anwendung wurde von Oscar Kirchner zur Errechnung der Kompensationszeiten " +
                "bei der ines GmbH Konstanz geschrieben. " +
                "\nSeit der Umstellung auf ein anderes CRM-System (Vertec) hat sich bei der Berechung etwas geändert. Da viele Firmen diese, sowie die alte Art der Stundenberechnung nutzen, ist das Programm ab jetzt für alle verfügbar. Auf GitHub findet ihr den kompletten Code für die alte Version. In dieser Version ist sowohl die alte als auch die neue Berechnungsweise möglich, für genauere Infos müsst ihr in die Anleitung schauen. Die aktuelle Version kommt demnächst auch auf Github." +
                "\n\nVerbesserungsvorschläge oder Bugs gerne an kirchner.oscar@googlemail.com" +
                "";
            textBlock3.Text = "[Nützliches:] [Unsortiert]" +
                "\n\n- Per TAB- und Enter-Taste könnt ihr das Programm ohne Maus nutzen. Weitere Tasten-Controls findet ihr im TAB-Reiter 'TastenControls'" +
                "\nUm das Programm komplett ohne Maus nutzen zu können, solltet ihr wissen: mit den Pfeil-Tasten lässt sich scrollen, allerdings erst, wenn der ScrollView im Focus ist. Hierzu müsst ihr einfach nochmal den Buchstaben drücken, der den aktuellen Tab aufgerufen hat." +
                "\n\n- Dein Wunschfaktor kann größer oder kleiner als dein aktuelles Zeitguthaben sein. Auch die Zeit, zu der du heute gehen magst kannst" +
                " du unabhängig von allem Anderen eintragen." +
                "\n\n- '24:00 Uhr' solltest du als '00:00 Uhr' angeben, sonst bekommst du einen Fehler. Liegt aber sowieso ausserhalb der Regelzeiten." +
                "\n\n- Wenn ihr den Wintermodus aktiviert habt, wird die Hintergrundfarbe immer automatisch auf Rot gesetzt." +
                "\n\n- Ihr könnt bis Faktor +/- 6,00 Rechnen, denkt aber bitte daran, dass eigentlich max. +/- 4 Stunden an einem Tag ausgeglichen werden können." +
                "\n\n- Im Reiter 'Allgemein' könnt ihr eure eigenen Defaultwerte in den Einstellungen festlegen, diese werden unter 'C:\\temp\\ZeitRechnerDefaultEinstellungen.Xml' gespeichert." +
                "\n\n- Betrifft die alte Version: Denk daran, dass in der ines-Zeiterfassung abgerundet wird. Wird dir also als neuer Faktor '1,48666..' angezeigt wird, hast du nachher '1,48' auf deinem konto, nicht '1,49'." +
                "\n\n- Einen Schnell-Modus-Wechsel könnt ihr durch einen Doppelklick auf die Modusanzeige unten rechts" +
                "\n\n- Es kann zu sog. weichen Fehlern kommen, zB. wenn die angegebene Pausenzeit nicht mindestens 30 Minuten beträgt. Diese werden durch eine Meldung mit dem Titel 'Achtung' gekennzeichnet, der Zeitrechner rechnet aber trotzdem. Bitte beachte, dass es in so einem Fall zu Fehlern kommen kann." +
                "\n\n- Sollte der Zeitrechner das erste mal über eine Verknüpfung auf eurem Rechner gestartet werden, kann es sein, dass ihr beim Speichern eurer Defaultwerte den Fehler erhaltet, dass auf die XML-Datei nicht zugegriffen werden kann, bzw. dass diese bereits verwendet wird. Hier hilft es, einmal die" +
                "'richtige' .exe-Datei auszuführen und nicht die Verknüpfung. Danach sollte alles wie gewohnt auch mit der Verknüpfung funktionieren, falls nicht: schreibt mir bitte eine E-Mail." +
                "\n\n*- Die minimalen Ungenauigkeiten sind immer zu eurem 'Besten'. Es kann also sein, dass ihr eine Minute länger bleibt als nötig, damit die angegebene Zielzeit sicher erreicht wird. Es ist jedoch niemals so, dass euch die App in den Feierabend schickt, ihr aber den gewünschten Faktor verfehlt. Allerdings bleibt auch das ohne Gewähr." +
                "\n\n- EasterEggs: bis jetzt sind in der Anwendung 4 EasterEggs versteckt, manche schwerer und manche einfacher zu finden. Finde sie alle :)!" +                
                "";

            //EasterEggs: 
            //1. im Modus 'faktor' im faktor feld '1,61' eingeben
            //2. neustart durch doppelklick auf modus-anzeige unten rechts im hauptfenster, EE als tooltipp
            //3. Wintermodus rein, speichern und die hintergrundfarbe in der xml datei ändern, damit es auch winter gibt in anderen farben
            //4. im Anleitungsfenster, egal welcher Tab, auf F3 drücken
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
            {
                Close();
            }
            if (e.Key == Key.A)
            {
                tabControl.SelectedItem = tabItem1;
            }

            if (e.Key == Key.U)
            {
                tabControl.SelectedItem = tabItem3;
                SV4.Focus();
            }
            if (e.Key == Key.C)
            {
                tabControl.SelectedItem = tabItem5;
                TCList.Focus();
            }
            if (e.Key == Key.I)
            {
                tabControl.SelectedItem = tabItem4;
            }
            if (e.Key == Key.S && tabItem1.IsSelected)
            {
                button1_Click(this, e);
            }
            if (e.Key == Key.H)
            {
                Anleitung An = new Anleitung();
                An.ShowDialog();
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }


        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!MainFrame.IsSnowing())
            {
                MainFrame.StartSnow();
                comboBox.SelectedItem = LightCoralB;
                label2_Copy.IsEnabled = false;
                comboBox.IsEnabled = false;
            }
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (MainFrame.IsSnowing())
            {
                MainFrame.StopSnow();
                comboBox.SelectedItem = WhiteB;
                label2_Copy.IsEnabled = true;
                comboBox.IsEnabled = true;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkBox.IsChecked == true)
                {
                    ((ComboBoxItem)comboBox.SelectedItem).Name = "LightCoralB";
                }
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                DefaultWerte sc = new DefaultWerte();
                sc.ZeitGuthaben = textBox.Text;
                sc.GekommenH = textBox_Copy.Text;
                sc.GekommenM = textBox_Copy1.Text;
                sc.Pause = textBox_Copy2.Text;
                sc.WillGehenH = textBox_Copy3.Text;
                sc.WillGehenM = textBox_Copy4.Text;
                sc.Wunschfaktor = textBox_Copy5.Text;
                sc.Winter = checkBox.IsChecked.ToString();
                sc.BackColor = ((ComboBoxItem)comboBox.SelectedItem).Name;
                sc.Modus = radioButton.IsChecked.ToString();
                sc.WunschAStunden = textBox_Copy6.Text;
                ls.Add(sc);
                xs.Serialize(fs, ls);
                fs.Close();
                if (checkBox.IsChecked == true)
                {
                    if (MessageBox.Show("Deine Defaultwerte wurden gespeichert.\n\nAchtung: Da du den Wintermodus aktiviert hast, wurde die Hintergrundfarbe automatisch auf Rot gesetzt. Wenn du eine andere Farbe willst, musst du das Winterspecial deaktivieren.\n\nBeim nächsten Neustart treten deine Änderungen in Kraft.\n\nMöchtest du den Zeitrechner jetzt neustarten?", "Speichern Erfolgreich", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    if (MessageBox.Show("Deine Defaultwerte wurden gespeichert.\n\nBeim nächsten Neustart treten deine Änderungen in Kraft.\n\nMöchtest du den Zeitrechner jetzt neustarten?", "Speichern Erfolgreich", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"\n\nREAD ME:\nStarte das Programm erneut, und probier es nochmal. Ausserdem gibt´s im Reiter 'Tipps & Tricks' einen Lösungsvorschlag. Wenn es dann immernoch nicht geht, schreib mir bitte eine Email (Info/Einstellungen > über uns > Email schreiben).", "Fehler");

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Bist du sicher, dass du die Einstellungen auf Standart zurücksetzen willst?", "Reset", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {

                //checkBox.IsChecked = true; //im januar anpassen
                checkBox.IsChecked = false;

                try
                {
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    DefaultWerte sc = new DefaultWerte();
                    sc.ZeitGuthaben = "0,00";
                    sc.GekommenH = "08";
                    sc.GekommenM = "00";
                    sc.Pause = "30";
                    sc.WillGehenH = "17";
                    sc.WillGehenM = "00";
                    sc.Wunschfaktor = "2,5";
                    sc.Modus = "False";
                    sc.WunschAStunden = "8";

                    sc.Winter = checkBox.IsChecked.ToString(); //im januar anpassen (bzw wird oben angepasst)
                                                               //sc.BackColor = "LightCoralB"; //im januar anpassen
                    sc.BackColor = "WhiteB"; //im januar anpassen

                    ls.Add(sc);
                    xs.Serialize(fs, ls);
                    fs.Close();
                    if (MessageBox.Show("Deine Defaultwerte wurden zurückgesetzt.\n\nBeim nächsten Neustart treten deine Änderungen in Kraft.\n\nMöchtest du den Zeitrechner neustarten?", "Reset Erfolgreich", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\nREAD ME:\nStarte das Programm erneut, und probier es nochmal. Ausserdem gibt´s im Reiter 'Tipps & Tricks' einen Lösungsvorschlag. Wenn es dann immernoch nicht geht, schreib mir bitte eine Email (Info/Einstellungen > über uns > Email schreiben).", "Fehler");
                }
            }
            else
            {

            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Anleitung An = new Anleitung();
            An.ShowDialog();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.M)
            {
                string mailto = string.Format("mailto:{0}?Subject={1}&Body={2}", "kirchner.oscar@googlemail.com", "(An-)Frage ZeitrechnerApp", "Hallo Oscar,");
                mailto = Uri.EscapeUriString(mailto);
                Process mailStart = Process.Start(mailto);
            }
            if (e.Key == Key.T)
            {
                tabControl.SelectedItem = tabItem2;
                SV3.Focus();
            }
        }

        private ObservableCollection<TastenControlls> CreateTCList()
        {
            ObservableCollection<TastenControlls> liste = new ObservableCollection<TastenControlls>();
            liste.Add(new TastenControlls("ESC", "Schließt das Fenster") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("N", " Programm Neustarten") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("A oder H", "Anleitungsfenster öffnen") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("E oder I", "Einstellungs- und Info-Fenster öffnen") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("M", "EMail an Oscar senden") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("Enter", "Ausrechnen") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("Z", "Ins Feld 'Zeitguthaben' wechseln") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("B", "Ins Feld 'Beginn heute' wechseln") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("P", "Ins Feld 'Pause' wechseln") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("G", "Ins Feld 'Wann magst du Heute gehen' wechseln") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("W", "Ins Feld 'Wunschfaktor' wechseln") { Fenster = FensterTyp.Hauptfenster });
            liste.Add(new TastenControlls("S", "Ins Feld 'Wie viele Stunden willst du Heute\narbeiten' wechseln") { Fenster = FensterTyp.Hauptfenster });

            liste.Add(new TastenControlls("ESC", "Schließt das Fenster") { Fenster = FensterTyp.Einstellungen });
            liste.Add(new TastenControlls("A", "Wechselt zum Tabreiter 'Allgemein'") { Fenster = FensterTyp.Einstellungen });
            liste.Add(new TastenControlls("T", "Wechselt zum Tabreiter 'Tipps & Tricks'") { Fenster = FensterTyp.Einstellungen });
            liste.Add(new TastenControlls("C", "Wechselt zum Tabreiter 'Tasten Controls'") { Fenster = FensterTyp.Einstellungen });
            liste.Add(new TastenControlls("U", "Wechselt zum Tabreiter 'Updates'") { Fenster = FensterTyp.Einstellungen });
            liste.Add(new TastenControlls("I", "Wechselt zum Tabreiter 'Über uns/Info'") { Fenster = FensterTyp.Einstellungen });
            liste.Add(new TastenControlls("M", "EMail an Oscar senden") { Fenster = FensterTyp.Einstellungen });
            liste.Add(new TastenControlls("S", "(Im Tabreiter Allgemein) Änderungen speichern") { Fenster = FensterTyp.Einstellungen });
            liste.Add(new TastenControlls("H", "Anleitungsfenster öffnen") { Fenster = FensterTyp.Einstellungen });

            liste.Add(new TastenControlls("ESC", "Schließt das Fenster") { Fenster = FensterTyp.Anleitung });
            liste.Add(new TastenControlls("U", "Wechselt zum Tabreiter 'Uhrzeit'") { Fenster = FensterTyp.Anleitung });
            liste.Add(new TastenControlls("F", "Wechselt zum Tabreiter 'Faktor'") { Fenster = FensterTyp.Anleitung });

            return liste;
        }
    }
}

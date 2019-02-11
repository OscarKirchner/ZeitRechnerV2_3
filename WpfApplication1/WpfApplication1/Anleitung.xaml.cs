using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für Anleitung.xaml
    /// </summary>
    public partial class Anleitung : Window
    {
        public Anleitung()
        {
            InitializeComponent();
            SV1.Focus();

            TBUhrzeit.Text = "Diesen Modus solltet ihr benutzen, wenn in eurer Zeiterfassung die Über-/MinusStunden " +
                "als Zeit, also als Stunden und Minuten, angegeben werden. Wenn ihr in eurem CRM/Zeiterfassungsportal der Firma eure Zeiten " +
                "eingetragen habt, werden irgendwo eure aktuellen Über-/Minusstunden (meist ohne den heutigen Tag) angezeigt. " +
                "Wenn diese als 'Stunden und Minuten' angegeben werden, dann ist dieser Modus das richtige für euch.\n\nUhrzeit bedeutet, " +
                "dass die Zeit, die ihr auf eurem Konto habt, zum Beispiel '1:20 h' oder '30 min', auch genauso angezeigt wird. Für " +
                "das Beispiel hier, würde bei euch die Zeit wie folgt in den Zeitrechner eingetragen werden müssen: '1,20' " +
                "beziehungsweise '0,3'. Diese Zeiten " +
                "können natürlich auch negativ sein.\n\nIn das erste Feld 'Zeitguthaben' tragt ihr also eure Zeit, also die " +
                "gesammelten über/-Minusstunden von euch, wie angegeben ein. Alle weiteren Eingaben sind selbsterklärend. Im letzen Feld " +
                "'Wunschfaktor' wird allerdings auch in diesem Modus auf den 'Faktor' zurückgegriffen. Wie dieser funktioniert, " +
                "lest ihr am besten im Tabreiter 'Modus: Faktor'.\n\nRechts " +
                "werden euch nun mehrere Werte angezeigt. Erstmal bekommst du nochmal angezeigt, wieviel Minuten, bzw. Stunden " +
                "und Minuten du aktuell hast - aber auch welchem Faktor das entspricht. Dann bekommst du angezeigt, wann du gehen kannst, ohne ins Minus zu rutschen, " +
                "bzw. auf '0' zu landen (falls du schon im Minus bist), inklusive der Anzahl an Stunden und Minuten, die du - ausgegangen von einem 8 h " +
                "Arbeitstag inkl. Pause - arbeiten müsstest um bei '0' zu landen. Weiter geht es mit der Uhrzeit, wann du gehen " +
                "kannst, ohne Stunden zu gewinnen oder zu verlieren - also deine aktuellen Über-/Minusstunden beizubehalten. Hier wird " +
                "einfach die Pausenzeit + 8 h auf deinen 'Beginn heute' aufgerechnet.\nIm zweiten Teil wird dir ersteinmal " +
                "ausgerechnet, was für einen Faktor bzw. wie viele Über-/Minusstunden du auf deinem Zeitkonto hättest, würdest " +
                "du um die von dir links angegebene Zeit nach Hause gehen. Unten bekommt ihr dann noch errechnet, wann ihr " +
                "gehen müsst, um den links angegebenen erwünschten Faktor zu erhalten. Wie oben schon erwähnt, muss hier auch " +
                "in diesem Modus der 'Faktor' angegeben werden (Bsp.: Faktor 1 = 60 min, Faktor 0,5 = 30 min, Faktor -1,75 = -1 h und 45 " +
                "min).\n\nEuch hier noch zu erklären, was ihr im Einstellungsmenu noch alles " +
                "entdecken könnt, würde nun aber den Rahmen dieser Anleitung sprengen und erklärt sich eigentlich auch von selbst. Nur " +
                "so viel: im Tabreiter 'Allgmein' könnt ihr euch selbst sog. 'DefaultWerte' festlegen, die beim starten des Programms automatisch in den " +
                "Feldern stehen, um euch ein schnelleres und bequemeres Ausrechnen zu ermöglichen. Bei weiteren Fragen, schreibt mir " +
                "bitte eine Email.";

            TBFaktor.Text = "Diesen Modus solltet ihr benutzen, wenn in eurer Zeiterfassung die Über-/MinusStunden " +
                "als Faktor angegeben werden. Wenn ihr in eurem CRM/Zeiterfassungsportal der Firma eure Zeiten " +
                "eingetragen habt, werden irgendwo eure aktuellen Über-/Minusstunden (meist ohne den heutigen Tag) angezeigt. " +
                "Wenn diese als 'Faktor' angegeben werden, dann ist dieser Modus das richtige für euch.\n\nFaktor bedeutet, " +
                "dass die Zeit, die ihr auf eurem Konto habt, zum Beispiel '1:20 h' oder '30 min' durch 60 geteilt wird. Für " +
                "das Beispiel hier, würde bei euch der Faktor '1,33' beziehungsweise '0,5' angezeigt werden. Dieser Faktor " +
                "kann natürlich auch negativ sein.\n\nIn das erste Feld 'Zeitguthaben' tragt ihr euren Faktor, also die " +
                "gesammelten über/-Minusstunden von euch, wie angegeben ein. Alle weiteren Eingaben sind selbsterklärend.\n\nRechts " +
                "werden dir nun mehrere Werte angezeigt. Erstmal bekommst du ausgerechnet, wieviel Minuten, bzw. Stunden " +
                "und Minuten du aktuell hast. Dann bekommst du angezeigt, wann du gehen kannst, ohne ins Minus zu rutschen, " +
                "bzw. auf '0' zu landen (falls du schon im Minus bist), inklusive der Anzahl an Stunden und Minuten, die du - ausgegangen von einem 8 h " +
                "Arbeitstag inkl. Pause - arbeiten müsstest um bei '0' zu landen. Weiter geht es mit der Uhrzeit, wann du gehen " +
                "kannst, ohne Stunden zu gewinnen oder zu verlieren - also deinen aktuellen Faktor beizubehalten. Hier wird " +
                "einfach die Pausenzeit + 8 h auf deinen 'Beginn heute' aufgerechnet.\nIm zweiten Teil wird dir ersteinmal " +
                "ausgerechnet, was für einen Faktor bzw. wie viele Über-/Minusstunden du auf deinem Zeitkonto hättest, würdest " +
                "du um die von dir links angegebene Zeit nach Hause gehen. Unten bekommt ihr dann noch errechnet, wann ihr " +
                "gehen müsst, um den links angegebenen erwünschten Faktor zu erhalten.\n\nEuch hier noch zu erklären, was ihr im Einstellungsmenu noch alles " +
                "entdecken könnt, würde nun aber den Rahmen dieser Anleitung sprengen und erklärt sich eigentlich auch von selbst. Nur " +
                "so viel: im Tabreiter 'Allgmein' könnt ihr euch selbst sog. 'DefaultWerte' festlegen, die beim starten des Programms automatisch in den " +
                "Feldern stehen, um euch ein schnelleres und bequemeres Ausrechnen zu ermöglichen. Bei weiteren Fragen, schreibt mir " +
                "bitte eine Email.";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
            if (e.Key == Key.U)
            {
                tabControl2.SelectedItem = tabItem21;
                SV1.Focus();
            }
            if (e.Key == Key.F)
            {
                tabControl2.SelectedItem = tabItem22;
                SV2.Focus();
            }
            if (e.Key == Key.F3)
            {
                MessageBox.Show("Glückwunsch!\nWieso auch immer du auf die Idee gekommen bist, hier in der Anleitung auf F3 zu drücken, zu hast " +
                    "damit ein Osterei gefunden. Als Belohnung kommen hier 4 Bands & Lieder, die du dir mal angehört haben solltest:" +
                    "\n- Mülheim asozial - Yuppieschweine\n- Waving The Guns - Zapfhahn\n- Alles.Scheisze - Aussteigerprogramm\n- Feine Sahne Fischfilet - Wut\n\nViel Spaß!", "EasterEgg");
            } 
        }
    }
}

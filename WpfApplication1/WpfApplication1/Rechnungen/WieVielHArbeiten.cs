using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1.Rechnungen
{
    class WieVielHArbeiten
    {

        public string WieVielHArbeitenR(double BeginnH, double BeginnM, double Pause, double WunschStunden, double DeinZeitGH, int Modus)
        {
            if (Modus == 0)
            {
                double DeinZFHH = Math.Floor(DeinZeitGH);
                double DeinZGHM = (DeinZeitGH - DeinZFHH)+ 0.00000001;



                DeinZeitGH = DeinZFHH + (DeinZGHM*0.6);
            }

            double Erg = 0;
            double ErgHH = 0;
            double ErgHM = 0;
            double WunschHM = 0;
            double WunschHH = 0;
            string fooNull = "";
            string fooNull1 = "";
            string fooNull2 = "";
            string fooNull3 = "";

            WunschHH = Math.Floor(WunschStunden);
            WunschHM = Math.Floor(((WunschStunden-WunschHH)*100)+0.00000001);
            double test = WunschStunden - WunschHH+0.000000001;
            if (test < 0.1)
            {
                fooNull3 = "0";
            }
            else if (WunschHM <= 9)
            {
                fooNull2 = "0";
            }

            BeginnH = BeginnH + WunschHH;
            BeginnM = BeginnM + WunschHM +Pause;
            while(BeginnH >= 24)
            {
                BeginnH = BeginnH - 24;
            }

            while(BeginnM > 59)
            {
                BeginnM = BeginnM - 60;
                BeginnH = BeginnH + 1;
            }

            if (BeginnM < 10)
            {
                fooNull = "0";
            }

            if (DeinZeitGH >=0)
            {

                Erg = DeinZeitGH + WunschStunden;
                ErgHH = Math.Floor(Erg);
                ErgHM = ((Erg - ErgHH) * 100)+0.00000001;
                ErgHM = Math.Floor(ErgHM);
                while (ErgHM > 59)
                {
                    ErgHM = ErgHM - 60;
                    ErgHH = ErgHH + 1;
                }
                if (ErgHM < 10)
                {
                    fooNull1 = "0";
                }
                ErgHH = ErgHH - 8;
                Erg = ErgHH + (ErgHM / 60);
            }
            else
            {
                return "\n\nWenn du Heute " + WunschHH + ","+fooNull3+ WunschHM +fooNull2+ " [h,min] arbeiten willst und\n"+Pause+" min Pause machst musst du bis " + BeginnH + " : " + fooNull + BeginnM + " bleiben.\nDie Berechnung des neuen Zeitguthabens (bis jetzt)\nnur bei positivem aktuellen Zeitguthaben möglich.";
            }

            return "\n\nWenn du Heute " + WunschHH + "," + fooNull3 + WunschHM + fooNull2 + " [h,min] arbeiten willst und\n" + Pause + " min Pause machst, musst du bis " + BeginnH+" : "+ fooNull+BeginnM +" bleiben.\nDann hast du "+ ErgHH + " : "+ fooNull1 + ErgHM+" [h : min] Überstunden,\nbzw. den Faktor "+ Erg;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Rechnungen
{
    class TastenControlls
    {
        public TastenControlls(string v1, string v2)
        {
            this.Taste = v1;
            this.Funktion = v2;
        }
        public string Taste { get; set; }
        public string Funktion { get; set; }
        //   public string Fenster { get; set; }
        public FensterTyp Fenster { get; set; }
    }

    public enum FensterTyp { Hauptfenster, Einstellungen, Anleitung }
}


using munkaido_nyilvantartas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cucc
{
    class Statisthick
    {
        public Munkavallalo Nev;

        public double Munkaora;
        public int Ossz_fizu;
        public int Eloleg;
        public int Fizetendo;
        public DateTime Datum;

        public Statisthick(Munkaido alkmozat)
        {
            Nev = alkmozat.Alkalmazott;
            Munkaora = alkmozat.LedolgozottIdo;
            Ossz_fizu = Convert.ToInt32(alkmozat.Alkalmazott.Oraber * alkmozat.LedolgozottIdo);
            Eloleg = 0;
            Fizetendo = Ossz_fizu - Eloleg;
            Datum = alkmozat.Date;
        }
    }
}

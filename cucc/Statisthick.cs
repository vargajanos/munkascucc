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
        public double Munkaido;
        public int Ossz_fizu;
        public int Eloleg;
        public int Fizetendo;

        public Statisthick(Munkavallalo nev, double ora, int eloleg)
        {
            Nev = nev;
            Munkaido = ora;
            Ossz_fizu = Convert.ToInt32(nev.Oraber * ora);
            Eloleg = eloleg;
            Fizetendo = Ossz_fizu - Eloleg;
        }
    }
}

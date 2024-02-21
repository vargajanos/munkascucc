using munkaido_nyilvantartas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cucc
{
    class Eloleg
    {
        public Munkavallalo Alkalmazott;
        public DateTime Datum;
        public int Osszeg;

        public Eloleg(Munkavallalo alkalmazott, DateTime datum, int osszeg)
        {
            Alkalmazott = alkalmazott;
            Datum = datum;
            Osszeg = osszeg;


        }

    


    }
}

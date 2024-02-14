using System;

namespace munkaido_nyilvantartas
{
    class Munkaido
    {
        public Munkavallalo Alkalmazott;
        public DateTime Date;
        public Ido Start;
        public Ido End;

        public Munkaido(Munkavallalo munkavallalo, DateTime date, Ido start, Ido end)
        {
            Alkalmazott = munkavallalo;
            Date = date;
            Start = start;
            End = end;
        }
    }
}
    
using System;

namespace munkaido_nyilvantartas
{
    class Munkaido
    {
        public Munkavallalo Alkalmazott;
        public DateTime Date;
        public string Start;
        public string End;

        public Munkaido(Munkavallalo munkavallalo, DateTime date, string start, string end)
        {
            Alkalmazott = munkavallalo;
            Date = date;
            Start = start;
            End = end;
        }
    }
}
    
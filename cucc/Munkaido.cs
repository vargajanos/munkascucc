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

            /*double ido = (((Convert.ToInt32(start.Split(':')[0]) - Convert.ToInt32(end.Split(':')[0])) * 60)
                    + (Convert.ToInt32(start.Split(':')[1]) - Convert.ToInt32(end.Split(':')[1]))) /60;
            WorkTime = Math.Round(ido);*/
        }
    }
}
    
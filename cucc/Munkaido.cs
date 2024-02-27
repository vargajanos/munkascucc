using System;

namespace munkaido_nyilvantartas
{
    class Munkaido
    {
        public Munkavallalo Alkalmazott;
        public DateTime Date;
        public string Start;
        public string End;
        public double LedolgozottIdo;

        public Munkaido(Munkavallalo munkavallalo, DateTime date, string start, string end)
        {
            Alkalmazott = munkavallalo;
            Date = date;
            Start = start;
            End = end;

            LedolgozottIdo = LedolgozottIdoSzamolas(start, end);

        }

        public double LedolgozottIdoSzamolas(string start, string end)
        {
            string[] kezdoido = start.Split(':');
            string[] vegeido = end.Split(':');

            int start_ora = Convert.ToInt32(kezdoido[0]);
            int end_ora = Convert.ToInt32(vegeido[0]);
            int start_perc = Convert.ToInt32(kezdoido[1]);
            int end_perc = Convert.ToInt32(vegeido[1]);

            double ido = ((end_ora - start_ora) * 60 + (end_perc - start_perc)) / 60;

            return Math.Round(ido);


        }
    }
}
    
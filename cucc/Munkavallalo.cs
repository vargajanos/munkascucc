using System;

namespace munkaido_nyilvantartas
{
    class Munkavallalo
    {
        public string Nev;
        public string Lakcim;
        public string Beosztas;
        public int Oraber;
        public string Email;
        public string Telefonszam;


        public Munkavallalo(string sor)
        {
            string[] seged = sor.Split(';');

            Nev = seged[0];
            Lakcim = seged[1];
            Beosztas = seged[2];
            Oraber = Convert.ToInt32(seged[3]);
            Email = seged[4];
            Telefonszam = seged[5];
        }

    }
}

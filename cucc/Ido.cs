using System;

namespace munkaido_nyilvantartas
{
    class Ido
    {
        public byte Ora;
        public byte Perc;

        public Ido(string ido)
        {
            Ora = Convert.ToByte(ido.Split(':')[0]);
            Perc = Convert.ToByte(ido.Split(':')[1]);
        }
    }
}

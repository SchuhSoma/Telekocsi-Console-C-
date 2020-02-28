using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telekocsi2
{
    class Igenyek
    {
        //Azonosító;Indulás;Cél;Személyek
        public string Azonosito;
        public string Indulas;
        public string Cel;
        public int Szemelyek;
        public string IndulCel;

        public Igenyek (string sor)
        {
            var dbok = sor.Split(';');
            this.Azonosito = dbok[0];
            this.Indulas = dbok[1];
            this.Cel = dbok[2];
            this.Szemelyek = int.Parse(dbok[3]);
            this.IndulCel = dbok[1] + "-" + dbok[2];

        }

    }
}

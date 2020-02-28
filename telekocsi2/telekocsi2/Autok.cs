using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telekocsi2
{
    class Autok
    {//Indulás;Cél;Rendszám;Telefonszám;Féröhely
        public string Inulas;
        public string Cel;
        public string Rendszam;
        public string Telefonszam;
        public int Ferohely;
        public string IndulCel;

        public Autok (string sor)
        {
            var dbok = sor.Split(';');
            this.Inulas = dbok[0];
            this.Cel = dbok[1];
            this.Rendszam = dbok[2];
            this.Telefonszam = dbok[3];
            this.Ferohely = int.Parse(dbok[4]);
            this.IndulCel= dbok[0]+"-"+ dbok[1];


        }

    }
}

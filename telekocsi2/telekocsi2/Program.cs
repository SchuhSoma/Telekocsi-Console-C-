using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace telekocsi2
{
    class Program
    {
        static List<Autok> AutokList;
        static List<Igenyek> IgenyekList;
        static List<string> Hirdetesek;
        static Dictionary<string, int> Ferohely;
        static void Main(string[] args)
        {
            Feladat1Beolvasas();
            Feladat2HirdetesekSzama();
            Feladat3BUdapestMiskolc();
            Feladat4LegtobbFerohely();
            Feladat5Talalat();
            Feladat6TalalatPar();

            Console.ReadKey();
        }

        private static void Feladat6TalalatPar()
        {
            Console.WriteLine("\n6.Feladat: találatok igényekre");
            var sw = new StreamWriter(@"talalat.txt",false, Encoding.UTF8);
            int db = 0;
            foreach (var a in AutokList)
            {
                foreach (var i in IgenyekList)
                {
                    if (i.IndulCel == a.IndulCel && i.Szemelyek <= a.Ferohely)
                    {
                        db++;
                        Console.WriteLine("\t{0}\t{1,-6} Rendszám: {2,-9}, Telefonszám: {3}", db, i.Azonosito,a.Rendszam,a.Telefonszam);
                        sw.WriteLine("\t{0}\t{1,-6} Rendszám: {2,-9}, Telefonszám: {3}", db, i.Azonosito, a.Rendszam, a.Telefonszam);
                    }
                }
            }
            sw.Close();
            
        }

        private static void Feladat5Talalat()
        {
            Console.WriteLine("\n5.Feladat: Találatok");
            foreach (var a in AutokList)
            {
                foreach (var i in IgenyekList)
                {
                    if(i.Indulas==a.Inulas && i.Cel==a.Cel )
                    {
                        Console.WriteLine("\t{0,-6} => {1}",i.Azonosito,a.Rendszam);
                    }
                }
            }
            Console.WriteLine("???????????????????????????????????");
            int db = 0;
            foreach (var a in AutokList)
            {
                foreach (var i in IgenyekList)
                {
                    if (i.IndulCel == a.IndulCel)
                    {
                        db++;
                        Console.WriteLine("\t{0}\t{1,-6} => {2}",db, i.Azonosito, a.Rendszam);
                    }
                }
            }
        }

        private static void Feladat4LegtobbFerohely()
        {
            Console.WriteLine("\n4.Feladat: Legtöbb férőhely");
           /* Ferohely =new  Dictionary<string, int>();
            int fero = 0;
            foreach (var a in AutokList)
            {
                foreach (var b in AutokList)
                {
                    if(a.IndulCel==b.IndulCel)
                    {
                        fero ++;
                    }
                   
                }
                Ferohely.Add(a.IndulCel, fero);
            }
           
            foreach (var d in Ferohely)
            {
                Console.WriteLine(d);
            }*/
            int MaxFerohely = int.MinValue;
            string Max = "cica";
            foreach (var a in AutokList)
            {
                if(a.Ferohely>MaxFerohely)
                {
                    MaxFerohely = a.Ferohely;
                    Max = a.IndulCel;
                }

            }
            Console.WriteLine("\tA legtöbb férőhely: {0} útitrány: {1}",MaxFerohely,Max);
        }

        private static void Feladat3BUdapestMiskolc()
        {
            Console.WriteLine("\n3.Feladat: Budapest Miskolc");
            int hely = 0;
            foreach (var a in AutokList)
            {
                if(a.IndulCel=="Budapest-Miskolc")
                {
                    hely += a.Ferohely;
                }
            }
            Console.WriteLine("\tEnnyi férőhely van Budapest-Miskolc vonalon: {0}",hely);
        }

        private static void Feladat2HirdetesekSzama()
        {
            Console.WriteLine("\n2.Feladat: Hirdetesek száma");
            Hirdetesek = new List<string>();
            foreach (var a in AutokList)
            {
                if(!Hirdetesek.Contains(a.Rendszam))
                {
                    Hirdetesek.Add(a.Rendszam);
                }
            }
            Console.WriteLine("\t{0} hírdetés van a listában", Hirdetesek.Count);
            Console.WriteLine("\t{0} hírdetés van a listában", AutokList.Count);
        }

        private static void Feladat1Beolvasas()
        {
            Console.WriteLine("1.Feladat: Beolvasás");
            AutokList = new List<Autok>();
            var sr = new StreamReader(@"autok.csv", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                AutokList.Add(new Autok(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás");
            }
            
            IgenyekList = new List<Igenyek>();
            var sr1 = new StreamReader(@"igenyek.csv", Encoding.UTF8);
            int db2 = 0;
            while (!sr1.EndOfStream)
            {
                IgenyekList.Add(new Igenyek(sr1.ReadLine()));
                db2++;
            }
            sr1.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás");
            }
        }
    }
}

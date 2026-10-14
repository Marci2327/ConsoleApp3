using System;

namespace Videojatekok
{
    internal class Jatek
    {
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public string Platform { get; set; }
        public int Ev { get; set; }
        public double Ertekeles { get; set; }

        public Jatek(string nev, string tipus, string platform, int ev, double ertekeles)
        {
            Nev = nev;
            Tipus = tipus;
            Platform = platform;
            Ev = ev;
            Ertekeles = ertekeles;
        }
    }
}

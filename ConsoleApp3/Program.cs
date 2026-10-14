using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Videojatekok
{
    internal class Program
    {
        static List<Jatek> jatekok = new List<Jatek>();

        static void Main(string[] args)
        {
            AdatBeolvas();

            // 1. feladat
            Console.WriteLine("1. feladat");
            jatekok
                .Where(x => x.Ertekeles >= 9)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} - {x.Ertekeles}"));

            Console.WriteLine();
            Console.WriteLine();

            // 2. feladat
            Console.WriteLine("2. feladat");
            jatekok
                .Where(x => x.Platform == "Nintendo Switch" &&
                            x.Ev > 2015 &&
                            x.Ertekeles >= 8)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} - {x.Ev} - {x.Ertekeles}"));

            Console.WriteLine();
            Console.WriteLine();

            // 3. feladat
            Console.WriteLine("3. feladat");
            jatekok
                .OrderByDescending(x => x.Ev)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} - {x.Ev}"));
            Console.WriteLine();
            Console.WriteLine();


            // 4. feladat
            Console.WriteLine("4. feladat");
            jatekok
                .OrderByDescending(x => x.Ertekeles)
                .Take(10)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} - {x.Ertekeles}"));

            Console.WriteLine();
            Console.WriteLine();

            // 5. feladat
            Console.WriteLine("5. feladat");
            jatekok
                .GroupBy(x => x.Platform)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key}: {x.Count()} db"));

            Console.WriteLine();
            Console.WriteLine();

            // 6. feladat
            Console.WriteLine("6. feladat");
            jatekok
                .GroupBy(x => x.Tipus)
                .OrderByDescending(x => x.Count())
                .Take(1)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key}: {x.Count()} db"));

            Console.WriteLine();
            Console.WriteLine();

            // 7. feladat
            Console.WriteLine("7. feladat");
            Console.WriteLine($"Átlagos értékelés: {jatekok.Average(x => x.Ertekeles):F2}");

            Console.WriteLine();
            Console.WriteLine();

            // 8. feladat
            Console.WriteLine("8. feladat");
            jatekok
                .GroupBy(x => x.Platform)
                .Select(x => new
                {
                    Platform = x.Key,
                    Atlag = x.Average(y => y.Ertekeles)
                })
                .OrderByDescending(x => x.Atlag)
                .Take(1)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Platform} - {x.Atlag:F2}"));
            Console.WriteLine();
            Console.WriteLine();

           //9. feladat
            Console.WriteLine("9. feladat");
            jatekok
                .OrderByDescending(x => x.Ertekeles)
                .Take(1)
                .ToList()
                .ForEach(x => Console.WriteLine($"Legmagasabb: {x.Nev} - {x.Ertekeles}"));

            jatekok
                .OrderBy(x => x.Ertekeles)
                .Take(1)
                .ToList()
                .ForEach(x => Console.WriteLine($"Legalacsonyabb: {x.Nev} - {x.Ertekeles}"));

            Console.WriteLine();
            Console.WriteLine();

            // 10. feladat
            Console.WriteLine("10. feladat");
            jatekok
                .Select(x => x.Tipus)
                .Distinct()
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
            Console.WriteLine();

            // 11. feladat
            Console.WriteLine("11. feladat");
            jatekok
                .Select(x => new { x.Nev, x.Ev })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} - {x.Ev}"));

            Console.WriteLine();
            Console.WriteLine();

            // 12. feladat
            Console.WriteLine("12. feladat");
            jatekok
                .Where(x => x.Tipus == "Action")
                .OrderByDescending(x => x.Ertekeles)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} - {x.Ev} - {x.Ertekeles}"));

            Console.WriteLine();
            Console.WriteLine();

            // 13. feladat
            Console.WriteLine("13. feladat");
            jatekok
                .GroupBy(x => x.Tipus)
                .Select(x => new
                {
                    Tipus = x.Key,
                    Atlag = x.Average(y => y.Ertekeles)
                })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Tipus} - {x.Atlag:F2}"));

            Console.WriteLine();
            Console.WriteLine();

            // 14. feladat
            Console.WriteLine("14. feladat");
            var regiJatekok =
                from x in jatekok
                where x.Ev < 2005
                select new { x.Nev, x.Platform };



            Console.WriteLine();
            Console.WriteLine();

            // 15. feladat
            Console.WriteLine("15. feladat");
            jatekok
                .GroupBy(x => x.Platform)
                .Select(x => x.OrderByDescending(y => y.Ertekeles).FirstOrDefault())
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} - {x.Ertekeles}"));
                

            Console.ReadKey();
        }

        private static void AdatBeolvas()
        {
            try
            {
                jatekok = File.ReadAllLines("Márton Szántó - games_dataset.csv")
                    .Skip(1)
                    .Select(sor => sor.Split(';'))
                    .Select(adat => new Jatek(
                        adat[0],
                        adat[1],
                        adat[2],
                        int.Parse(adat[3]),
                        double.Parse(adat[4])
                    ))
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba! {e.Message}");
            }
        }
    }
}
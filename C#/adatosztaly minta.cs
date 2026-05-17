    internal class HajoAdat
    {
        public HajoAdat(string hajoNev, string tipus, int gyartasEv, bool uzemel, string tulajdonos, string varos)
        {
            HajoNev = hajoNev;
            Tipus = tipus;
            GyartasEv = gyartasEv;
            Uzemel = uzemel;
            Tulajdonos = tulajdonos;
            Varos = varos;
        }

        public bool Kiemelt()
        {
            return GyartasEv < 1990 && Uzemel;
        }

        public string HajoNev {  get; set; }
        public string Tipus {  get; set; }
        public int GyartasEv {  get; set; }
        public bool Uzemel {  get; set; }
        public string Tulajdonos {  get; set; }
        public string Varos {  get; set; }
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladat f = new();
            f.Feladat2();
            f.Feladat3();
            f.Feladat4();
            f.Feladat5();
        }
    }
}
namespace Hajo
{
    internal class Feladat
    {
        List<HajoAdat> adatok = [];

        public Feladat()
        {
            foreach (var item in File.ReadAllLines("hajolista.csv").Skip(1))
            {
                string[] resz = item.Split(';');
                string hajonev = resz[0];
                string tipus = resz[1];
                int gyartasEv = Convert.ToInt32(resz[2]);
                bool uzemel = resz[3] == "1";
                string tulajdonos = resz[4];
                string varos = resz[5];
                HajoAdat uj = new(hajonev, tipus, gyartasEv, uzemel, tulajdonos, varos);
                adatok.Add(uj);
            }
        }

        public void Feladat4()
        {
            Console.WriteLine($"4. feladat: Hajók száma: {adatok.Count}");
        }

        public void Feladat5()
        {
            var eredmeny = adatok.Where(x => x.Varos != "Siófok");
            Console.WriteLine("5. feladat: Siófokon kívüli hajók:");
            foreach (var item in eredmeny)
            {
                Console.WriteLine(item.HajoNev);
            }
        }

        public void Feladat7()
        {
            Console.Write("7. feladat: Kérem a város nevét: ");
            string varos = Console.ReadLine();
            if (adatok.Any(x=>x.Varos==varos)) // if (adatok.Count(x=>x.Varos)!=0)
            {
                double atlagosEv = adatok.
                    Where(x => x.Varos == varos).
                    Average(x => x.GyartasEv);
                Console.WriteLine($"A hajók átlagos gyártási éve: {atlagosEv:N0}");
            }
            else
            {
                Console.WriteLine("Nem található hajó a megadott városban");
            }
        }

        //8. feladat: Jelenjenek meg Balatonfüred város hajói a gyártási év szerinti csökkenő sorrendben, azon belül pedig névsorrendben! Jelenjen meg a hajó neve és a gyártási év!

        public void Feladat8()
        {
            var eredmeny = adatok.
                Where(x => x.Varos == "Balatonfüred").
                OrderByDescending(x => x.GyartasEv).
                ThenBy(x => x.HajoNev);
            Console.WriteLine("8. feladat: Balatonfüred hajói:");
            foreach (var item in eredmeny)
            {
                Console.WriteLine($"{item.HajoNev} - {item.GyartasEv}");
            }
        }

        //9. feladat: Jelenjen meg, hogy melyik az az év, amelyben az utolsó hajót vagy hajókat gyártották, és utána jelenjenek meg azoknak a hajóknak a neve névsorrendben, amelyeket ebben az évben gyártottak!

        public void Feladat9()
        {
            int maxEv = adatok.Max(x => x.GyartasEv);
            Console.WriteLine($"9. feladat: Utolsó gyártási év: {maxEv}");
            var eredmeny = adatok.Where(x => x.GyartasEv == maxEv).OrderBy(x => x.HajoNev);
            foreach (var item in eredmeny)
            {
                Console.WriteLine(item.HajoNev);
            }
        }

        //Jelenjen meg az összes hajótípus és az, hogy mennyi hajó tartozik ehhez a típushoz!

        public void Feladat10()
        {
            Console.WriteLine("10. feladat: Hajótípusok:");
            foreach (var item in adatok.GroupBy(x=>x.Tipus))
            {
                Console.WriteLine($"{item.Key} - {item.Count()} darab");
            }
        }

        //Készíts állományt kiemelt.csv néven, amelybe kerüljenek bele a kiemelt támogatású hajók neve, gyártási éve, tulajdonosa és városa ;-vel elválasztva! Az első sorban legyenek megjelenítve a mezőnevek!

        public void Feladat11()
        {
            StreamWriter sw = new("kiemelt.csv");
            sw.WriteLine("hajó neve;gyártás_éve;tulajdonos;város");
            var eredmeny = adatok.Where(x => x.Kiemelt());
            foreach (var item in eredmeny)
            {
                sw.WriteLine(string.Join(';',item.HajoNev,item.GyartasEv,item.Tulajdonos,item.Varos));
            }
            sw.Close();
        }

public void feladat7()
{
    Console.Write("7. feladat: Kérem a foglalat nevét: ");
    string keresettFoglalat = Console.ReadLine();

    var talalatok = termekek.Where(t => t.Foglalat == keresettFoglalat);

    if (talalatok.Any())
    {
        double atlag = talalatok.Average(t => t.Teljesitmeny);
        Console.WriteLine($"A lámpák átlagos teljesítménye: {atlag}");
    }
    else
    {
        Console.WriteLine("Nem található ilyen foglalatú lámpa.");
    }
}
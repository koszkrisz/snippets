class Konyv
{
    public string Cim { get; set; }
    public string Nev { get; set; }
    public string Nemzetiseg { get; set; }
    public int SzulEv { get; set; }
    public int HalEv { get; set; }
    public int Helyezes { get; set; }

internal class Feladat
{
    private List<Konyv> adatok = [];

    public Feladat()
    {
        foreach (var item in File.ReadAllLines("kiadas.txt"))
        {
            string[] resz = item.Split(";");
            int ev = Convert.ToInt32(resz[0]);
            int negyedEv = Convert.ToInt32(resz[1]);
            bool kulfoldi = resz[2] == "kf";
            string leiras = resz[3];
            int peldany = Convert.ToInt32(resz[4]);
            adatok.Add(new(ev,negyedEv,kulfoldi,leiras,peldany));
        }
    }

    public void Feladat2()
    {
        Console.WriteLine("2. feladat:");
        Console.Write("Szerző: ");
        string szerzo = Console.ReadLine();
        int kiadasok = adatok.Count(x => x.Leiras.Contains(szerzo));
        if (kiadasok == 0)
            Console.WriteLine("Nem adtak ki.");
        else
            Console.WriteLine($"{kiadasok} könyvkiadás.");
    }

    public void Feladat3()
    {
        int maxKiadas = adatok.Max(x => x.Peldany);
        int maxKiadasokSzama = adatok.Count(x => x.Peldany == maxKiadas);
        Console.WriteLine("3. feladat:");
        Console.WriteLine($"Legnagyobb példányszám: {maxKiadas}, előfordult {maxKiadasokSzama} alkalommal");

    }

    public void Feladat4()
    {
        var elso = adatok.Where(x => x.Kulfoldi && x.Peldany >= 40000).First();
        Console.WriteLine("4. feladat:");
        Console.WriteLine($"{elso.Ev}/{elso.NegyedEv}. {elso.Leiras}");
    }

    public void Feladat5()
    {
        string html = "";
        Console.WriteLine("Év\tMagyar kiadás\tMagyar példány\tKülföldi kiadás\tKülföldi példányszám");
        html += """
                  <table>
                    <tr>
                        <th>Év</th>
                        <th>Magyar kiadások</th>
                        <th>Magyar példány</th>
                        <th>Külföldi kiadás</th>
                        <th>Külföldi példányszám</th>
                    </tr>
                  """;
        foreach (var item in adatok.GroupBy(x=>x.Ev))
        {
            int magyarKiadas = item.Where(x => !x.Kulfoldi).Count();
            int magyarPeldany = item.Where(x => !x.Kulfoldi).Sum(x=>x.Peldany);
            int kulfoldiKiadas = item.Where(x => x.Kulfoldi).Count();
            int kulfoldiPeldany = item.Where(x => x.Kulfoldi).Sum(x => x.Peldany);
            Console.WriteLine($"{item.Key}\t\t{magyarKiadas}\t\t{magyarPeldany}\t\t{kulfoldiKiadas}\t\t{kulfoldiPeldany}");
            html += $"""
                  <tr>
                    <td>{item.Key}</td>
                    <td>{magyarKiadas}</td>
                    <td>{magyarPeldany}</td>
                    <td>{kulfoldiKiadas}</td>
                    <td>{kulfoldiPeldany}</td>
                  </tr>
                  """;
        }
        html += "</table>";
        StreamWriter sw = new("tabla.html");
        sw.WriteLine(html);
        sw.Close();
    }


    namespace konyvek
{
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

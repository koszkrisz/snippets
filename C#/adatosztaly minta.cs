
namespace Vilagitas
{
    internal class Termek
    {
        List<Termek> termekek = new List<Termek>();
        public Termek(string sor)
        {
            var adatok = sor.Split(';');
            TermekNev = adatok[0];
            Teljesitmeny = int.Parse(adatok[1]);
            Feszultseg = adatok[2];
            Foglalat = adatok[3];
            Elettartam = int.Parse(adatok[4]);
        }

        public string TermekNev { get; set; }
        public int Teljesitmeny { get; set; }
        public string Feszultseg { get; set; }
        public string Foglalat { get; set; }

        public int Elettartam { get; set; }
    }
}
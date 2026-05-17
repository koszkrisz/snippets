class Konyv
{
    public string Cim { get; set; }
    public string Nev { get; set; }
    public string Nemzetiseg { get; set; }
    public int SzulEv { get; set; }
    public int HalEv { get; set; }
    public int Helyezes { get; set; }

    public Konyv(string sor)
    {
        string[] adatok = sor.Split(';');

        Cim = adatok[0];
        Nev = adatok[1];
        Nemzetiseg = adatok[2];
        SzulEv = int.Parse(adatok[3]);
        HalEv = int.Parse(adatok[4]);
        Helyezes = int.Parse(adatok[5]);
    }

    public bool Kituntet()
    {
        return Nemzetiseg == "magyar" && Helyezes <= 50;
    }
}
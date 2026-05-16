// DataGrid feltöltése listából
// WPF DataGrid feltöltés minta
// ItemsSource használat

List<Versenyzo> versenyzok = new List<Versenyzo>();

versenyzok.Add(new Versenyzo()
{
    Nev = "Kiss Péter",
    Eredmeny = "10.25"
});

versenyzok.Add(new Versenyzo()
{
    Nev = "Nagy Anna",
    Eredmeny = "11.03"
});

// DataGrid neve: dgVersenyzok

dgVersenyzok.ItemsSource = versenyzok;
// LINQ Any példa

var vanSB = Versenyzok.Any(x => x.Csucs == "SB");

if (vanSB)
{
    Console.WriteLine("Van SB csúcs.");
}
else
{
    Console.WriteLine("Nincs SB csúcs.");
}
// File.ReadAllLines puskázó minta
// Szövegfájl összes sorának beolvasása listába/tömbbe

using System;
using System.IO;
using System.Text;

string fajlUtvonal = "adatok.txt";

// Minden sort beolvas a fájlból
string[] sorok = File.ReadAllLines(fajlUtvonal, Encoding.UTF8);

// Sorok kiírása
foreach (string sor in sorok)
{
    Console.WriteLine(sor);
}

// pontosvesszővel

// Példa: név;kor;város

foreach (string sor in sorok)
{
    string[] adatok = sor.Split(';');

    string nev = adatok[0];
    int kor = int.Parse(adatok[1]);
    string varos = adatok[2];

    Console.WriteLine($"{nev} - {kor} - {varos}");
}
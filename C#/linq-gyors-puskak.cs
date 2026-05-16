// LINQ gyors minták

// WHERE
// Kiválasztja a 18 évnél idősebbeket

var felnottek = emberek.Where(x => x.Kor >= 18);


// SELECT
// Kiválasztja csak a neveket

var nevek = emberek.Select(x => x.Nev);


// ANY
// Van-e olyan ember, aki 18 év alatti?

bool vanFiatal = emberek.Any(x => x.Kor < 18);


// COUNT
// Hány nő van?

int nokSzama = emberek.Count(x => x.Nem == "Nő");


// AVERAGE
// Átlag életkor

double atlag = emberek.Average(x => x.Kor);


// ORDER BY
// Rendezés név szerint

var rendezett = emberek.OrderBy(x => x.Nev);


// FIRST OR DEFAULT
// Első Anna nevű ember

var anna = emberek.FirstOrDefault(x => x.Nev == "Anna");
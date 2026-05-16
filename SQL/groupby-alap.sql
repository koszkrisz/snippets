-- GROUP BY alap minta
-- Nemzetenként hány versenyző van

SELECT nemzet, COUNT(*) AS darab
FROM versenyzok
GROUP BY nemzet;

-- Nemzetenként átlag helyezés

SELECT nemzet, AVG(helyezes) AS atlagHelyezes
FROM versenyzok
GROUP BY nemzet;


//Aggregáló függvények

COUNT()
AVG()
SUM()
MIN()
MAX()

-- Csak azok a nemzetek,
-- ahol több mint 3 versenyző van

SELECT nemzet, COUNT(*) AS darab
FROM versenyzok
GROUP BY nemzet
HAVING COUNT(*) > 3;


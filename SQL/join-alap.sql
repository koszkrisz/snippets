-- Alap INNER JOIN minta

SELECT versenyzok.nev, nemzetek.nemzet
FROM versenyzok
INNER JOIN nemzetek
ON versenyzok.nemzetid = nemzetek.id;
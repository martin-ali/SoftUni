UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries
    (Name, CountryCode)
VALUES('Hanga Abbey', (SELECT
            CountryCode
        FROM
            Countries
        WHERE CountryName = 'Tanzania'))

INSERT INTO Monasteries
    (Name, CountryCode)
VALUES('Myin-Tin-Daik', (SELECT
            CountryCode
        FROM
            Countries
        WHERE CountryName = 'Myanmar'))

SELECT
    cn.ContinentName,
    c.CountryName,
    COUNT(m.Id) AS MonasteriesCount
FROM
    Monasteries m
    RIGHT JOIN Countries c ON m.CountryCode = c.CountryCode
    RIGHT JOIN Continents cn ON c.ContinentCode = cn.ContinentCode
WHERE c.IsDeleted = 0
GROUP BY c.CountryName, cn.ContinentName
ORDER BY COUNT(m.Id) DESC,
            c.CountryName ASC
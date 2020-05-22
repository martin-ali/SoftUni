SELECT
    c.CountryName,
    cn.ContinentName,
    COUNT(r.Id),
    isnull(SUM(r.Length), 0)
FROM
    Countries c
    JOIN Continents cn ON c.ContinentCode = cn.ContinentCode
    LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
    LEFT JOIN Rivers r ON cr.RiverId = r.Id
GROUP BY c.CountryName, cn.ContinentName
ORDER BY COUNT(r.Id) DESC,
        SUM(r.Length) DESC,
        c.CountryName ASC

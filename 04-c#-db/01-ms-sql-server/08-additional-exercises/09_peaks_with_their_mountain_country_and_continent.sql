SELECT
    p.PeakName,
    m.MountainRange,
    c.CountryName,
    cn.ContinentName
FROM
    Peaks p
    JOIN Mountains m ON p.MountainId = m.Id
    JOIN MountainsCountries mc ON m.Id = mc.MountainId
    JOIN Countries c ON mc.CountryCode = c.CountryCode
    JOIN Continents cn ON c.ContinentCode = cn.ContinentCode
ORDER BY p.PeakName ASC, c.CountryName ASC
SELECT
    mc.[CountryCode],
    Count(*) AS [MountainRanges]
FROM
    [Mountains] m
    JOIN [MountainsCountries] mc
    ON m.[Id] = mc.[MountainId]
GROUP BY mc.[CountryCode]
HAVING mc.[CountryCode] IN ('BG', 'RU', 'US')
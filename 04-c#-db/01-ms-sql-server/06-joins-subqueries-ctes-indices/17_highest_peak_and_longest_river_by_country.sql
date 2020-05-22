SELECT
    TOP (5)
    c.[CountryName],
    Max(p.[Elevation]),
    Max(r.[Length])
FROM
    [Countries] c
    LEFT JOIN [MountainsCountries] mc
    ON c.[CountryCode] = mc.[CountryCode]
    LEFT JOIN [Mountains] m
    ON mc.[MountainId] = m.[Id]
    LEFT JOIN [Peaks] p
    ON m.[Id] = p.[MountainId]
    LEFT JOIN [CountriesRivers] cr
    ON c.[CountryCode] = cr.[CountryCode]
    LEFT JOIN [Rivers] r
    ON cr.[RiverId] = r.[Id]
GROUP BY c.[CountryName]
ORDER BY Max(p.[Elevation]) DESC,
            Max(r.[Length]) DESC,
            c.[CountryName]
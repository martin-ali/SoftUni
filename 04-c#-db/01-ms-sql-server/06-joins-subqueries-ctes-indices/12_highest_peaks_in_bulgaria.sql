SELECT
    c.[CountryCode],
    m.[MountainRange],
    p.[PeakName],
    p.[Elevation]
FROM
    [Peaks] p
    JOIN [Mountains] m
    ON p.[MountainId] = m.[Id]
    JOIN [MountainsCountries] mc
    ON m.[Id] = mc.[MountainId]
    JOIN [Countries] c
    ON mc.[CountryCode] = c.[CountryCode]
        AND c.[CountryName] = 'Bulgaria'
WHERE p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC
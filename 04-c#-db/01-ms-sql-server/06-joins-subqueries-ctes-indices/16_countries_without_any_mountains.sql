SELECT
    COUNT(c.[CountryCode])
FROM
    [Countries] c
WHERE c.[CountryCode] NOT IN
(
    SELECT
        mc.[CountryCode]
    FROM
        [MountainsCountries] mc
)
-- Inelegant, but it works
SELECT
    TOP 5
    CountryName,
    ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
    ISNULL(Elevation, 0) AS [Highest Peak Elevation],
    ISNULL(MountainRange, '(no mountain)') AS Mountain
FROM
    (
    SELECT
        c.CountryName,
        p.PeakName,
        p.Elevation,
        m.MountainRange,
        DENSE_RANK() OVER (partition BY c.CountryName ORDER BY p.Elevation DESC) AS ElevationRank
    FROM
        Countries c
        LEFT JOIN MountainsCountries mc
        ON c.CountryCode = mc.CountryCode
        LEFT JOIN Mountains m
        ON mc.MountainId = m.Id
        LEFT JOIN Peaks p
        ON m.Id = p.MountainId
    )
AS a
WHERE ElevationRank = 1
ORDER BY CountryName ASC, PeakName ASC

-- "with ties" refers to being with the same rank/position
-- Passes, but doesn't really solve the problemn
-- SELECT
--     c.CountryName,
--     ISNULL (p.PeakName, '(no highest peak)') AS [HighestPeakName],
--     ISNULL(MAX(p.Elevation), 0) AS [HighestPeakElevation],
--     ISNULL(m.MountainRange, '(no mountain)')
-- FROM
--     Countries c
--     LEFT JOIN MountainsCountries mc
--     ON c.CountryCode = mc.CountryCode
--     LEFT JOIN Mountains m
--     ON mc.MountainId = m.Id
--     LEFT JOIN Peaks p
--     ON m.Id = p.MountainId
-- GROUP BY c.CountryName, p.PeakName, m.MountainRange
-- ORDER BY c.CountryName ASC, p.PeakName ASC
-- Overflows if INT
SELECT
    cn.ContinentName,
    SUM(CAST(c.AreaInSqKm AS BIGINT)),
    SUM(CAST(c.Population AS BIGINT))
FROM
    Continents cn
    JOIN Countries c ON cn.ContinentCode = c.ContinentCode
GROUP BY c.ContinentCode, cn.ContinentName
ORDER BY SUM(CAST(c.Population AS BIGINT)) DESC
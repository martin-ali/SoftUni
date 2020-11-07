SELECT
    cu.ContinentCode,
    cu.CurrencyCode,
    cu.CurrencyUsage
FROM
    (
    SELECT
        continents.ContinentCode,
        currencies.CurrencyCode,
        DENSE_RANK() OVER (partition BY continents.ContinentCode ORDER BY COUNT(currencies.CurrencyCode) DESC) AS UsageRank,
        COUNT(currencies.CurrencyCode) AS CurrencyUsage
    FROM
        Currencies currencies
        JOIN Countries countries
        ON currencies.CurrencyCode = countries.CurrencyCode
        JOIN Continents continents
        ON countries.ContinentCode = continents.ContinentCode
    GROUP BY currencies.CurrencyCode, continents.ContinentCode
    HAVING COUNT(currencies.CurrencyCode) != 1
) AS cu
WHERE cu.UsageRank = 1
ORDER BY cu.ContinentCode ASC
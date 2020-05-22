SELECT
    cur.CurrencyCode AS CurrencyCode,
    cur.[Description] AS Currency,
    COUNT(c.CountryCode) AS NumberOfCountries
FROM
    Currencies cur
    LEFT JOIN Countries c ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode, cur.[Description]
ORDER BY COUNT(c.CountryCode) DESC,
        cur.[Description] ASC
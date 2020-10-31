SELECT
    f.Id,
    SUM(Price)
FROM
    Tickets t
    JOIN Flights f ON t.FlightId = f.Id
GROUP BY f.Id
ORDER BY SUM(Price) DESC,
            f.Id ASC
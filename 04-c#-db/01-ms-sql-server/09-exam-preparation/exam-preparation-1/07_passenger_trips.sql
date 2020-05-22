SELECT
    CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
    f.Origin,
    f.Destination
FROM
    Passengers p
    JOIN tickets t ON p.Id = t.PassengerId
    JOIN Flights f ON t.FlightId = f.Id
ORDER BY CONCAT(p.FirstName, ' ', p.LastName),
            f.Origin ASC,
            f.Destination ASC
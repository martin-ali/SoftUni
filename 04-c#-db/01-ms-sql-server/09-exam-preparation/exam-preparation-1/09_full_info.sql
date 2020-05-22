SELECT
    CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
    pl.Name,
    CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
    lt.Type
FROM
    Passengers p
    JOIN Tickets t ON p.Id = t.PassengerId
    JOIN Flights f ON  t.FlightId = f.Id
    JOIN Planes pl ON f.PlaneId = pl.Id
    JOIN Luggages l ON t.Luggageid = l.Id
    JOIN LuggageTypes lt ON l.LuggageTypeId = lt.Id
ORDER BY CONCAT(p.FirstName, ' ', p.LastName) ASC,
            pl.Name ASC,
            f.Origin ASC,
            f.Destination ASC,
            lt.Type ASC
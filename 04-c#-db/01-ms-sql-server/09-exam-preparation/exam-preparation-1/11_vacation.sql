CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
returns VARCHAR(50)
AS
BEGIN
    DECLARE @flightsCount INT = (
    SELECT
        COUNT(*)
    FROM
        Flights
    WHERE Origin = @origin AND Destination = @destination)

    IF (@peopleCount <= 0) RETURN 'Invalid people count!'
    ELSE IF (@flightsCount = 0) RETURN 'Invalid flight!'

    DECLARE @totalPrice DECIMAL(20, 2) = @peopleCount *
    (SELECT
        t.Price
    FROM
        Flights f
        JOIN Tickets t ON t.FlightId = f.Id
    WHERE f.Origin = @origin AND f.Destination = @destination)

    RETURN CONCAT('Total price ', @totalPrice)
END
SELECT
    FirstName,
    LastName,
    Age
FROM
    Passengers
WHERE Id NOT IN (
SELECT
    PassengerId
FROM
    Tickets)
ORDER BY Age DESC,
        FirstName ASC,
        LastName DESC
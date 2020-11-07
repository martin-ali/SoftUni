-- Better way?
CREATE PROCEDURE usp_GetTownsStartingWith(@start NVARCHAR(MAX))
AS
SELECT
    [Name]
FROM
    Towns
WHERE LEFT([Name], len(@start)) = @start
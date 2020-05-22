CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
returns INT
AS
BEGIN
    IF (@StartDate IS NULL OR @EndDate IS NULL) RETURN 0

    RETURN DATEDIFF(hh, @StartDate, @EndDate)
END
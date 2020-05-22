SELECT [Peaks].PeakName,
    [rivers].RiverName,
    LOWER([peaks].PeakName + SUBSTRING([rivers].RiverName, 2, LEN(rivers.RiverName)-1)) AS [Mix]
FROM [Peaks] peaks
    INNER JOIN [Rivers] rivers
    ON SUBSTRING(peaks.PeakName, len(peaks.PeakName), 1)
        = SUBSTRING(rivers.RiverName, 1, 1)
ORDER BY [Mix]
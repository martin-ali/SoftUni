SELECT
  [mountains].MountainRange,
  [Peaks].PeakName,
  [peaks].Elevation
FROM
  [Peaks] peaks
  JOIN [Mountains] mountains ON [peaks].MountainId = [mountains].Id
    AND [mountains].MountainRange = 'Rila'
ORDER BY
  [Elevation] DESC
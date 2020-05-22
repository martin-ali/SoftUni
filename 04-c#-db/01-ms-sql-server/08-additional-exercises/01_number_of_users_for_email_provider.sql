SELECT
    SUBSTRING (Email, CHARINDEX ('@', Email)+1, len (Email)-CHARINDEX ('@', Email)) AS [Email Provider],
    COUNT(*)
FROM
    Users
GROUP BY SUBSTRING (Email, CHARINDEX ('@', Email)+1, len (Email)-CHARINDEX ('@', Email))
ORDER BY COUNT(*) DESC, SUBSTRING (Email, CHARINDEX ('@', Email)+1, len(Email)-CHARINDEX ('@', Email))
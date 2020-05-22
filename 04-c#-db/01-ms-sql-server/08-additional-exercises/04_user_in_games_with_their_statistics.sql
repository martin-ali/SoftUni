-- Awful explanation. Spent 3 hours in excel trying to understand what I am supposed to do, then 15 minutes solving it.
-- Should have used a real user in the examples instead of the made-up "Ana", so we have something to go on
SELECT
    u.Username,
    g.Name,
    MAX(c.Name),
    SUM(s.Strength) + MAX(sc.Strength) + MAX(sb.Strength) AS Strength,
    SUM(s.Defence) + MAX(sc.Defence) + MAX(sb.Defence) AS Defence,
    SUM(s.Speed) + MAX(sc.Speed) + MAX(sb.Speed) AS Speed,
    SUM(s.Mind) + MAX(sc.Mind) + MAX(sb.Mind) AS Mind,
    SUM(s.Luck) + MAX(sc.Luck) + MAX(sb.Luck) AS Luck
FROM
    Users u
    JOIN UsersGames ug ON u.Id = ug.UserId
    JOIN Games g ON ug.GameId = g.Id
    JOIN GameTypes gt ON g.GameTypeId = gt.Id
    JOIN Characters c ON ug.CharacterId = c.Id
    JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
    JOIN Items i ON ugi.ItemId = i.Id
    JOIN [Statistics] s ON i.StatisticId = s.Id
    JOIN [Statistics] sc ON c.StatisticId = sc.Id
    JOIN [Statistics] sb ON gt.BonusStatsId = sb.Id
GROUP BY u.Username, g.Name
ORDER BY Strength DESC,
        Defence DESC,
        Speed DESC,
        Mind DESC,
        Luck DESC
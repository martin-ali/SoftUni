SELECT
    u.Username,
    g.Name,
    COUNT(i.Id) AS [Items Count],
    SUM(i.Price) AS [Items Price]
FROM
    Users u
    JOIN UsersGames ug ON u.Id = ug.UserId
    JOIN Games g ON ug.GameId = g.Id
    JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
    JOIN Items i ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY COUNT(i.Id) DESC,
        SUM(i.Price) DESC,
        u.Username ASC
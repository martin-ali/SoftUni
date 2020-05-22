-- 1 - Buy items
DECLARE @user INT =
(SELECT
    Id
FROM
    Users
WHERE Username = 'Alex')

DECLARE @game INT =
(SELECT
    Id
FROM
    Games
WHERE Name = 'Edinburgh')

DECLARE @totalPrice INT =
(SELECT
    SUM(PRICE)
FROM
    Items
WHERE Name IN (
    'Blackguard',
    'Bottomless Potion of Amplification',
    'Eye of Etlich (Diablo III)',
    'Gem of Efficacious Toxin',
    'Golden Gorget of Leoric',
    'Hellfire Amulet')
)

DECLARE @userGameId INT =
(SELECT
    Id
FROM
    UsersGames
WHERE UserId = @user AND GameId = @game)

UPDATE UsersGames
SET Cash -= @totalPrice
WHERE Id = @userGameId

INSERT INTO UserGameItems
    (UserGameId, ItemId)
SELECT
    @userGameId,
    Id
FROM
    Items
WHERE Name IN (
    'Blackguard',
    'Bottomless Potion of Amplification',
    'Eye of Etlich (Diablo III)',
    'Gem of Efficacious Toxin',
    'Golden Gorget of Leoric',
    'Hellfire Amulet'
)

-- -- -- 2 - Select users
SELECT
    u.Username,
    g.Name,
    ug.Cash,
    i.Name AS [Item Name]
FROM
    Users u
    JOIN UsersGames ug ON u.Id = ug.UserId
    JOIN Games g ON ug.GameId = g.Id
    JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
    JOIN Items i ON ugi.ItemId = i.Id
WHERE ug.GameId = @game
ORDER BY i.Name ASC
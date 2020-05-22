SELECT
    i.Name,
    i.Price,
    i.MinLevel,
    gt.Name
FROM
    items i
    LEFT JOIN GameTypeForbiddenItems gfi ON i.Id = gfi.ItemId
    LEFT JOIN GameTypes gt ON gfi.GameTypeId = gt.Id
ORDER BY gt.Name DESC,
            i.Name ASC
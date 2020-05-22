function solve()
{
    const appearancesCountByType = {};
    for (const parameter of arguments)
    {
        const type = typeof parameter;
        console.log(`${type}: ${parameter}`);

        if (appearancesCountByType.hasOwnProperty(type) === false)
        {
            appearancesCountByType[type] = 0;
        }

        appearancesCountByType[type]++;
    }

    const sortedAppearancesCountByType = Object.entries(appearancesCountByType);
    sortedAppearancesCountByType.sort(([typeA, countA], [typeB, countB]) => countB - countA);

    for (const [type, count] of sortedAppearancesCountByType)
    {
        console.log(`${type} = ${count}`);
    }
}
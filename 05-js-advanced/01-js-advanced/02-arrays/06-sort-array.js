function printItemsSorted(items)
{
    const itemsSorted = items.sort((a, b) =>
    {
        if (a.length !== b.length)
        {
            return a.length - b.length;
        }
        else
        {
            return a.localeCompare(b, undefined, { sensitivity: "base" });
        }
    });

    for (const item of itemsSorted)
    {
        console.log(item);
    }
}

printItemsSorted(["alpha", "beta", "gamma"]);
printItemsSorted(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
printItemsSorted(['test', 'Deny', 'omen', 'Default']);
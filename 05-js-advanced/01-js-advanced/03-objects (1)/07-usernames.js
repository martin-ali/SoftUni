function solve(names)
{
    function sortByLengthThenAlphabetically(a, b)
    {
        if (a.length !== b.length)
        {
            return a.length - b.length;
        }
        else
        {
            return a.localeCompare(b);
        }
    }

    const nonDuplicateNames = new Set(names);
    const sortedNames = Array.from(nonDuplicateNames);
    sortedNames.sort(sortByLengthThenAlphabetically);

    return sortedNames.join('\n');
}
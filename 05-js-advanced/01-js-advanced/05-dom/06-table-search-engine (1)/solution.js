function solve()
{
    const dataRows = document.querySelectorAll('tbody tr');
    const searchButton = document.getElementsByTagName('button')[0];

    searchButton.addEventListener('click', event =>
    {
        // Clear previousky selected rows
        for (const row of dataRows)
        {
            row.classList.remove('select');
        }

        // Get data
        const searchInput = document.getElementsByTagName('input')[0];
        const item = searchInput.value;
        searchInput.value = '';

        // Highlight matching rows
        for (const row of dataRows)
        {
            const isMatch = row.textContent.toLowerCase().includes(item.toLowerCase());
            if (isMatch)
            {
                row.classList.add('select');
            }
        }
    });
}
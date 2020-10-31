function solve()
{
    const tbody = document.getElementsByTagName('tbody')[0];
    const color = '#413f5e';
    let previousRow;

    tbody.addEventListener('click', event =>
    {
        const currentRow = event.target.parentNode;
        const allRows = currentRow.parentNode.children;

        if (currentRow.style.backgroundColor === '')
        {
            currentRow.style.backgroundColor = color;
        }
        else
        {
            currentRow.style.backgroundColor = '';
        }

        if (previousRow)
        {
            previousRow.style.backgroundColor = ''
        }

        previousRow = currentRow;
    });
}
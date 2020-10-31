function solve()
{
    const textAreas = document.getElementsByTagName('textarea');
    const inputTextArea = textAreas[0];
    const outputTextArea = textAreas[1];

    const buttons = document.getElementsByTagName('button');
    const generateButton = buttons[0];
    const buyButton = buttons[1];

    generateButton.addEventListener('click', event =>
    {
        const jsonData = inputTextArea.value;
        const furnitureItems = JSON.parse(jsonData);
        const furnitureTBody = document.getElementsByTagName('tbody')[0];

        for (const furniturePiece of furnitureItems)
        {
            const row = document.createElement('tr');
            const image = document.createElement('img');
            const imageCol = document.createElement('td');
            image.src = furniturePiece.img;
            imageCol.appendChild(image);
            row.appendChild(imageCol);

            for (const property in furniturePiece)
            {
                if (property !== 'img' && furniturePiece.hasOwnProperty(property))
                {
                    const col = document.createElement('td');
                    const paragraph = document.createElement('p');
                    paragraph.textContent = furniturePiece[property];
                    col.appendChild(paragraph);
                    row.appendChild(col);
                }
            }

            const markCheckboxCol = document.createElement('td');
            const markCheckbox = document.createElement('input');
            markCheckbox.type = 'checkbox';
            markCheckboxCol.appendChild(markCheckbox);
            row.appendChild(markCheckboxCol);

            furnitureTBody.appendChild(row);
        }
    });

    buyButton.addEventListener('click', event =>
    {
        const furniturePieces = [];
        const furnitureRows = Array
            .from(document.querySelectorAll('tbody tr input[type="checkbox"]:checked'))
            .map(x => x.parentElement.parentElement);
        let totalPrice = 0;
        let totalDecorationFactor = 0

        for (const furnitureRow of furnitureRows)
        {
            const paragraphs = furnitureRow.getElementsByTagName('p');
            const furniture = paragraphs[0].textContent;
            const price = parseFloat(paragraphs[1].textContent);
            const decorationFactor = parseFloat(paragraphs[2].textContent);

            furniturePieces.push(furniture);
            totalPrice += price;
            totalDecorationFactor += decorationFactor;
        }

        const averageDecorationFactor = totalDecorationFactor / furniturePieces.length;

        outputTextArea.value = '';
        outputTextArea.value += `Bought furniture: ${furniturePieces.join(', ')}\n`;
        outputTextArea.value += `Total price: ${totalPrice.toFixed(2)}\n`
        outputTextArea.value += `Average decoration factor: ${averageDecorationFactor}`
    });
}
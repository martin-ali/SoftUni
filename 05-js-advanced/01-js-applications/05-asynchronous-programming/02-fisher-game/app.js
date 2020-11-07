function capitalize(word)
{
    word = String(word);

    return word[0].toUpperCase() + word.slice(1);
}

function getTypeForInput(item)
{
    const itemAsNumber = parseFloat(item);

    if (isNaN(itemAsNumber))
    {
        return 'text';
    }
    else
    {
        return 'number'
    }
}

function generateCatchFromInputs(inputs)
{
    const newCatch = {};

    for (const field of inputs)
    {
        const property = field.className;
        let value = field.value;

        if (field.type === 'number')
        {
            value = parseFloat(value);
        }

        newCatch[property] = value;
    }

    return newCatch;
}

function generateCatchCard(catchInfo, id)
{
    const catchCard = document.createElement('div');
    catchCard.classList.add('catch');
    catchCard.setAttribute('data-id', id);

    for (const item in catchInfo)
    {
        const label = document.createElement('label')
        label.textContent = capitalize(item);
        catchCard.appendChild(label);

        const input = document.createElement('input');
        input.classList.add(item);
        input.type = getTypeForInput(catchInfo[item]);
        input.value = catchInfo[item];
        catchCard.appendChild(input);

        catchCard.appendChild(document.createElement('hr'));
    }

    const updateButton = document.createElement('button');
    updateButton.classList.add('update');
    updateButton.textContent = 'Update';
    catchCard.appendChild(updateButton);

    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete');
    deleteButton.textContent = 'Delete';
    catchCard.appendChild(deleteButton);

    return catchCard;
}

function attachEvents()
{
    async function handleAdd(event)
    {

        const inputs = document.querySelectorAll('fieldset#addForm input');
        const newCatch = generateCatchFromInputs(inputs);

        const newCatchJson = JSON.stringify(newCatch);
        http.postAsync('https://fisher-game.firebaseio.com/catches.json', newCatchJson);
    }

    async function handleLoad(event)
    {
        const catchesJson = await http.getAsync('https://fisher-game.firebaseio.com/catches.json');
        const catches = JSON.parse(catchesJson);
        const catchesContainer = document.getElementById('catches');

        catchesContainer.innerHTML = '';

        for (const catchInfo in catches)
        {
            const catchCard = generateCatchCard(catches[catchInfo], catchInfo);

            catchesContainer.appendChild(catchCard);
        }
    }

    async function handleModify(event)
    {
        const id = event.target.parentNode.getAttribute('data-id');
        if (event.target.classList.contains('update'))
        {
            const inputs = event.target.parentNode.getElementsByTagName('input');

            const modifiedCatch = generateCatchFromInputs(inputs);
            const modifiedCatchJson = JSON.stringify(modifiedCatch);

            http.updateAsync(`https://fisher-game.firebaseio.com/catches/${id}.json`, modifiedCatchJson);
        }
        else if (event.target.classList.contains('delete'))
        {
            http.deleteAsync(`https://fisher-game.firebaseio.com/catches/${id}.json`);
        }
    }

    document.querySelector('button.add')
        .addEventListener('click', handleAdd);

    document.querySelector('button.load')
        .addEventListener('click', handleLoad);

    document.querySelector('div#catches')
        .addEventListener('click', handleModify);
}

attachEvents();
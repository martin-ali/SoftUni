async function attachEvents()
{

    async function refreshPhonebook()
    {
        phonebookUl.innerHTML = '';

        const dataJson = await http.getAsync('https://phonebook-nakov.firebaseio.com/phonebook.json');
        const contacts = JSON.parse(dataJson);

        for (const id in contacts)
        {
            const { person, phone } = contacts[id];

            const li = document.createElement('li');
            li.textContent = `${person}: ${phone}`

            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', async event =>
            {
                await http.deleteAsync(`https://phonebook-nakov.firebaseio.com/phonebook/${id}.json`);

                refreshPhonebook();
            })

            li.appendChild(deleteButton);
            phonebookUl.appendChild(li);
        }
    };

    const loadButton = document.getElementById('btnLoad');
    const createButton = document.getElementById('btnCreate');
    const phonebookUl = document.getElementById('phonebook');

    loadButton.addEventListener('click', refreshPhonebook);

    createButton.addEventListener('click', async event =>
    {
        const personInput = document.getElementById('person');
        const phoneInput = document.getElementById('phone');

        const person = personInput.value;
        const phone = phoneInput.value;

        const personPhone = JSON.stringify({ person, phone });

        phoneInput.value = '';
        personInput.value = '';

        await http.postAsync('https://phonebook-nakov.firebaseio.com/phonebook.json', personPhone);

        refreshPhonebook();
    })
}

attachEvents();
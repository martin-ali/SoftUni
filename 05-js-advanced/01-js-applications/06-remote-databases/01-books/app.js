// import { database } from "firebase";

function setup() {
    function handleCreateBook() {
        // @ts-ignore
        const inputs = event.target.parentNode.getElementsByTagName('input');
        const bookData = generateBookFromInputs(inputs);

        database.createBook(bookData);
    }

    async function handleLoadBooks() {
        const booksTable = document.getElementsByTagName('tbody')[0];
        booksTable.innerHTML = '';

        const books = await database.getAllBooksAsync();

        for (const bookId in books) {
            const row = generateRowFromBook(books[bookId], bookId);

            booksTable.appendChild(row);
        }
    }

    async function handleShowEditBookForm(event) {
        // @ts-ignore
        const id = event.target.parentNode.parentNode.dataset['bookId']
        const book = await database.getBookByIdAsync(id)

        const destinationInputs = document.querySelectorAll('form#editBook input');
        for (const input of destinationInputs) {
            if (input.name === 'tags') {
                input.value = book[input.name].join(', ');
            } else {
                input.value = book[input.name];
            }
        }

        const idInput = document.getElementsByName('id')[0];
        idInput.value = id;

        const createForm = document.getElementById('createBook');
        const editForm = document.getElementById('editBook');

        createForm.style.display = 'none';
        editForm.style.display = 'block';
    }

    async function handleSubmitEditedBook(event) {
        // @ts-ignore
        const inputs = document.querySelectorAll('form#editBook input:not([disabled])');
        const id = document.querySelector('form#editBook input[name=id]').value;
        const bookData = generateBookFromInputs(inputs);

        database.updateBook(bookData, id);

        const createForm = document.getElementById('createBook');
        const editForm = document.getElementById('editBook');

        createForm.style.display = 'block';
        editForm.style.display = 'none';
    }

    function handleDeleteBook(event) {
        const id = event.target.parentNode.parentNode.dataset['bookId'];

        database.deleteBook(id);
    }

    function handleCancelCreate() {
        const createForm = document.getElementById('createBook');
        const editForm = document.getElementById('editBook');

        createForm.style.display = 'block';
        editForm.style.display = 'none';

        createForm.childNodes.forEach(x => x.value = '');
    }

    function handleCancelEdit() {
        const createForm = document.getElementById('createBook');
        const editForm = document.getElementById('editBook');

        createForm.style.display = 'block';
        editForm.style.display = 'none';

        editForm.childNodes.forEach(x => x.value = '');
    }

    function generateBookFromInputs(inputs) {
        const book = {};
        for (const input of inputs) {
            const property = input.name;
            const value = input.value;

            if (property === 'tags') {
                book[property] = value.split(', ');
            } else {
                book[property] = value;
            }
        }

        return book;
    }

    function generateRowFromBook(book, id) {
        const row = document.createElement('tr');
        row.dataset['bookId'] = id;

        const propertiesTh = document.getElementsByTagName('th');

        for (const propertyTh of propertiesTh) {
            const property = propertyTh.innerText.toLowerCase();
            const col = document.createElement('td');
            row.appendChild(col);

            if (property === 'tags') {
                col.textContent = book[property].join(', ');
            } else {
                col.textContent = book[property];
            }
        }

        const buttonsCol = row.lastChild;

        const editButton = document.createElement('button');
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', handleShowEditBookForm)
        buttonsCol.appendChild(editButton);

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', handleDeleteBook)
        buttonsCol.appendChild(deleteButton);

        return row;
    }

    // Solve problem
    document.getElementById('loadBooks')
        .addEventListener('click', handleLoadBooks);

    document.getElementById('submit')
        .addEventListener('click', handleCreateBook);

    document.getElementById('edit')
        .addEventListener('click', handleSubmitEditedBook);

    document.getElementById('cancelEdit')
        .addEventListener('click', handleCancelEdit);

    document.getElementById('cancelCreate')
        .addEventListener('click', handleCancelCreate);
}

setup();
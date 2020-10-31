const database = (function () {
    function createBook(bookData) {
        fetch(`${api}.json`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookData)
        });
    }

    async function getAllBooksAsync() {
        const response = await fetch(`${api}.json`);
        const books = await response.json();

        return books;
    }

    function updateBook(bookData, id) {
        fetch(`${api}/${id}.json`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookData)
        });
    }

    function deleteBook(id) {
        fetch(`${api}/${id}.json`, {
            method: 'DELETE'
        });
    }

    async function getBookByIdAsync(id) {
        const response = await fetch(`${api}/${id}.json`);
        const book = await response.json();

        return book;
    }

    // Intialize firebase
    const api = 'https://books-10b24.firebaseio.com/books';

    return {
        createBook,
        getAllBooksAsync,
        updateBook,
        deleteBook,
        getBookByIdAsync
    }
})();
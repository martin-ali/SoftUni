const database = (function () {
    async function createStudentAsync(studentData) {
        await fetch(`${api}.json`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(studentData)
        });
    }

    async function getAllStudentsAsync() {
        const response = await fetch(`${api}.json`);
        const students = await response.json();

        return students;
    }

    // Intialize firebase
    const api = 'https://students-a7d62.firebaseio.com/students';

    return {
        createStudentAsync,
        getAllStudentsAsync
    }
})();
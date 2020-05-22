function setup() {
    async function handleCreateNewStudent(event) {
        const inputs = event.target.parentNode.getElementsByTagName('input');

        const studentData = {};
        for (const input of inputs) {
            const property = input.name;
            const value = getParsedValue(input);
            const valueIsMismatched = input.type === 'number' && isNaN(parseInt(value));

            if (!value || valueIsMismatched) {
                return;
            }

            studentData[property] = value;
        }

        if (await idIsTaken(studentData.id)) {
            alert('Id is taken!');
            return;
        }

        await database.createStudentAsync(studentData);

        refreshAllStudents();
    }

    async function refreshAllStudents() {
        const studentsData = await database.getAllStudentsAsync();
        const studentsDiv = document.querySelector('table#results tbody');

        studentsDiv.innerHTML = '';

        const students = [];
        for (const databaseId in studentsData) {
            students.push(studentsData[databaseId]);
        }

        students.sort((a, b) => a.id - b.id);

        for (const student of students) {
            const row = generateRowFromStudent(student)

            studentsDiv.appendChild(row);
        }
    }

    async function idIsTaken(id) {
        const students = await database.getAllStudentsAsync();

        for (const databaseId in students) {
            const student = students[databaseId];

            if (student.id === id) {
                return true;
            }
        }

        return false;
    }

    function generateRowFromStudent(student, id) {
        const row = document.createElement('tr');
        const propertiesOrder = document.querySelectorAll('table#results th');

        for (const header of propertiesOrder) {
            const property = convertToDatabaseCase(header.textContent);

            const col = document.createElement('td');
            row.appendChild(col);

            col.textContent = student[property];
        }

        return row;
    }

    function convertToDatabaseCase(item) {
        if (item === 'ID') {
            return item.toLowerCase();
        }

        const itemWithoutSpaces = item.replace(' ', '');
        const itemInCamelCase = `${itemWithoutSpaces[0].toLowerCase()}${itemWithoutSpaces.slice(1)}`;

        return itemInCamelCase;
    }

    function getParsedValue(input) {
        if (input.type === 'number') {
            return parseInt(input.value);
        }

        return input.value;
    }

    refreshAllStudents();

    document.querySelector('button#submit')
        .addEventListener('click', handleCreateNewStudent);
}

setup();
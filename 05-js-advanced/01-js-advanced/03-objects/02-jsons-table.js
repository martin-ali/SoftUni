function convertJsonToHtml(teachersData)
{
    const teachers = [];
    for (const teacherData of teachersData)
    {
        teachers.push(JSON.parse(teacherData));
    }

    let table = '<table>\n';

    for (const teacher of teachers)
    {
        let row = '<tr>\n';

        row += `<td>${teacher.name}</td>\n`;
        row += `<td>${teacher.position}</td>\n`;
        row += `<td>${teacher.salary}</td>\n`;

        row += '</tr>\n';

        table += row;
    }

    table += '</table>';

    return table;
}
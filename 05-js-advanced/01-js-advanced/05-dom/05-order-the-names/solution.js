function solve()
{
    const addButton = document.getElementsByTagName('button')[0];
    addButton.addEventListener('click', event =>
    {
        let name = document.getElementsByTagName('input')[0].value.toLowerCase();
        name = name.charAt(0).toUpperCase() + name.slice(1);
        const rows = document.getElementsByTagName('li');
        const index = name.toLowerCase().charCodeAt(0) - 97;

        if (rows[index].textContent === '')
        {
            rows[index].innerHTML = name;
        }
        else
        {
            rows[index].innerHTML += `, ${name}`;
        }
    });
}
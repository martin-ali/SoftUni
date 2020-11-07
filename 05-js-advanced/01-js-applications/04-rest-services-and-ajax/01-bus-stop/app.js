async function getInfo()
{
    const stopNameDiv = document.getElementById('stopName');
    const stopId = document.getElementById('stopId').value;
    const busesUl = document.getElementById('buses');

    busesUl.innerHTML = '';

    const result = await http.getAsync(`https://judgetests.firebaseio.com/businfo/${stopId}.json`);
    const info = JSON.parse(result);

    if (info === null
        || info.error)
    {
        stopNameDiv.textContent = 'Error';
        busesUl.innerHTML = '';

        return;
    }

    stopNameDiv.textContent = info.name;

    const buses = info.buses;

    for (const number in buses)
    {
        const busInfoLi = document.createElement('li');

        busInfoLi.textContent = `Bus ${number} arrives in ${buses[number]} minutes`;

        busesUl.appendChild(busInfoLi);
    }
}
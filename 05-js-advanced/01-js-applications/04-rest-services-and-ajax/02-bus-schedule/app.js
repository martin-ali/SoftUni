function solve()
{
    const arriveButton = document.getElementById('arrive');
    const departButton = document.getElementById('depart');
    const infoDiv = document.getElementById('info');
    let stopName;
    let nextStop = 'depot';

    async function depart()
    {
        const stopInfoJson = await http.getAsync(`https://judgetests.firebaseio.com/schedule/${nextStop}.json`);
        const stopInfo = JSON.parse(stopInfoJson);

        if (stopInfo === null)
        {
            infoDiv.textContent = 'Error';
            departButton.disabled = true;
            arriveButton.disabled = true;
        }

        stopName = stopInfo.name;
        nextStop = stopInfo.next;

        infoDiv.textContent = `Next stop ${stopName}`;

        departButton.disabled = true;
        arriveButton.disabled = false;
    }

    function arrive()
    {
        arriveButton.disabled = true;
        departButton.disabled = false;

        infoDiv.textContent = `Arriving at ${stopName}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
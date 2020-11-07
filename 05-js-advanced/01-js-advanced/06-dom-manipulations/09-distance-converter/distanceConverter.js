function attachEventsListeners()
{
    const convertButton = document.getElementById('convert');
    const output = document.getElementById('outputDistance');

    const convertToMetersFrom = {
        km: kilometers => kilometers * 1000,
        m: meters => meters,
        cm: centimeters => centimeters * 0.01,
        mm: millimeters => millimeters * 0.001,
        mi: miles => miles * 1609.34,
        yrd: yards => yards * 0.9144,
        ft: feet => feet * 0.3048,
        in: inches => inches * 0.0254
    };

    const convertFromMetersTo = {
        km: meters => meters / 1000,
        m: meters => meters,
        cm: meters => meters / 0.01,
        mm: meters => meters / 0.001,
        mi: meters => meters / 1609.34,
        yrd: meters => meters / 0.9144,
        ft: meters => meters / 0.3048,
        in: meters => meters / 0.0254
    };

    convertButton.addEventListener('click', event =>
    {
        const input = document.getElementById('inputDistance');
        const distance = parseFloat(input.value);

        const inputUnit = document.getElementById('inputUnits').value;
        const outputUnit = document.getElementById('outputUnits').value;

        const distanceInMeters = convertToMetersFrom[inputUnit](distance);
        const distanceInOutputUnit = convertFromMetersTo[outputUnit](distanceInMeters);

        output.value = distanceInOutputUnit;
    });
}
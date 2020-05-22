function getCarByRequirements(requirements)
{
    const engines = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }
    ];

    const model = requirements.model;
    const engine = engines.find(e => e.power >= requirements.power);
    const carriage = { type: requirements.carriage, color: requirements.color };
    let wheelSize = requirements.wheelsize;

    if (wheelSize % 2 === 0)
    {
        wheelSize--;
    }

    const wheels = [wheelSize, wheelSize, wheelSize, wheelSize];

    return {
        model,
        engine,
        carriage,
        wheels
    };
}
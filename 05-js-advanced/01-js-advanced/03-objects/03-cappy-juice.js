function printJuiceBottlesCount(juicesInfo)
{
    const quantityByJuice = new Map();
    const orderedJuices = [];

    for (const juiceInfo of juicesInfo)
    {
        const [juice, quantity] = juiceInfo.split(' => ');
        if (quantityByJuice.has(juice) === false)
        {
            quantityByJuice.set(juice, 0);
        }

        const totalQuantity = quantityByJuice.get(juice) + parseInt(quantity, 10);

        if (orderedJuices.includes(juice) === false && totalQuantity >= 1000)
        {
            orderedJuices.push(juice);
        }

        quantityByJuice.set(juice, totalQuantity);
    }

    for (const juice of orderedJuices)
    {
        const quantity = quantityByJuice.get(juice);
        console.log(`${juice} => ${Math.floor(quantity / 1000)}`);
    }
}
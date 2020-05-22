function printCarsData(carsData)
{
    'use strict';

    const modelByBrand = new Map();

    for (const carData of carsData)
    {
        const [brand, model, producedData] = carData.split(' | ');
        const newProduced = parseInt(producedData);

        if (modelByBrand.has(brand) === false)
        {
            modelByBrand.set(brand, new Map());
        }

        if (modelByBrand.get(brand).has(model) === false)
        {
            modelByBrand.get(brand).set(model, 0);
        }

        const oldProduced = modelByBrand.get(brand).get(model);
        const totalProduced = newProduced + oldProduced;

        modelByBrand.get(brand).set(model, totalProduced);
    }

    for (const [brand, models] of modelByBrand)
    {
        console.log(brand);
        for (const [name, produced] of models)
        {
            console.log(`###${name} -> ${produced}`);
        }
    }
}
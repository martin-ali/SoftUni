function getFruitInfo(fruit, weightInGr, pricePerKg)
{
    'use strict';

    const weightInKg = weightInGr / 1000;
    const totalPrice = pricePerKg * weightInKg;
    const formattedWeightInKg = weightInKg.toFixed(2);
    const formattedTotalPrice = totalPrice.toFixed(2);

    const result = `I need $${formattedTotalPrice} to buy ${formattedWeightInKg} kilograms ${fruit}.`

    console.log(result);
}

// solve('orange', 2500, 1.80)
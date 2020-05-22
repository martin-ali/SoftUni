function getCaloriesInfo(parameters)
{
    'use strict';

    const calorieInformationPer100gr = {};
    for (let current = 1; current < parameters.length; current += 2)
    {
        const fruit = parameters[current - 1];
        const caloriesPer100gr = parseInt(parameters[current], 10);

        calorieInformationPer100gr[fruit] = caloriesPer100gr;
    }

    return calorieInformationPer100gr;
}
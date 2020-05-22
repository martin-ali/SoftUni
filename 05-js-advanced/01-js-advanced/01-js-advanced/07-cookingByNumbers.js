function processNumber(parameters)
{
    'use strict';

    let number = parameters.shift();
    const execute = {
        chop: x => x / 2,
        dice: x => Math.sqrt(x),
        spice: x => x + 1,
        bake: x => x * 3,
        fillet: x => x - x * 0.2
    };

    for (const command of parameters)
    {

        number = execute[command](number);

        console.log(number);
    }
}
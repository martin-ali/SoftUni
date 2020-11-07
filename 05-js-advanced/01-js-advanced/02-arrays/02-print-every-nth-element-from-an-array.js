function printEveryNthElement(parameters)
{
    const step = parseInt(parameters.pop());
    const items = parameters;

    for (let current = 0; current < items.length; current += step)
    {
        console.log(items[current]);
    }
}
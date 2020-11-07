function executeCommands(commands)
{
    const numbers = [];
    let currentNumber = 1;

    for (const command of commands)
    {
        if (command === "add")
        {
            numbers.push(currentNumber);
        }
        else if (command === "remove")
        {
            numbers.pop();
        }

        currentNumber++;
    }

    if (numbers.length === 0)
    {
        console.log("Empty");
    }
    else
    {
        for (const number of numbers)
        {
            console.log(number);
        }
    }
}
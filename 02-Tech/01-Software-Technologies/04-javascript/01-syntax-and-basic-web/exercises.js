// jshint esversion:6

function multiplyNumber([number])
{
    return number * 2;
}

function multiplyTwoNumbers([firstNumber, secondNumber])
{
    return firstNumber * secondNumber;
}

function multiplyDivideNumber([firstNumber, secondNumber])
{
    let result = 0;
    if (secondNumber >= firstNumber)
    {
        result = firstNumber * secondNumber;
    }
    else
    {
        result = firstNumber / secondNumber;
    }

    return result;
}

function productOfThree(numbers)
{
    const productSign = numbers.filter(x => x < 0).length % 2 == 0;
    const zeroContained = numbers.includes(0);

    const result = productSign || zeroContained ? "Positive" : "Negative";
    return result;
}

function numbersOneToN([n])
{
    for (let current = 1; current <= n; ++current)
    {
        console.log(current);
    }
}

function numbersNToOne([n])
{
    for (let current = n; current >= 1; --current)
    {
        console.log(current);
    }
}

function printLines(commands)
{
    const stop = commands.indexOf("Stop");
    for (let index = 0; index < stop; ++index)
    {
        console.log(commands[index]);
    }
}

function printLinesReversed(commands)
{
    for (let index = commands.length - 1; index >= 0; --index)
    {
        console.log(commands[index]);
    }
}

function setValues(commands)
{
    const arr = [];
    const length = +commands[0];
    for (let current = 1; current < commands.length; ++current)
    {
        const commandRaw = commands[current].split(' - ');
        const command = {
            index: +commandRaw[0],
            value: +commandRaw[1]
        };

        arr[command.index] = command.value;
    }

    for (let index = 0; index < length; ++index)
    {
        console.log(arr[index] || 0);
    }
}

setValues(['3', '0 - 5', '1 - 6', '2 - 7']);
// setValues(['5', '0 - 3', '3 - -1', '4 - 2']);

function addRemoveElements(commands)
{
    let arr = [];
    const execute = {
        add: (x) => arr.push(x),
        remove: (x) =>
        {
            // arr[x] = undefined;
            const newArr = [];
            for (let originalIndex = 0, newIndex = 0; originalIndex < arr.length; ++originalIndex)
            {
                if (originalIndex !== x)
                {
                    newArr[newIndex] = arr[originalIndex];
                    ++newIndex;
                }
            }

            arr = newArr;
        }
    };

    for (let current = 0; current < commands.length; current++)
    {
        const rawCommand = commands[current].split(' ');
        const command = {
            type: rawCommand[0],
            target: +rawCommand[1]
        };

        execute[command.type](command.target);
    }

    arr.forEach(x => console.log(x));
}

// addRemoveElements(['add 3', 'add 5', 'add 7']);
// addRemoveElements(['add 3', 'add 5', 'remove 2', 'remove 0', 'add 7']);

function keyValuePairs(commands)
{
    const map = new Map();
    const final = commands.pop();

    for (let current = 0; current < commands.length; current++)
    {
        const rawCommand = commands[current].split(' ');
        // const key = rawCommand[0];
        // const value = rawCommand[1];

        const [key, value] = rawCommand;
        map.set(key, value);
    }

    if (map.has(final))
    {
        console.log(map.get(final));
    }
    else
    {
        console.log("None");
    }
}

// keyValuePairs(['key value', 'key eulav', 'test tset', 'key']);

function multipleValuesForKey(commands)
{
    const map = new Map();
    const final = commands.pop();

    for (let current = 0; current < commands.length; current++)
    {
        const rawCommand = commands[current].split(' ');
        const [key, value] = rawCommand;

        if (map.has(key) === false) map.set(key, []);
        map.get(key).push(value);
    }

    if (map.has(final))
    {
        map.get(final).forEach(x => console.log(x));
    }
    else
    {
        console.log("None");
    }
}

// multipleValuesForKey(['key value', 'key eulav', 'test tset', 'key']);

function storingObject(commands)
{
    const students = [];
    for (let current = 0; current < commands.length; ++current)
    {
        const commandRaw = commands[current].split(' -> ');
        const [name, age, grade] = commandRaw;

        students.push({ name, age, grade });
    }

    students.forEach(({ name, age, grade }) =>
    {
        console.log(`Name: ${name}\nAge: ${age}\nGrade: ${grade}`);
    });
}

storingObject(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90']);

function deserializeJson(lines)
{
    for (let current = 0; current < lines.length; ++current)
    {
        const deserializedObj = JSON.parse(lines[current]);
        const { name, age, date } = deserializedObj;

        console.log(`Name: ${name}\nAge: ${age}\nDate: ${date}`);
    }
}

function serializeJson(lines)
{
    const obj = {};
    for (let current = 0; current < lines.length; ++current)
    {
        const property = lines[current].split(' -> ');
        let [key, value] = property;

        if (key === 'age' || key === 'grade') value = +value;

        obj[key] = value;
    }

    console.log(JSON.stringify(obj));
}
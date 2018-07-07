// jshint esversion:6
function multiplyNumberBy2([number])
{
    return number * 2
}

function multiplyTwoNumbers([firstNumber, secondNumber])
{
    return firstNumber * secondNumber
}

function multiplyDivideNumberByGivenSecondNumber([firstNumber, secondNumber])
{
    let result = 0
    if (secondNumber >= firstNumber)
    {
        result = firstNumber * secondNumber
    }
    else
    {
        result = firstNumber / secondNumber
    }

    return result
}

function productOfThreeNumbers(numbers)
{
    const negativeNumberCountIsEven = numbers.filter(x => x < 0).length % 2 == 0
    const zeroContained = numbers.includes(0)

    const result = negativeNumberCountIsEven || zeroContained ? "Positive" : "Negative"
    return result
}

function printNumbers1ToN([n])
{
    for (let number = 1; number <= n; ++number)
    {
        console.log(number)
    }
}

function printNumbersNTo1([n])
{
    for (let number = n; number >= 1; --number)
    {
        console.log(number)
    }
}

function printLines(lines)
{
    const end = lines.indexOf('stop')
    for (let i = 0; i < end; ++i)
    {
        console.log(lines[i])
    }
}

function printNumbersReversed(numbers)
{
    for (const number of numbers.reverse())
    {
        console.log(number)
    }
}

// printNumbersReversed([1, 2, 3, 4, 5])

function setValuesToIndexesInArray(indexValuePairs)
{
    const length = Number(indexValuePairs.shift())
    const numbers = new Array(length)
    for (const pair of indexValuePairs)
    {
        const [index, value] = pair.split(' - ')
        numbers[+index] = +value
    }

    for (const number of numbers)
    {
        console.log(number || 0)
    }
}

setValuesToIndexesInArray(['2', '0 - 5', '0 - 6', '0 - 7'])
// setValuesToIndexesInArray(['3', '0 - 5', '1 - 6', '2 - 7'])
// setValuesToIndexesInArray(['5', '0 - 3', '3 - -1', '4 - 2'])

function addRemoveElements(commands)
{
    const numbers = []
    const execute = {
        add: (x) => numbers.push(x),
        remove: (indexToSkip) =>
        {
            const indexIsValid = 0 <= indexToSkip && indexToSkip < commands.length
            if (indexIsValid)
            {
                numbers.splice(indexToSkip, 1)
            }
        }
    }

    for (let current = 0; current < commands.length; current++)
    {
        const [command, target] = commands[current].split(' ')
        execute[command](+target)
    }

    numbers.forEach(x => console.log(x))
}

// addRemoveElements(['add 3', 'add 5', 'add 7'])
// addRemoveElements(['add 3', 'add 5', 'remove 2', 'remove 0', 'add 7'])

function keyValuePairs(keyValuePairs)
{
    const map = new Map()
    const final = keyValuePairs.pop()

    for (const pair of keyValuePairs)
    {
        const [key, value] = pair.split(' ')
        map.set(key, value)
    }

    if (map.has(final))
    {
        console.log(map.get(final))
    }
    else
    {
        console.log("None")
    }
}

// keyValuePairs(['key value', 'key eulav', 'test tset', 'key'])

function multipleValuesForKey(keyValuePairs)
{
    const map = new Map()
    const final = keyValuePairs.pop()

    for (const pair of keyValuePairs)
    {
        const [key, value] = pair.split(' ')

        if (map.has(key) === false)
        {
            map.set(key, [])
        }

        map.get(key).push(value)
    }

    if (map.has(final))
    {
        map.get(final).forEach(x => console.log(x))
    }
    else
    {
        console.log("None")
    }
}

// multipleValuesForKey(['key value', 'key eulav', 'test tset', 'key'])

function storingObject(lines)
{
    const students = []
    for (const line of lines)
    {
        const [name, age, grade] = line.split(' -> ')
        students.push({ name, age, grade })
    }

    students.forEach(({ name, age, grade }) =>
    {
        console.log(`Name: ${name}\nAge: ${age}\nGrade: ${grade}`)
    })
}

// storingObject(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90'])

function deserializeJson(lines)
{
    for (const line of lines)
    {
        const deserializedObj = JSON.parse(line)
        const { name, age, date } = deserializedObj

        console.log(`Name: ${name}\nAge: ${age}\nDate: ${date}`)
    }
}

function serializeJson(lines)
{
    const obj = {}
    for (const line of lines)
    {
        let [key, value] = line.split(' -> ')

        if (key === 'age' || key === 'grade')
        {
            value = Number(value)
        }

        obj[key] = value
    }

    console.log(JSON.stringify(obj))
}
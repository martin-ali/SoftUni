// jshint esversion:6
function symmetricNumbers([limit])
{
    function isSymmetric(number)
    {
        const word = String(number);
        const firstHalf = word.substring(0, Math.floor(word.length / 2));
        const secondHalf = word.substring(Math.ceil(word.length / 2));

        if (firstHalf === secondHalf.split('').reverse().join(''))
        {
            return true;
        }

        return false;
    }

    for (let current = 1; current <= limit; ++current)
    {
        if (isSymmetric(current))
        {
            console.log(current);
        }
    }
}

function sumsByTown(towns)
{
    // Could also use map
    const townsOrder = [];
    const townInfo = {};
    for (let current = 0; current < towns.length; ++current)
    {
        const { town, income } = JSON.parse(towns[current]);

        if (townsOrder.indexOf(town) < 0)
        {
            townsOrder.push(town);
            townInfo[town] = 0;
        }

        townInfo[town] += income;
    }

    townsOrder.sort().forEach(town => console.log(`${town} -> ${townInfo[town]}`));
}

// sumsByTown(
//     ['{"town":"Sofia","income":200}',
//         '{"town":"Varna","income":120}',
//         '{"town":"Pleven","income":60}',
//         '{"town":"Varna","income":70}'
//     ]
// );

function largestThreeNumbers(numbers)
{
    numbers
        .sort((a, b) => (b - a))
        .slice(0, 3)
        .forEach(x => console.log(x));
}

// largestThreeNumbers([10, 30, 15, 20, 50, 5]);

function extractCapitalCaseWords(text)
{
    // Why does this work?
    const pattern = /\b[A-Z]+\b/g;
    const words = [];

    text.forEach(line =>
    {
        line.match(pattern).forEach(matchedWord => words.push(matchedWord))
    });

    console.log(words.join(', '));
}

// extractCapitalCaseWords(
//     [
//         'We start by HTML, CSS, JavaScript, JSON and REST.',
//         'Later we touch some PHP, MySQL and SQL.',
//         'Later we play with C#, EF, SQL Server and ASP.NET MVC.',
//         'Finally, we touch some Java, Hibernate and Spring.MVC.'
//     ]
// );
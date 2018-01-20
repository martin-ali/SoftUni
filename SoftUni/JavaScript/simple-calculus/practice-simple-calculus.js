// jshint esversion: 6

function squareArea([side])
{
    side = +side;
    let squareArea = side * side;

    console.log(`Square = ${squareArea}`);
}

function inchesToCentimeters([inches])
{
    let centimeters = +inches * 2.54;

    console.log(`centimeters = ${centimeters}`);
}

function greeting([name])
{
    console.log(`Hello, ${name}!`);
}

function concatenateData([firstName, lastName, age, town])
{
    console.log(`You are ${firstName} ${lastName}, a ${age}-years old person from ${town}.`);
}

function trapezoidArea([firstBase, secondBase, height])
{
    firstBase  = +firstBase;
    secondBase = +secondBase;
    height     = +height;

    let area = (firstBase + secondBase) * height / 2;
    console.log(`Trapezoid area = ${area}`);
}

function circleAreaAndPerimeter([radius])
{
    radius = +radius;
    let area = radius * radius * Math.PI;
    let perimeter = 2 * radius * Math.PI;
    console.log(`Area = ${area}\nPerimeter = ${perimeter}`);
}

function rectangleInPlaneArea([x1, y1, x2, y2])
{
    x1 = +x1;
    x2 = +x2;
    y1 = +y1;
    y2 = +y2;

    let leftSide = Math.abs(y1 - y2);
    let bottomSide = Math.abs(x1 - x2);

    let area = leftSide * bottomSide;
    let perimeter = 2 * (leftSide + bottomSide);

    console.log(`${area}\n${perimeter}`);
}

function triangleArea([side, height])
{
    let area = side * height / 2;
    console.log(`Triangle area = ${area}`);
}

function celsiusToFahrenheit([celsius])
{
    let fahrenheit = (celsius * 1.8) + 32;
    console.log(fahrenheit.toFixed(2));
}

function radiansToDegree([radians])
{
    let degrees = radians * (180 / Math.PI);
    console.log(degrees.toFixed(2));
}

function usdToBgn([usd])
{
    let usdToBgnCourse = 1.79549;
    let bgn = usd * usdToBgnCourse;
    console.log(bgn.toFixed(2));
}

function currencyConverter([value, inputCurrency, outputCurrency])
{
    let usdToBgnCourse = 1.79549,
        eurToBgnCourse = 1.95583,
        gbpToBgnCourse = 2.53405;

    let courseMap = {
        "USD": usdToBgnCourse,
        "EUR": eurToBgnCourse,
        "GBP": gbpToBgnCourse
    };

    let inputCurrencyIsSupported = courseMap[inputCurrency];
    if (inputCurrencyIsSupported)
    {
        value = value * courseMap[inputCurrency];
    }

    let outputCurrencyIsSupported = courseMap[outputCurrency];
    if (outputCurrencyIsSupported)
    {
        value = value / courseMap[outputCurrency];
    }

    console.log(value.toFixed(2));
}

function oneThousandDaysAfterBirth([startDateString])
{
    // Jessus... I hate JS date handling. Always had problems with it
    function padLeft(stringToPad, size, characterToPadWith)
    {
        stringToPad = stringToPad.toString();
        size = +size;
        characterToPadWith = characterToPadWith.toString();

        let stringisNotLongEnough = stringToPad.length < size;
        if (stringisNotLongEnough)
        {
            return characterToPadWith.repeat(size - stringToPad.length) + stringToPad;
        }

        return stringToPad;
    }

    // Much bad date handling, bad code, wow
    let startDateSplit = startDateString.split('-');
    // -1 for the month because JS counts 0-11, not 1-12
    let startDate = new Date(startDateSplit[2], +startDateSplit[1] - 1, startDateSplit[0]);
    let endDate = new Date(startDate.setDate(startDate.getDate() + 999));

    let date = padLeft(endDate.getDate(), 2, '0');
    let month = padLeft(endDate.getMonth() + 1, 2, '0');
    let year = endDate.getFullYear();

    console.log(`${date}-${month}-${year}`);
}
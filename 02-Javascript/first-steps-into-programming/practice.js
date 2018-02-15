// jshint esversion: 6

function nums1To20()
{
    for (let current = 1; current <= 20; ++current)
    {
        console.log(current);
    }
}

function triangleOfStars()
{
    let starCurrentLine = '*';
    for (let current = 0; current < 10; ++current)
    {
        console.log(starCurrentLine);
        starCurrentLine += '*';
    }
}

function rectangleArea([sideA, sideB])
{
    return sideA * sideB;
}

function squareOfStars([size])
{
    console.log('*'.repeat(size));
    
    for (let current = 2; current < size; ++current) 
    {
        console.log('*' + ' '.repeat(size-2) + '*');
    }

    console.log('*'.repeat(size));
}


/*
"collapse", 
"expand", 
"end-expand", 
"none", 
"collapse,preserve-inline", 
"expand,preserve-inline", 
"end-expand,preserve-inline", 
"none,preserve-inline" 
*/
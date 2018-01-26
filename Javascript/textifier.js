// Old code from ~2yrs ago starts here
//----------------------------------------------------------------------------------------------------------

// Made this code to take advantage of as many javascript capabilities as I could jam into it
// Problem 8. Number as words --> Bigger version(I experimented around with stuff here)
function giantWordNumberProcessor(targetNumber)
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    //// WARNING!!! POSSIBLE ECMASCRIPT < v6.0 OCTAL BEHAVIOUR! THIS IS NOT MY FAULT. HAVE A NICE DAY! ////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////

    // Just add more names to the levels array and larger numbers are magically supported now :)
    var levels = ['', 'thousand', 'million', 'billion', 'trillion', 'quadrillion', 'megagigantilliom'],
        targetString = String(targetNumber),
        length = targetString.length,
        separatedGroupsOfDigits = [],
        cycleCounter = 0,
        thirdPart = '',
        level = 0,
        grouperLength,
        levelUp,
        section,
        i;

    if (typeof(targetNumber) !== "number" || isNaN(targetNumber)) // Second part checks for NaN
    {
        return ('Thou hath entereth and invalith numbeth. Thou shalt now enter a validth numbeth!');
    }
    else if ((targetNumber) === 0) // This part checks if target is zero and transfers to number if needed
    {
        return ('zero');
    }

    // This part adds every group of three digits to the array to be used for further processing
    for (i = length - 1; i >= 0; i -= 1)
    {
        cycleCounter += 1;
        thirdPart = targetString[i] + '' + thirdPart;
        if ((cycleCounter % 3 === 0) || i === 0)
        {
            separatedGroupsOfDigits.unshift(thirdPart);
            thirdPart = '';
        }
    }
    console.log('Your number: ' + separatedGroupsOfDigits.join(' ')); // Used for visual verification, so you don't have to count the digits by hand :)

    // This part sends the contents of each cell for processing and replaces them with a worded variant of the number inside and a level indicator if needed(thousand, million etc...)
    // Cell with content that equals zero are removed
    grouperLength = separatedGroupsOfDigits.length - 1;
    for (i = grouperLength; i >= 0; i -= 1)
    {
        if (separatedGroupsOfDigits[i] === '000')
        {
            separatedGroupsOfDigits.splice(i, 1);
        }
        else
        {
            section = separatedGroupsOfDigits[i];
            levelUp = (section === '000' ? '' : (' ' + levels[level]));
            separatedGroupsOfDigits[i] = numberAsWords(section).trim() + levelUp;
            level += 1;
        }
    }

    // I should rework this to add an "and" wherever needed, but what kind of logic should I use?
    // This part removes empty cells
    //length=separatedGroupsOfDigits.length;            // Needs better logic. Numbers are sometimes awkwardly worded
    //var tr = !separatedGroupsOfDigits[length - 2];
    //var xr = length > 2;
    //var st = separatedGroupsOfDigits[length - 1] !== '';
    //if (tr && xr && st)
    //{
    //    separatedGroupsOfDigits[length - 2] = 'and';
    //}
    //for (i = grouperLength; i >= 0; i -= 1)
    //{
    //    if (separatedGroupsOfDigits[i] === '')
    //    {
    //        separatedGroupsOfDigits.splice(i, 1);
    //    }
    //
    //}

    return (separatedGroupsOfDigits.join(' ')).trim();
}

console.log(giantWordNumberProcessor(33345356547));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(0));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(9));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(456));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(324));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(34));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(1234423));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(100000000));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(100000001));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(100000000111));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(100000005001));
console.log('-------------------------------------------------');
console.log(giantWordNumberProcessor(10000023420001));

function numberAsWords(targetNumber) // Fix for zero // Fixed elsewhere. Fix unneeded here
{
    // if (targetNumber === 0) {
    // 	return 'Zero';
    // }

    var visualiser = [hundreds, dozens, digits],
        digitsStr = String(targetNumber),
        length = digitsStr.length,
        andOrNot = false,
        result = '',
        visualisedItem,
        teen,
        i;

    if (length > 3 || length < 1 || isNaN(targetNumber))
    {

        return ('Only numbers in the range 0-999 are supported. Please input a valid number');
    }

    if (digitsStr[length - 2] !== '1')
    { // Construct string automatically if no "teen" number is found

        for (i = 0; i < length; i += 1)
        {
            // First line gets a word for each digit, second line decides whether to put a line or an "and" at the back of the word and the third line adds finalised word to final string
            visualisedItem = visualiser[visualiser.length - i - 1](digitsStr[length - i - 1], andOrNot); // Yes, yes terrible code. It's a bit early in JS and I still don't know a better way. Suggestions for improvements are very appreciated :)
            if (visualisedItem) andOrNot = true;
            result = visualisedItem + '' + result;
        }
    }
    else
    { // Construct string manually if number between 10 and 19 inclusive is found

        teen = (digitsStr[length - 2] + '' + digitsStr[length - 1]);
        result = teens(teen);
        if (length > 2)
        {
            result = hundreds(digitsStr[0]) + 'and ' + result;
        }
    }

    return result.trim();

    function digits(digit)
    {
        switch (digit)
        {
            case '1':
                return 'one ';
            case '2':
                return 'two ';
            case '3':
                return 'three ';
            case '4':
                return 'four ';
            case '5':
                return 'five ';
            case '6':
                return 'six ';
            case '7':
                return 'seven ';
            case '8':
                return 'eight ';
            case '9':
                return 'nine ';
            case '0':
            default:
                return '';
        }
    }

    function dozens(digit, areThereTrailingNumbers)
    {
        var lineOrEmpty = (areThereTrailingNumbers ? '-' : ' ');
        switch (digit)
        {
            case '1':
                return 'one' + lineOrEmpty;
            case '2':
                return 'twenty' + lineOrEmpty;
            case '3':
                return 'thirty' + lineOrEmpty;
            case '4':
                return 'forty' + lineOrEmpty;
            case '5':
                return 'fifty' + lineOrEmpty;
            case '6':
                return 'sixty' + lineOrEmpty;
            case '7':
                return 'seventy' + lineOrEmpty;
            case '8':
                return 'eighty' + lineOrEmpty;
            case '9':
                return 'ninety' + lineOrEmpty;
            case '0':
            default:
                return '';
        }
    }

    function hundreds(digit, areThereTrailingNumbers)
    {
        var andOrEmpty = (areThereTrailingNumbers ? 'and ' : '');
        switch (digit)
        {
            case '1':
                return 'one-hundred ' + andOrEmpty;
            case '2':
                return 'two-hundred ' + andOrEmpty;
            case '3':
                return 'three-hundred ' + andOrEmpty;
            case '4':
                return 'four-hundred ' + andOrEmpty;
            case '5':
                return 'five-hundred ' + andOrEmpty;
            case '6':
                return 'six-hundred ' + andOrEmpty;
            case '7':
                return 'seven-hundred ' + andOrEmpty;
            case '8':
                return 'eight-hundred ' + andOrEmpty;
            case '9':
                return 'nine-hundred ' + andOrEmpty;
            case '0':
            default:
                return '';
        }
    }

    function teens(digits)
    {
        switch (digits)
        {
            case '10':
                return 'ten ';
            case '11':
                return 'eleven ';
            case '12':
                return 'twelve ';
            case '13':
                return 'thirteen ';
            case '14':
                return 'fourteen ';
            case '15':
                return 'fifteen ';
            case '16':
                return 'sixteen ';
            case '17':
                return 'seventeen ';
            case '18':
                return 'eighteen ';
            case '19':
                return 'nineteen ';
            default:
                return '';
        }
    }
}
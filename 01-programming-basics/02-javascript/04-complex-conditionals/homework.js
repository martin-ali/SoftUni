// jshint esversion:6

function greetingBasedOnAgeAndGender([age, gender])
{
    if (gender === 'm')
    {
        if (age < 16)
        {
            return 'master';
        }
        else
        {
            return 'Mr.';
        }
    }
    else
    {
        if (age < 16)
        {
            return 'Miss';
        }
        else
        {
            return 'Ms.';
        }
    }
}

// console.log(greetingBasedOnAgeAndGender(['f', 47]));

function smallShop([product, city, quantity])
{
    let prices = {
        sofia:
        {
            coffee: 0.5,
            water: 0.8,
            beer: 1.2,
            sweets: 1.45,
            peanuts: 1.6
        },
        plovdiv:
        {
            coffee: 0.4,
            water: 0.7,
            beer: 1.15,
            sweets: 1.3,
            peanuts: 1.5
        },
        varna:
        {
            coffee: 0.45,
            water: 0.7,
            beer: 1.1,
            sweets: 1.35,
            peanuts: 1.55
        }
    };

    let sum = prices[city.toLowerCase()][product] * quantity;
    return sum;
}

// console.log(smallShop(['coffee', 'Varna', 2]));

function pointInRectangle([ry1, rx1, ry2, rx2, py, px])
{
    let horizonalBoundIsInRectangle = rx1 <= px && px <= rx2;
    let verticalBoundIsInRectangle = ry1 <= py && py <= ry2;

    let pointIsInRectangle = horizonalBoundIsInRectangle && verticalBoundIsInRectangle;
    let whetherPointIsInRectangleFormatted = pointIsInRectangle ? 'inside' : 'outside';
    return whetherPointIsInRectangleFormatted;
}

console.log(pointInRectangle([2, -3, 12, 3, 8, -1]));
console.log(pointInRectangle([2, -3, 12, 3, 12, 3]));
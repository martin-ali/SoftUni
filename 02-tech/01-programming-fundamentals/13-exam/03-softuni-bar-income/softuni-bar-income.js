// jshint esversion:6
function solve(orders)
{
    // %([A-Z][a-z]+)%.*<(\w+)>.*\|(\d+)\|\D*(\d+(\.\d+)?)\$
    orders.pop();
    let income = 0;
    var namePattern = '%([A-Z][a-z]+)%';
    var productPattern = '<(\\w+)>';
    var countPattern = '\\|(\\d+)\\|';
    var pricePattern = '(\\d+(\\.\\d+)?)\\$';
    var validOrderRegex = new RegExp(`${namePattern}.*${productPattern}.*${countPattern}\\D*${pricePattern}`);

    for (const order of orders)
    {
        const match = validOrderRegex.exec(order);
        if (match)
        {
            const [_, customer, product, quantity, price] = match;
            const bill = (+price) * (+quantity);

            console.log(`${customer}: ${product} - ${bill.toFixed(2)}`);

            income += bill;
        }
    }

    console.log(`Total income: ${income.toFixed(2)}`);
}

// solve([
//     '%George%<Croissant>|2|10.3$',
//     '%Peter%<Gum>|1|1.3$',
//     '%Maria%<Cola>|1|2.4$',
//     'end of shift'
// ]);

// solve([
//     '%InvalidName%<Croissant>|2|10.3$',
//     '%Peter%<Gum>1.3$',
//     '%Maria%<Cola>|1|2.4',
//     '%Valid%<Valid>valid|10|valid20$',
//     'end of shift'
// ]);
function printOrdersStatus(orders)
{
    function processOrder(money, drink, extras, sugar)
    {
        const pricing = {
            tea: 0.8,
            coffee: 0.8,
            caffeine: 0.0,
            decaf: 0.1,
            milk: 0.1
        };

        let price = pricing[drink];
        for (const extra of extras)
        {
            price += pricing[extra];
        }

        if (sugar > 0)
        {
            price += 0.1;
        }

        price = price.toFixed(2);
        const moneyIsEnough = money >= price;
        if (moneyIsEnough)
        {
            const change = (money - price)
                .toFixed(2);
            return `You ordered ${drink}. Price: $${price} Change: $${change}`;
        }
        else
        {
            const moneyNeeded = (price - money)
                .toFixed(2);
            return `Not enough money for ${drink}. Need $${moneyNeeded} more.`;
        }
    }

    for (const order of orders)
    {
        const parameters = order.split(", ");
        const money = parseFloat(parameters.shift());
        const drink = parameters.shift();
        const sugar = parameters.pop();
        const extras = parameters;

        const message = processOrder(money, drink, extras, sugar);

        console.log(message);
    }
}
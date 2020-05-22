function solution()
{
    const quantityByMicroelementType = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    function manage(input)
    {
        const [command, item, quantityText] = input.split(' ');
        const microelementsInOrder = ['protein', 'carbohydrate', 'fat', 'flavour']
        const recipes = {
            apple: [0, 1, 0, 2],
            lemonade: [0, 10, 0, 20],
            burger: [0, 5, 7, 3],
            eggs: [5, 0, 1, 1],
            turkey: [10, 10, 10, 10],
        };
        let status = 'Success';

        if (command === 'report')
        {
            return microelementsInOrder
                .map(microelement => `${microelement}=${quantityByMicroelementType[microelement]}`)
                .join(' ');
        }
        else if (command === 'restock')
        {
            const quantity = parseInt(quantityText, 10);

            quantityByMicroelementType[item] += quantity;

            return status;
        }
        else if (command === 'prepare')
        {
            const quantity = parseInt(quantityText, 10);
            const recipe = Array.from(recipes[item]);

            for (const microelement of microelementsInOrder)
            {
                const required = recipe.shift() * quantity;
                const available = quantityByMicroelementType[microelement];

                if (required > available)
                {
                    status = `Error: not enough ${microelement} in stock`
                    return status;
                }

                recipe.push(required / quantity);
            }

            for (const microelement of microelementsInOrder)
            {
                const required = recipes[item].shift() * quantity;
                quantityByMicroelementType[microelement] -= required;
            }

            return status;
        }
    }

    return manage;
}

// const manager = solution();
// console.log(manager('restock carbohydrate 10'));
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare apple 1'));
// console.log(manager('restock fat 10'));
// console.log(manager('prepare burger 1'));
// console.log(manager('report'));

const manager = solution();
console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));
function printStoreCatalogue(productsData)
{
    const productsInfoByFirstCharacter = new Map();
    const characters = new Set();

    for (const productData of productsData)
    {
        const [product, quantity] = productData.split(' : ');
        const firstCharacter = product[0];
        const productInformation = `${product}: ${quantity}`;

        if (characters.has(firstCharacter) === false)
        {
            characters.add(firstCharacter);
            productsInfoByFirstCharacter.set(firstCharacter, []);
        }

        productsInfoByFirstCharacter.get(firstCharacter).push(productInformation);
    }

    const orderedCharacters = Array.from(characters.values()).sort();
    for (const character of orderedCharacters)
    {
        console.log(character);

        const orderedProductsInfo = productsInfoByFirstCharacter.get(character);
        orderedProductsInfo.sort();

        for (const product of orderedProductsInfo)
        {
            console.log(product);
        }
    }
}

printStoreCatalogue(['Appricot : 20.4', 'Fridge : 1500', 'TV : 1499', 'Deodorant : 10', 'Boiler : 300', 'Apple : 1.25', 'Anti-Bug Spray : 15', 'T-Shirt : 10']);
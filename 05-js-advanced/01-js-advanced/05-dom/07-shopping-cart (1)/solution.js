function solve()
{
    const checkoutButton = document.getElementsByClassName('checkout')[0];
    const productsDivs = document.getElementsByClassName('product');
    const shoppingCartArea = document.getElementsByTagName('textarea')[0];
    const uniqueProducts = new Set();
    let total = 0;

    checkoutButton.addEventListener('click', event =>
    {
        const products = Array.from(uniqueProducts);
        const message = `You bought ${products.join(', ')} for ${total.toFixed(2)}.`;

        shoppingCartArea.value += message;

        const buttons = document.getElementsByTagName('button');
        for (const button of buttons)
        {
            button.disabled = true;
        }
    });

    for (const productDiv of Array.from(productsDivs))
    {
        const product = productDiv.getElementsByClassName('product-title')[0].textContent;
        const price = parseFloat(productDiv.getElementsByClassName('product-line-price')[0].textContent);
        const addButton = productDiv.getElementsByTagName('button')[0];

        addButton.addEventListener('click', event =>
        {
            const message = `Added ${product} for ${price.toFixed(2)} to the cart.\n`;

            shoppingCartArea.value += message;

            uniqueProducts.add(product);
            total += price;
        });
    }
}
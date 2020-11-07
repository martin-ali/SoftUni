function solve()
{
    function createLi(product)
    {
        const li = document.createElement('li');
        li.innerHTML = `<span>${product.name}</span>` +
            `<strong>Available: ${product.quantity}</strong>` +
            '<div>' +
            `<strong>${product.price}</strong>` +
            '<button>Add to Client\'s List</button>' +
            '</div>';

        return li;
    }

    const products = [];
    const addProductButton = document.querySelector('#add-new button');

    addProductButton.addEventListener('click', event =>
    {
        const product = {};
        const propertyInputs = document.getElementById('add-new').querySelectorAll('input');

        for (const input of propertyInputs)
        {
            const property = input.placeholder.toLowerCase();

            product[property] = input.value;
        }

        products.push(product);

        const productsUl = document.querySelector('#myProducts ul');
        productsUl.innerHTML = '';

        for (const product of products)
        {
            const li = createLi(product);

            productsUl.appendChild(li);
            console.log(1);
        }
    });

    const filterButton = document.querySelector('.filter button');

    filterButton.addEventListener('click', event =>
    {
        const filterInput = document.getElementById('filter');
        const filterItem = filterInput.value.toLowerCase();

        const filteredProducts = products.filter(p => p.name.toLowerCase().includes(filterItem));
        const productsUl = document.querySelector('#myProducts ul');
        productsUl.innerHTML = '';

        for (const product of filteredProducts)
        {
            const li = createLi(product);

            productsUl.appendChild(li);
            console.log(1);
        }
    });
}
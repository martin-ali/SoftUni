class Kitchen
{
    constructor(budget)
    {
        /** @type {number} */
        this.budget = budget;
        /** @type {string[]} */
        this.actionsHistory = [];
        // /** @type {string[]} */
        this.productsInStock = {};
        /** @type {{ name: string; products: { name: string; quantity: number; }[]; price: number; }[]} */
        this.menu = [];
    }

    /**
     * @param {string[]} products
     */
    loadProducts(products)
    {
        for (const productText of products)
        {
            const product = Kitchen.parseProduct(productText);

            if (this.budget < product.price)
            {
                this.actionsHistory.push(`There was not enough money to load ${product.quantity} ${product.name}`);
                continue;
            }

            if (this.productsInStock[product.name])
            {
                this.productsInStock[product.name].quantity += product.quantity;
            }
            else
            {
                this.productsInStock[product.name] = product;
            }

            this.actionsHistory.push(`Successfully loaded ${product.quantity} ${product.name}`);
            this.budget -= product.price;
        }

        return this.actionsHistory.join('\n');
    }

    /**
     * @param { string } mealName
     * @param {string[]} productsNeeded
     * @param {number} price
     */
    addToMenu(mealName, productsNeeded, price)
    {
        if (this.menu.some(m => m.name === mealName))
        {
            return `The ${mealName} is already in our menu, try something different.`
        }

        const products = [];
        for (const productText of productsNeeded)
        {
            const [name, quantityText] = productText.split(' ');
            const quantity = parseInt(quantityText);

            const product = { name, quantity };

            products.push(product);
        }

        const meal = { name: mealName, products, price };
        this.menu.push(meal);

        return `Great idea! Now with the ${mealName} we have ${this.menu.length} meals in the menu, other ideas?`;
    }

    showTheMenu()
    {
        if (this.menu.length === 0)
        {
            return 'Our menu is not ready yet, please come later...';
        }

        const meals = [];

        for (const meal of this.menu)
        {
            meals.push(`${meal.name} - ${meal.price}\n`);
        }

        return this.menu.join('\n');
    }

    makeTheOrder(mealName)
    {
        const meal = this.menu.find(m => m.name === mealName);

        if (meal && meal.products.every(p => this.productsInStock[p.name].quantity >= p.quantity))
        {
            this.budget += meal.price;
            for (const product of meal.products)
            {
                this.productsInStock[product.name].quantity -= product.quantity;
            }

            return `Your order (${meal.name}) will be completed in the next 30 minutes and will cost you ${meal.price}.`;
        }
        else if (meal) // Not enough products
        {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }
        else // Meal not available
        {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
    }

    /**
     * @param {string} productText
     */
    static parseProduct(productText)
    {
        const [name, quantityText, priceText] = productText.split(' ');
        const quantity = parseInt(quantityText);
        const price = parseFloat(priceText);

        return { name, quantity, price };
    }
}

// let kitchen = new Kitchen(1000);
// console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

// console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
// console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

// console.log(kitchen.showTheMenu());
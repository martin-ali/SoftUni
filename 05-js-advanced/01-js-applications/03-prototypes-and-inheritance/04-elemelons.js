function solve()
{
    class Melon
    {
        // weight;
        // melonSort;

        constructor(weight, melonSort)
        {
            if (new.target === Melon)
            {
                throw new Error('Abstract class cannot be instantiated directly');
            }

            this.weight = weight;
            this.melonSort = melonSort;
        }

        get elementIndex()
        {
            return this.weight * this.melonSort.length;
        }

        get element()
        {
            return this.constructor.name.replace('melon', '');
        }

        toString()
        {
            const result = `Element: ${this.element}\n`
                + `Sort: ${this.melonSort}\n`
                + `Element Index: ${this.elementIndex}`;

            return result;
        }
    }

    class Watermelon extends Melon
    {
        constructor(weight, melonSort)
        {
            super(weight, melonSort);
        }
    }

    class Firemelon extends Melon
    {
        constructor(weight, melonSort)
        {
            super(weight, melonSort);
        }
    }

    class Earthmelon extends Melon
    {
        constructor(weight, melonSort)
        {
            super(weight, melonSort);
        }
    }

    class Airmelon extends Melon
    {
        constructor(weight, melonSort)
        {
            super(weight, melonSort);
        }
    }

    class Melolemonmelon extends Watermelon
    {
        // Not happy with the way I solved this
        elements = ['Water', 'Fire', 'Earth', 'Air'];

        constructor(weight, melonSort)
        {
            super(weight, melonSort);
        }

        get element()
        {
            return this.elements[0];
        }

        morph()
        {
            const currentElement = this.elements.shift();

            this.elements.push(currentElement);
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon
    }
}
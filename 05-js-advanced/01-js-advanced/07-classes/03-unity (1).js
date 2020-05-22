class Rat
{
    name;
    unitedRats;

    constructor(name)
    {
        this.name = name;
        this.unitedRats = [];
    }

    unite(newRat)
    {
        if (newRat instanceof Rat === false)
        {
            return;
        }

        this.unitedRats.push(newRat)
    }

    getRats()
    {
        return this.unitedRats;
    }

    toString()
    {
        let stringRepresentation = `${this.name}\n`;

        for (const rat of this.unitedRats)
        {
            stringRepresentation += `##${rat.name}\n`;
        }

        return stringRepresentation;
    }
}
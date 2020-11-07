class List
{
    items;
    size;

    constructor()
    {
        this.items = [];
        this.size = 0;
    }

    throwIfInvalidIndex(index)
    {
        const indexIsValid = 0 <= index && index < this.items.length;
        if (indexIsValid === false)
        {
            throw new Error('Invalid index!');
        }
    }

    sort()
    {
        this.items.sort((a, b) => a - b);
    }

    add(item)
    {
        this.items.push(parseFloat(item));
        ++this.size;

        this.sort();
    }

    remove(index)
    {
        this.throwIfInvalidIndex(index);

        this.items.splice(index, 1);
        --this.size;

        this.sort();
    }

    get(index)
    {
        this.throwIfInvalidIndex(index);

        return this.items[index];
    }
}
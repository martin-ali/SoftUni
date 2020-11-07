class Hex
{
    value;

    constructor(value)
    {
        this.value = value;
    }

    valueOf()
    {
        return this.value;
    }

    plus(number)
    {
        let newValue = this.value;
        if (typeof number === 'object')
        {
            newValue += number.valueOf();
        }
        else
        {
            newValue += number;
        }

        return new Hex(newValue);
    }

    minus(number)
    {
        let newValue = this.value;
        if (typeof number === 'object')
        {
            newValue -= number.valueOf();
        }
        else
        {
            newValue -= number;
        }

        return new Hex(newValue);
    }

    parse(hexNumber)
    {
        return new Hex(parseInt(hexNumber, 16));
    }

    toString()
    {
        return `0x${this.value.toString(16).toUpperCase()}`;
    }
}
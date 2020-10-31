class Stringer
{
    innerString;
    initialLength;
    innerLength;

    constructor(string, length)
    {
        this.innerString = string;
        this.initialLength = length;
        this.innerLength = length;
    }

    increase(length)
    {
        this.innerLength += length;
    }

    decrease(length)
    {
        this.innerLength -= length;

        this.innerLength = Math.max(0, this.innerLength);
    }

    toString()
    {
        let outerString = this.innerString.substring(0, this.innerLength);
        console.log(`outerString: ${outerString}`);
        console.log(`length: ${this.innerLength}`);

        if (this.innerLength < this.initialLength)
        {
            outerString += '...';
        }

        return outerString;
    }
}
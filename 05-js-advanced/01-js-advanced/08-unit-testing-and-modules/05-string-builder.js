class StringBuilder
{
    constructor(string)
    {
        if (string !== undefined)
        {
            StringBuilder._verifyParam(string);
            this._stringArray = Array.from(string);
        }
        else
        {
            this._stringArray = [];
        }
    }

    append(string)
    {
        StringBuilder._verifyParam(string);
        for (let i = 0; i < string.length; i++)
        {
            this._stringArray.push(string[i]);
        }
    }

    prepend(string)
    {
        StringBuilder._verifyParam(string);
        for (let i = string.length - 1; i >= 0; i--)
        {
            this._stringArray.unshift(string[i]);
        }
    }

    insertAt(string, startIndex)
    {
        StringBuilder._verifyParam(string);
        this._stringArray.splice(startIndex, 0, ...string);
    }

    remove(startIndex, length)
    {
        this._stringArray.splice(startIndex, length);
    }

    static _verifyParam(param)
    {
        if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }


    toString()
    {
        return this._stringArray.join('');
    }
}
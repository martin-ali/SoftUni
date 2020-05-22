(function ()
{
    String.prototype.ensureStart = function (start)
    {
        if (!this.startsWith(start))
        {
            return `${start}${this}`;
        }

        return this.slice(0);
    };

    String.prototype.ensureEnd = function (end)
    {
        if (!this.endsWith(end))
        {
            return `${this}${end}`;
        }

        return this.slice();
    };

    String.prototype.isEmpty = function ()
    {
        return this.length === 0;
    };

    String.prototype.truncate = function (n)
    {
        if (n <= 3)
        {
            return '.'.repeat(n);
        }
        else if (this.length <= n && this.includes(' '))
        {
            return this.slice(0);
        }
        else if (!this.includes(' '))
        {
            return `${this.substring(0, this.length - 3)}...`;
        }

        let truncatedText = '';
        const words = this.split(' ');

        while (truncatedText.length + words[0].length + 3 <= n)
        {
            truncatedText = `${truncatedText} ${words.shift()}`;
        }

        truncatedText += `...`;

        return truncatedText.trim();

    };

    // Static
    String.format = function (string, ...params)
    {
        return string.replace(/{.+?}/g, (match) =>
        {
            const index = parseInt(match.replace(/{|}/g, ''));

            if (index < params.length)
            {
                return params[index];
            }
            else
            {
                return match;
            }
        });
    };
})()

// console.log(String.format('{0} {1} {1} {2} {33}', 'x', 'y', 'z'));

// const testString = 'quick brown fox jumps over the lazy dog';
// testString = testString.ensureStart('the ');
// testString = testString.ensureStart('the ');
// testString = testString.ensureStart('the ');

// console.log('testString');

// console.log(''.isEmpty());

// var testString = 'the quick brown fox jumps over the lazy dog';
// // console.log(testString.truncate(10));
// // console.log(testString.truncate(25));
// console.log(testString.truncate(43));
// console.log(testString.truncate(45));
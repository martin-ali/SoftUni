(function ()
{
    Array.prototype.last = function ()
    {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (count)
    {
        return this.slice(count);
    }

    Array.prototype.take = function (count)
    {
        return this.slice(0, count);
    }

    Array.prototype.sum = function ()
    {
        return this.reduce((sum, x) => sum + x, 0);
    }

    Array.prototype.average = function ()
    {
        return this.sum() / this.length;
    }
})();

// const arr = [1, 2, 3, 4];

// console.log(arr.last());
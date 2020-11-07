(function ()
{
    class Extensible
    {
        id;

        constructor()
        {
            this.id = getId.next().value;
        }

        extend(template)
        {
            // Object.assign(this, template);
            for (const property in template)
            {
                if (typeof template[property] === 'function')
                {
                    Extensible.prototype[property] = template[property];
                }
                else
                {
                    this[property] = template[property];
                }
            }
        }
    }

    function* getIdIterator()
    {
        let id = 0;
        while (true)
        {
            yield id;
            id++;
        }
    }

    const getId = getIdIterator();

    return Extensible;
})()
function getCarByRequirements()
{
    function extend(template)
    {
        for (const property in template)
        {
            if (typeof template[property] === 'function')
            {
                Object.getPrototypeOf(this)[property] = template[property];
                // this.__proto__[property] = template[property];
            }
            else
            {
                this[property] = template[property];
            }
        }
    }

    return {
        __proto__: {},
        extend
    };
}

// var template = {
//     extensionMethod: function ()
//     {
//         console.log("From extension method")
//     }
// };

// const extensible = getCarByRequirements();
// extensible.extend(template);
// console.log(extensible);
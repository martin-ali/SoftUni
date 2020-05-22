function getSortedList()
{
    const items = [];
    const sortedList = {
        size: 0,
        _throwIfIndexIsInvalid: function (index)
        {
            const indexIsValid = 0 <= index && index < this.size;
            if (!indexIsValid)
            {
                throw new Error();
            }
        },
        add: function (element)
        {
            items.push(element);

            this.size++;

            items.sort((a, b) => +a - +b);
        },
        remove: function (index)
        {
            this._throwIfIndexIsInvalid(index);

            items.splice(index, 1);

            this.size--;
        },
        get: function (index)
        {
            this._throwIfIndexIsInvalid(index);

            return items[index];
        }
    };

    return sortedList;
}

// const list = getSortedList();
// console.log(list);
// list.add(1);
// list.add(7);
// list.add(5);
// list.add(2);
// list.add(4);
// list.add(3);
// list.add(6);
// console.log(list);
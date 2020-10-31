function shift(items)
{
    const rotationsCount = items.pop() % items.length;

    for (let rotations = 1; rotations <= rotationsCount; rotations++)
    {
        const lastElement = items.pop();

        items.unshift(lastElement);
    }

    return items.join(" ");
}
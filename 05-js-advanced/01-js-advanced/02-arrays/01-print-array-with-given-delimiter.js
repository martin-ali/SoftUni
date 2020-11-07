function join(parameters)
{
    const delimiter = parameters.pop();
    const items = parameters;

    return items.join(delimiter);
}
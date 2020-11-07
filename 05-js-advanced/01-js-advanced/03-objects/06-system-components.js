function solve(componentsInput)
{
    const subcomponentsByComponentBySystem = new Map();

    for (const componentsData of componentsInput)
    {
        const [system, component, subcomponent] = componentsData.split(' | ');

        if (subcomponentsByComponentBySystem.has(system) === false)
        {
            subcomponentsByComponentBySystem.set(system, new Map());
        }

        if (subcomponentsByComponentBySystem.get(system).has(component) === false)
        {
            subcomponentsByComponentBySystem.get(system).set(component, new Set());
        }

        subcomponentsByComponentBySystem
            .get(system)
            .get(component)
            .add(subcomponent);
    }

    const sortBySizeThenAlphabetically = ([aKey, aValue], [bKey, bValue]) =>
    {
        if (aValue.size !== bValue.size)
        {
            return bValue.size - aValue.size;
        }
        else
        {
            return aKey.localeCompare(bKey, undefined, { sensitivity: 'case' });
        }
    };

    const sortedSystems = Array.from(subcomponentsByComponentBySystem);
    sortedSystems.sort(sortBySizeThenAlphabetically);

    for (const [system, components] of sortedSystems)
    {
        console.log(system);

        const sortedComponents = Array.from(components);
        sortedComponents.sort(sortBySizeThenAlphabetically);

        for (const [component, subcomponents] of sortedComponents)
        {
            console.log(`|||${component}`);

            for (const subcomponent of subcomponents)
            {
                console.log(`||||||${subcomponent}`);
            }
        }
    }
}
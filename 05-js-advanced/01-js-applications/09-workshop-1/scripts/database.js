class Database
{
    api;
    resource;

    constructor(api, resource)
    {
        this.api = api;
        this.resource = resource;
    }

    async create(data, token)
    {
        const response = await fetch(`${this.api}/${this.resource}.json?auth=${token}`,
        {
            method: 'POST',
            body: JSON.stringify(data)
        });

        return response;
    }

    async getById(id, token)
    {
        const response = await fetch(`${this.api}/${this.resource}/${id}.json?auth=${token}`);
        const object = await response.json();

        return object;
    }

    async getAll(token)
    {
        const response = await fetch(`${this.api}/${this.resource}.json?auth=${token}`);
        const objectById = await response.json();

        const objects = [];
        for (const id in objectById)
        {
            const item = objectById[id];
            item.id = id;

            objects.push(item);
        }

        return objects;
    }

    async updateById(data, id, token)
    {
        const response = await fetch(`${this.api}/${this.resource}/${id}.json?auth=${token}`,
        {
            method: 'PUT',
            body: JSON.stringify(data)
        });

        return response;
    }

    async patchById(data, id, token)
    {
        const response = await fetch(`${this.api}/${this.resource}/${id}.json?auth=${token}`,
        {
            method: 'PATCH',
            body: JSON.stringify(data)
        });

        return response;
    }

    async deleteById(id, token)
    {
        const response = await fetch(`${this.api}/${this.resource}/${id}.json?auth=${token}`,
        {
            method: 'DELETE'
        });

        return response;
    }
}

export default Database;
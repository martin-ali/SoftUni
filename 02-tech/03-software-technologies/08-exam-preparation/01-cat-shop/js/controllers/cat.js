// jshint esversion:6
const Cat = require('../models').Cat;

module.exports = {
    index: async (request, response) =>
    {
        const cats = await Cat.findAll()

        response.render("cat/index", { cats })
    },

    createGet: async (request, response) =>
    {
        response.render('cat/create');
    },

    createPost: async (request, response) =>
    {
        const catArguments = request.body;
        const { name, nickname, price } = catArguments.cat;

        let errorMessage = '';
        if (!name)
        {
            errorMessage = 'Invalid name!';
        }
        else if (!nickname)
        {
            errorMessage = 'Invalid nickname!';
        }
        else if (!price)
        {
            errorMessage = 'Invalid price!';
        }

        if (errorMessage)
        {
            response.render('cat/create', { error: errorMessage, cat: catArguments });
            return;
        }

        try
        {
            await Cat.create(catArguments.cat);
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('cat/create', { error: error.message, cat: catArguments });
        }
    },

    editGet: async (request, response) =>
    {
        const id = request.params.id;

        const cat = await Cat.findById(id);
        if (!cat)
        {
            const errorMessage = 'Cat does not exist';
            response.render('cat/edit', { error: errorMessage, cat: cat.dataValues });
        }

        response.render('cat/edit', { cat: cat.dataValues });
    },

    editPost: async (request, response) =>
    {
        const catArguments = request.body;
        const { name, nickname, price } = catArguments.cat;
        const id = request.params.id;

        const cat = await Cat.findById(id);

        if (!cat)
        {
            const errorMessage = 'Cat does not exist';
            response.render('cat/edit', { error: errorMessage, cat: catArguments.cat });
        }

        let errorMessage = '';
        if (!name)
        {
            errorMessage = 'Invalid name!';
        }
        else if (!nickname)
        {
            errorMessage = 'Invalid nickname!';
        }
        else if (!price)
        {
            errorMessage = 'Invalid price!';
        }

        if (errorMessage)
        {
            response.render('cat/edit', { error: errorMessage, cat: catArguments.cat });
            return;
        }

        try
        {
            Cat.update({ name, nickname, price }, { where: { id }, returning: true });
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('cat/edit', { cat: catArguments.cat });
        }
    },

    deleteGet: async (request, response) =>
    {
        const id = request.params.id;

        const cat = await Cat.findById(id);
        if (!cat)
        {
            const errorMessage = 'Cat does not exist';
            response.render('cat/delete', { error: errorMessage, cat: cat.dataValues });
        }

        response.render('cat/delete', { cat: cat.dataValues });
    },

    deletePost: async (request, response) =>
    {
        const catArguments = request.body;
        const { name, nickname, price } = catArguments.cat;
        const id = request.params.id;

        const cat = await Cat.findById(id);

        if (!cat)
        {
            const errorMessage = 'Cat does not exist';
            response.render('cat/delete', { error: errorMessage, cat: catArguments.cat });
        }

        let errorMessage = '';
        if (!name)
        {
            errorMessage = 'Invalid name!';
        }
        else if (!nickname)
        {
            errorMessage = 'Invalid nickname!';
        }
        else if (!price)
        {
            errorMessage = 'Invalid price!';
        }

        if (errorMessage)
        {
            response.render('cat/delete', { error: errorMessage, cat: catArguments.cat });
            return;
        }

        try
        {
            Cat.destroy({ where: { id } });
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('cat/delete', { error: error.message, cat: catArguments.cat });
        }
    }
};
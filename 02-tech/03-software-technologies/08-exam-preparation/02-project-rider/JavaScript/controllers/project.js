const Project = require('../models').Project;

module.exports = {
    index: async (request, response) =>
    {
        const projects = await Project.findAll()

        response.render("project/index", { projects })
    },

    createGet: async (request, response) =>
    {
        response.render('project/create');
    },

    createPost: async (request, response) =>
    {
        const projectArguments = request.body;
        const { title, description, budget } = projectArguments.project;

        try
        {
            await Project.create(projectArguments.project);
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('project/create', { error: error.message, project: projectArguments });
        }
    },

    editGet: async (request, response) =>
    {
        const id = request.params.id;

        const project = await Project.findById(id);
        if (!project)
        {
            const errorMessage = 'Project does not exist';
            response.render('project/edit', { error: errorMessage, project: project.dataValues });
        }

        response.render('project/edit', { project: project.dataValues });
    },

    editPost: async (request, response) =>
    {
        const projectArguments = request.body;
        const { title, description, budget } = projectArguments.project;
        const id = request.params.id;

        const project = await Project.findById(id);

        if (!project)
        {
            const errorMessage = 'Project does not exist';
            response.render('project/edit', { error: errorMessage, project: projectArguments.project });
        }

        try
        {
            Project.update({ title, description, budget }, { where: { id }, returning: true });
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('project/edit', { project: projectArguments.project });
        }
    },

    deleteGet: async (request, response) =>
    {
        const id = request.params.id;

        const project = await Project.findById(id);
        if (!project)
        {
            const errorMessage = 'Project does not exist';
            response.render('project/delete', { error: errorMessage, project: project.dataValues });
        }

        response.render('project/delete', { project: project.dataValues });
    },

    deletePost: async (request, response) =>
    {
        const projectArguments = request.body;
        const { title, description, budget } = projectArguments.project;
        const id = request.params.id;

        const project = await Project.findById(id);

        if (!project)
        {
            const errorMessage = 'Project does not exist';
            response.render('project/delete', { error: errorMessage, project: projectArguments.project });
        }

        try
        {
            Project.destroy({ where: { id } });
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('project/delete', { error: error.message, project: projectArguments.project });
        }
    }
};
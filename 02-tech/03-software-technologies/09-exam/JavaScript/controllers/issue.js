const Issue = require('../models').Issue;

module.exports = {
    index: async (request, response) =>
    {
        const issues = await Issue.findAll()

        response.render("issue/index", { issues })
    },

    createGet: async (request, response) =>
    {
        response.render('issue/create');
    },

    createPost: async (request, response) =>
    {
        const issueArguments = request.body;

        try
        {
            await Issue.create(issueArguments.issue);
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('issue/create', { error: error.message, issue: issueArguments });
        }
    },

    editGet: async (request, response) =>
    {
        const id = request.params.id;

        const issue = await Issue.findById(id);
        if (!issue)
        {
            const errorMessage = 'Issue does not exist';
            response.render('issue/edit', { error: errorMessage, issue: issue.dataValues });
        }

        response.render('issue/edit', { issue: issue.dataValues });
    },

    editPost: async (request, response) =>
    {
        const issueArguments = request.body;
        const { title, content, priority } = issueArguments.issue;
        const id = request.params.id;

        const issue = await Issue.findById(id);

        if (!issue)
        {
            const errorMessage = 'Issue does not exist';
            response.render('issue/edit', { error: errorMessage, issue: issueArguments.issue });
        }

        try
        {
            Issue.update({ title, content, priority }, { where: { id }, returning: true });
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('issue/edit', { issue: issueArguments.issue });
        }
    },

    deleteGet: async (request, response) =>
    {
        const id = request.params.id;

        const issue = await Issue.findById(id);
        if (!issue)
        {
            const errorMessage = 'Issue does not exist';
            response.render('issue/delete', { error: errorMessage, issue: issue.dataValues });
        }

        response.render('issue/delete', { issue: issue.dataValues });
    },

    deletePost: async (request, response) =>
    {
        const issueArguments = request.body;
        const id = request.params.id;

        const issue = await Issue.findById(id);

        if (!issue)
        {
            const errorMessage = 'Issue does not exist';
            response.render('issue/delete', { error: errorMessage, issue: issueArguments.issue });
        }

        try
        {
            Issue.destroy({ where: { id } });
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('issue/delete', { error: error.message, issue: issueArguments.issue });
        }
    }
};
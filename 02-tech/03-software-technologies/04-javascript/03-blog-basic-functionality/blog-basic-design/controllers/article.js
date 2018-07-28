// jshint esversion:6
const Article = require('../models').Article;
const Comment = require('../models').Comment;
const User = require('../models').User;

const articleController = {
    createGet: (request, response) =>
    {
        response.render('article/create');
    },
    createPost: async (request, response) =>
    {
        const articleArguments = request.body;
        const { title, content } = articleArguments;

        let errorMessage = '';
        if (!request.isAuthenticated()) // Is there a logged user
        {
            errorMessage = 'You need to be logged in to create articles!';
        }
        else if (!title)
        {
            errorMessage = 'Invalid title!';
        }
        else if (!content)
        {
            errorMessage = 'Invalid content!';
        }

        if (errorMessage)
        {
            response.render('article/create', { error: errorMessage });
            return;
        }

        articleArguments.authorId = request.user.id;

        try
        {
            await Article.create(articleArguments);
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('article/create', { error: error.message });
        }
    },
    detailsGet: async (request, response) =>
    {
        const id = request.params.id;

        const article = await Article.findById(id, { include: [{ model: User }, { model: Comment, include: [{ model: User }] }] });
        if (!article)
        {
            const errorMessage = 'Article does not exist';

            response.render('/');
        }

        article.dataValues.userIsAuthor = (request.user && article.dataValues.authorId === request.user.id);
        article.dataValues.userLogged = !!request.user;
        response.render('article/details', article.dataValues);
    },
    editGet: async (request, response) =>
    {
        const id = request.params.id;

        const article = await Article.findById(id, { include: [{ model: User }, { model: Comment, include: [{ model: User }] }] });
        if (!article)
        {
            const errorMessage = 'Article does not exist';

            response.render('home/index', { error: errorMessage });
        }

        article.dataValues.userLogged = !!request.user;
        response.render('article/edit', article.dataValues);
    },
    editPost: async (request, response) =>
    {
        const articleArguments = request.body;
        const { title, content } = articleArguments;
        const id = request.params.id;

        const article = await Article.findById(id);
        const editorIsAuthor = (article.dataValues.authorId === request.user.id);
        let errorMessage = '';
        if (!request.isAuthenticated()) // Is there a logged user
        {
            errorMessage = 'You need to be logged in to edit articles!';
        }
        else if (!title)
        {
            errorMessage = 'Invalid title!';
        }
        else if (!content)
        {
            errorMessage = 'Invalid content!';
        }
        else if (!editorIsAuthor)
        {
            errorMessage = 'You can only edit your own articles!';
        }

        if (errorMessage)
        {
            response.render('article/create', { title, content, error: errorMessage });
            return;
        }

        try
        {
            await Article.update({ title, content }, { where: { id, authorId: request.user.id }, returning: true });
            response.redirect(`/article/details/${id}`);
        }
        catch (error)
        {
            console.error(error.message);
            response.render('article/edit', { title, content, error: error.message });
        }
    },
    deleteGet: async (request, response) =>
    {
        const id = request.params.id;

        const article = await Article.findById(id);
        if (!article)
        {
            const errorMessage = 'Article does not exist';

            response.render('home/index', { error: errorMessage });
        }

        article.dataValues.userLogged = !!request.user;
        response.render('article/delete', article.dataValues);
    },
    deletePost: async (request, response) =>
    {
        const articleArguments = request.body;
        const { title, content } = articleArguments;
        const id = request.params.id;

        const article = await Article.findById(id);
        const editorIsAuthor = request.user && (article.dataValues.authorId === request.user.id);
        let errorMessage = '';
        if (!request.isAuthenticated()) // Is there a logged user
        {
            errorMessage = 'You need to be logged in to remove articles!';
        }
        else if (!editorIsAuthor)
        {
            errorMessage = 'You can only delete your own articles!';
        }

        if (errorMessage)
        {
            response.render('article/delete', { title, content, error: errorMessage });
            return;
        }

        Comment.destroy({ where: { articleId: id } });
        // Comment.destroy({ where: { articleId: null } });

        try
        {
            await Article.destroy({ where: { id, authorId: request.user.id } });
            response.redirect('/');
        }
        catch (error)
        {
            console.error(error.message);
            response.render('article/delete', { title, content, error: error.message });
        }
    }
};

module.exports = articleController;
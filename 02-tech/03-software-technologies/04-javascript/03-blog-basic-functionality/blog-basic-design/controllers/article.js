// jshint esversion:6
const Article = require('../models').Article;
const Comment = require('../models').Comment;
const User = require('../models').User;

const articleController = {
    createGet: (request, response) =>
    {
        response.render('article/create');
    },
    createPost: (request, response) =>
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

        Article
            .create(articleArguments)
            .then((article) =>
            {
                response.redirect('/');
            })
            .catch((error) =>
            {
                console.error(error.message);
                response.render('article/create', { error: error.message });
            });
    },
    detailsGet: (request, response) =>
    {
        const id = request.params.id;

        Article
            .findById(id, { include: [{ model: User }, { model: Comment, include: [{ model: User }] }] })
            .then((article) =>
            {
                if (!article)
                {
                    const errorMessage = 'Article does not exist';

                    response.render('/');
                }

                article.dataValues.userIsAuthor = (request.hasOwnProperty('user') && article.dataValues.authorId === request.user.id);
                article.dataValues.userLogged = !!request.user;
                response.render('article/details', article.dataValues);
            });
    },
    editGet: (request, response) =>
    {
        const id = request.params.id;

        Article
            .findById(id, { include: [{ model: User }, { model: Comment, include: [{ model: User }] }] })
            .then((article) =>
            {
                if (!article)
                {
                    const errorMessage = 'Article does not exist';

                    response.render('home/index', { error: errorMessage });
                }

                article.dataValues.userLogged = !!request.user;
                response.render('article/edit', article.dataValues);
            });
    },
    editPost: (request, response) =>
    {
        const articleArguments = request.body;
        const { title, content } = articleArguments;
        const id = request.params.id;

        Article
            .findById(id)
            .then((article) =>
            {
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

                Article
                    .update({ title, content }, { where: { id, authorId: request.user.id }, returning: true })
                    .then((article) =>
                    {
                        response.redirect(`/article/details/${id}`);
                    })
                    .catch((error) =>
                    {
                        console.error(error.message);
                        response.render('article/edit', { title, content, error: error.message });
                    });
            });
    },
    deleteGet: (request, response) =>
    {
        const id = request.params.id;

        Article
            .findById(id)
            .then((article) =>
            {
                if (!article)
                {
                    const errorMessage = 'Article does not exist';

                    response.render('home/index', { error: errorMessage });
                }

                article.dataValues.userLogged = !!request.user;
                response.render('article/delete', article.dataValues);
            });
    },
    deletePost: (request, response) =>
    {
        const articleArguments = request.body;
        const { title, content } = articleArguments;
        const id = request.params.id;

        Article
            .findById(id)
            .then((article) =>
            {
                const editorIsAuthor = (article.dataValues.authorId === request.user.id);
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

                Article
                    .destroy({ where: { id, authorId: request.user.id } })
                    .then(() =>
                    {
                        response.redirect('/');
                    })
                    .catch((error) =>
                    {
                        console.error(error.message);
                        response.render('article/delete', { title, content, error: error.message });
                    });
            });
    }
};

module.exports = articleController;
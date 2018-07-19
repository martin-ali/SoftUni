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

                // article.dataValues -> article properties
                article.dataValues.userLogged = !!request.user;
                response.render('article/details', article.dataValues);
            });
    }
};

module.exports = articleController;
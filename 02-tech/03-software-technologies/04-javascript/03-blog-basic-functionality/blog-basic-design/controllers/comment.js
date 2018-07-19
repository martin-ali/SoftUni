// jshint esversion:6
const Comment = require('../models').Comment;
const User = require('../models').User;

const homeController = {
    createGet: (request, response) =>
    {
        response.render('comment/create', { articleId: request.params.id });
    },
    createPost: (request, response) =>
    {
        const commentArguments = request.body;
        const content = commentArguments.content;
        const articleId = request.params.id;

        let errorMessage = '';
        if (!request.isAuthenticated()) // Is there a logged user
        {
            errorMessage = 'You need to be logged in to create comments!';
        }
        else if (!content)
        {
            errorMessage = 'Invalid content!';
        }

        if (errorMessage)
        {
            console.log(errorMessage);
            response.render('comment/create', { error: errorMessage, content, articleId });
            return;
        }

        commentArguments.authorId = request.user.id;
        commentArguments.articleId = articleId;

        Comment
            .create(commentArguments)
            .then((comment) =>
            {
                response.redirect('/');
            })
            .catch((error) =>
            {
                console.error(error.message);
                response.render('comment/create', { error: error.message, content, articleId });
            });
    },
    detailsGet: (request, response) =>
    {

        const id = request.params.id;

        Comment
            .findById(id, { include: [{ model: User }] })
            .then((comment) =>
            {
                if (!comment)
                {
                    const errorMessage = 'Comment does not exist';

                    response.render('/');
                }

                response.render('comment/details', comment.dataValues);
            });

    }
};

module.exports = homeController;
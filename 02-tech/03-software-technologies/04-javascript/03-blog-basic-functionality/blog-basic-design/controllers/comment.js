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
            response.render('comment/create', { error: errorMessage, content, articleId });
            return;
        }

        commentArguments.authorId = request.user.id;
        commentArguments.articleId = articleId;

        Comment
            .create(commentArguments)
            .then((comment) =>
            {
                response.redirect(`/article/details/${articleId}`);
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

                comment.dataValues.userIsAuthor = (request.hasOwnProperty('user') && comment.dataValues.authorId === request.user.id);
                response.render('comment/details', comment.dataValues);
            });

    },
    editGet: (request, response) =>
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

                comment.dataValues.userIsAuthor = (request.hasOwnProperty('user') && comment.dataValues.authorId === request.user.id);
                comment.dataValues.userLogged = !!request.user;
                response.render('comment/edit', comment.dataValues);
            });
    },
    editPost: (request, response) =>
    {
        const articleArguments = request.body;
        const content = articleArguments.content;
        const id = request.params.id;

        Comment
            .findById(id)
            .then((comment) =>
            {
                const editorIsAuthor = (comment.dataValues.authorId === request.user.id);
                let errorMessage = '';
                if (!request.isAuthenticated()) // Is there a logged user
                {
                    errorMessage = 'You need to be logged in to edit comments!';
                }
                else if (!content)
                {
                    errorMessage = 'Invalid content!';
                }
                else if (!editorIsAuthor)
                {
                    errorMessage = 'You can only edit your own comments!';
                }

                if (errorMessage)
                {
                    response.render('comment/edit', { content, error: errorMessage });
                    return;
                }

                Comment
                    .update({ content }, { where: { id, authorId: request.user.id }, returning: true })
                    .then((comment) =>
                    {
                        response.redirect(`/comment/details/${id}`);
                    })
                    .catch((error) =>
                    {
                        console.error(error.message);
                        response.render('comment/edit', { content, error: error.message });
                    });
            });
    }
};

module.exports = homeController;
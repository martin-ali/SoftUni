// jshint esversion:6
const Comment = require('../models').Comment;
const User = require('../models').User;

const homeController = {
    createGet: async (request, response) =>
    {
        response.render('comment/create', { articleId: request.params.id });
    },
    createPost: async (request, response) =>
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

        try
        {
            const comment = await Comment.create(commentArguments);
            response.redirect(`/article/details/${articleId}`);
        }
        catch (error)
        {
            console.error(error.message);
            response.render('comment/create', { error: error.message, content, articleId });
        }
    },
    detailsGet: async (request, response) =>
    {

        const id = request.params.id;

        try
        {
            const comment = await Comment.findById(id, { include: [{ model: User }] });
            if (!comment)
            {
                const errorMessage = 'Comment does not exist';

                response.render('/');
            }

            comment.dataValues.userIsAuthor = (request.hasOwnProperty('user') && comment.dataValues.authorId === request.user.id);
            response.render('comment/details', comment.dataValues);
        }
        catch (error)
        {

        }

    },
    editGet: async (request, response) =>
    {
        const id = request.params.id;

        try
        {
            const comment = await Comment.findById(id, { include: [{ model: User }] });

            if (!comment)
            {
                const errorMessage = 'Comment does not exist';

                response.render('/');
            }

            comment.dataValues.userIsAuthor = (request.hasOwnProperty('user') && comment.dataValues.authorId === request.user.id);
            comment.dataValues.userLogged = !!request.user;
            response.render('comment/edit', comment.dataValues);
        }
        catch (error)
        {

        }
    },
    editPost: async (request, response) =>
    {
        const articleArguments = request.body;
        const content = articleArguments.content;
        const id = request.params.id;

        try
        {
            const comment = await Comment.findById(id);
            const editorIsAuthor = request.user && (comment.dataValues.authorId === request.user.id);
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

            await Comment.update({ content }, { where: { id, authorId: request.user.id }, returning: true });
            response.redirect(`/comment/details/${id}`);
        }
        catch (error)
        {
            console.error(error.message);
            response.render('comment/edit', { content, error: error.message });
        }
    }
};

module.exports = homeController;
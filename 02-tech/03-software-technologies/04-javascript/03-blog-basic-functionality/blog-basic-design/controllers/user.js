// jshint esversion:6
const User = require('../models').User;
const Article = require('../models').Article;
const Comment = require('../models').Comment;
const date = require('../utilities/date');
const encryption = require('../utilities/encryption');

const userController = {
    detailsGet: (request, response) =>
    {
        const id = request.params.id;
        User
            .findById(id, { include: [{ model: Article }, { model: Comment, include: { model: Article } }] })
            .then(user =>
            {
                const { email, fullName } = user.dataValues;
                const articles = user.dataValues.Articles.map(date.mapInternalDate);
                const comments = user.dataValues.Comments.map(date.mapInternalDate);

                response.render('user/details', { username: email, fullName, articles, comments });
            });
    },
    loginGet: (request, response) =>
    {
        response.render('user/login');
    },
    loginPost: (request, response) =>
    {
        const loginArguments = request.body;
        const { email, password } = loginArguments;

        User
            .findOne({ where: { email } })
            .then((user) =>
            {
                if (!user || !user.authenticate(password))
                {
                    const errorMessage = 'Invalid username or password!';
                    loginArguments.error = errorMessage;

                    response.render('user/login', loginArguments);

                    return;
                }

                request.logIn(user,
                    (error) =>
                    {
                        if (error)
                        {
                            response.redirect('user/login', { error: error.message });
                            return;
                        }

                        response.redirect('/');
                    });
            });
    },
    logout: (request, response) =>
    {
        request.logOut();
        response.redirect('/');
    },
    registerGet: (request, response) =>
    {
        response.render('./user/register');
    },
    registerPost: (request, response) =>
    {
        const registerArguments = request.body;
        const { email, password, repeatedPassword, fullName } = registerArguments;

        User
            .findOne({ where: { email } })
            .then((user) =>
            {
                let errorMessage = '';

                if (user)
                {
                    errorMessage = 'This username is already taken!';
                }
                else if (password !== repeatedPassword)
                {
                    errorMessage = 'Passwords do not match!';
                }

                if (errorMessage)
                {
                    registerArguments.error = errorMessage;
                    response.render('user/register', registerArguments);
                }
                else
                {
                    const salt = encryption.generateSalt();
                    const passwordHash = encryption.hashPassword(password, salt);

                    const userObject = {
                        email,
                        passwordHash,
                        fullName,
                        salt
                    };

                    User
                        .create(userObject)
                        .then((user) =>
                        {
                            request.logIn(user, (error) =>
                            {
                                if (error)
                                {
                                    registerArguments.error = error.message;
                                    response.render('user/register', registerArguments);

                                    return;
                                }

                                response.redirect('/');
                            });
                        });
                }
            });
    }
};

module.exports = userController;
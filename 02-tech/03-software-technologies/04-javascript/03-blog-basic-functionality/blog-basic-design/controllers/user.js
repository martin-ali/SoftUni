// jshint esversion:6
const User = require('../models').User;
const Article = require('../models').Article;
const Comment = require('../models').Comment;
const date = require('../utilities/date');
const encryption = require('../utilities/encryption');

const userController = {
    detailsGet: async (request, response) =>
    {
        const id = request.params.id;
        const user = await User.findById(id, { include: [{ model: Article }, { model: Comment, include: { model: Article } }] });

        const { email, fullName } = user.dataValues;
        const articles = user.dataValues.Articles.map(date.mapInternalDate);
        const comments = user.dataValues.Comments.map(date.mapInternalDate);

        response.render('user/details', { username: email, fullName, articles, comments });
    },
    loginGet: async (request, response) =>
    {
        response.render('user/login');
    },
    loginPost: async (request, response) =>
    {
        const loginArguments = request.body;
        const { email, password } = loginArguments;
        const user = await User.findOne({ where: { email } });

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
    },
    logout: async (request, response) =>
    {
        request.logOut();
        response.redirect('/');
    },
    registerGet: async (request, response) =>
    {
        response.render('./user/register');
    },
    registerPost: async (request, response) =>
    {
        const registerArguments = request.body;
        const { email, password, repeatedPassword, fullName } = registerArguments;

        const user = await User.findOne({ where: { email } });
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

            const newUser = await User.create(userObject);
            request.logIn(newUser, (error) =>
            {
                if (error)
                {
                    registerArguments.error = error.message;
                    response.render('user/register', registerArguments);

                    return;
                }

                response.redirect('/');
            });
        }
    }
};

module.exports = userController;
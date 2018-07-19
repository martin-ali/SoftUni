// jshint esversion:6
const express = require('express');
const path = require('path');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const session = require('express-session');
const passport = require('passport');

module.exports = (app, config) =>
{
    // View engine
    app.set('views', path.join(config.rootFolder, '/views'));
    app.set('view engine', 'hbs');

    // This makes the content in the "public" folder accessible for every user.
    app.use(express.static(path.join(config.rootFolder, '/public')));

    // This set up which is the parser for the request's data.
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: true }));

    // We will use cookies.
    app.use(cookieParser('gosho'));

    // Session is storage for cookies, which will be de/encrypted with that 'secret' key.
    app.use(session({ secret: 'gosho', resave: false, saveUninitialized: false }));

    // For user validation we will use passport module.
    app.use(passport.initialize());
    app.use(passport.session());

    app.use((request, response, next) =>
    {
        if (request.user)
        {
            response.locals.user = request.user;
        }

        next();
    });

};
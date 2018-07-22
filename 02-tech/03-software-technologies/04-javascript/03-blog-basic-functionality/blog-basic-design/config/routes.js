// jshint esversion:6
// This is here for intellisense
const express = require('express')();

const homeController = require('../controllers').home;
const userController = require('../controllers').user;
const articleController = require('../controllers').article;
const commentController = require('../controllers').comment;

/**
 * @param { express } app
 */
module.exports = (app) =>
{
    app.get('/', homeController.indexGet);
    app.get('/page/:page', homeController.indexPageGet);

    app.get('/article/create', articleController.createGet);
    app.post('/article/create', articleController.createPost);

    app.get('/article/edit/:id', articleController.editGet);
    app.post('/article/edit/:id', articleController.editPost); // No put :(

    app.get('/article/delete/:id', articleController.deleteGet);
    app.post('/article/delete/:id', articleController.deletePost);

    app.get('/article/details/:id', articleController.detailsGet);

    app.get('/user/register', userController.registerGet);
    app.post('/user/register', userController.registerPost);

    app.get('/user/login', userController.loginGet);
    app.post('/user/login', userController.loginPost);
    app.get('/user/logout', userController.logout);

    app.get('/user/details/:id', userController.detailsGet);

    app.get('/comment/details/:id', commentController.detailsGet);
    app.get('/comment/create/:id', commentController.createGet);
    app.post('/comment/create/:id', commentController.createPost);

    app.get('/comment/edit/:id', commentController.editGet);
    app.post('/comment/edit/:id', commentController.editPost); // Need to find way to use put
};
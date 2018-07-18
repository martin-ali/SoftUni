const homeController = require('../controllers').home;
const userController = require('../controllers').user;
const articleController = require('../controllers').article;

module.exports = (app) =>
{
    app.get('/', homeController.indexGet);

    app.get('/article/create', articleController.createGet);
    app.post('/article/create', articleController.createPost);

    app.get('/article/details/:id', articleController.detailsGet);

    app.get('/user/register', userController.registerGet);
    app.post('/user/register', userController.registerPost);

    app.get('/user/login', userController.loginGet);
    app.post('/user/login', userController.loginPost);
    app.get('/user/logout', userController.logout);

    app.get('/user/details/:id', userController.detailsGet);
};
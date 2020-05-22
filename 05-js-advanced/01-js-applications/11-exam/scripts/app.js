import controller from './controller.js';

const app = Sammy('#root', function () {
    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/', controller.getHome);
    this.get('#/home', controller.getHome);

    // Users
    this.get('#/users/register', controller.getRegister);
    this.post('#/users/register', controller.postRegister);

    this.get('#/users/login', controller.getLogin);
    this.post('#/users/login', controller.postLogin);

    this.get('#/users/logout', controller.getLogout);

    // Articles
    this.get('#/articles/create', controller.getCreateArticle);
    this.post('#/articles/create', controller.postCreateArticle);

    this.get('#/articles/details/:id', controller.getArticleDetails);

    this.get('#/articles/edit/:id', controller.getEditArticle);
    this.post('#/articles/edit/:id', controller.postEditArticle);

    this.get('#/articles/delete/:id', controller.getDeleteArticle);
});

window.addEventListener(
    'DOMContentLoaded',
    () => {
        app.run('#/');
    });
``
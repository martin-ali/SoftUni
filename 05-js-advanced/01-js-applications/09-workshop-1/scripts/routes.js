import controller from './controller.js';

const app = Sammy('#main', function ()
{
    this.use('Handlebars', 'hbs');

    this.get('#/', controller.getHome);
    this.get('#/home', controller.getHome);

    this.get('#/register', controller.getRegister);
    this.post('#/register', controller.postRegister);

    this.get('#/login', controller.getLogin);
    this.post('#/login', controller.postLogin);

    this.get('#/logout', controller.getLogout);

    this.get('#/profile', controller.getProfile);

    this.get('#/treks/details/:id', controller.getTrekDetails);

    this.get('#/treks/create', controller.getCreateTrek);
    this.post('#/treks/create', controller.postCreateTrek);

    this.get('#/treks/edit/:id', controller.getEditTrek);
    this.post('#/treks/edit/:id', controller.postEditTrek);

    this.get('#/treks/like/:id', controller.getLikeTrek);

    this.get('#/treks/delete/:id', controller.getDeleteTrek);
});

window.addEventListener(
    'DOMContentLoaded',
    () =>
    {
        app.run('#/');
    });
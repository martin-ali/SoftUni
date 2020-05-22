import controller from './controller.js';
import controller from './controller.js';
import controller from './controller.js';

const app = Sammy('#main', function ()
{
    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/', controller.getHome);
    this.get('#/home', controller.getHome);

    // User
    this.get('#/user/register', controller.getRegister);
    this.post('#/user/register', controller.postRegister);

    this.get('#/user/login', controller.getLogin);
    this.post('#/user/login', controller.postLogin);

    this.get('#/user/logout', controller.getLogout);

    // Causes
    this.get('#/causes/create', controller.getCreateCause);
    this.post('#/causes/create', controller.postCreateCause);

    this.get('#/causes', controller.getAllCauses);
    this.get('#/causes/:id', controller.getCauseDetails);

    this.post('#/causes/:id/donate', controller.postDonate);

    this.get('#/causes/delete/:id', controller.getDeleteCause);
    this.del('#/causes/:id', controller.deleteCause);
});

window.addEventListener(
    'DOMContentLoaded',
    () =>
    {
        app.run('#/');
    });
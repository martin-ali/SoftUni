import routes from '../routes.js';
import Database from '../database.js';
import authentication from '../authentication.js';
import NotificationHandler from '../notification-handler.js';

const templatesPath = './templates';
const posts = new Database('https://my-blog-38846.firebaseio.com/', 'posts');
const notifications = new NotificationHandler('div#notifications', 5000);

class Controller {

    static posts = posts;
    static notifications = notifications;
    static templatesPath = templatesPath;
    static authentication = authentication;

    constructor() {
        if (new.target === Controller) {
            throw new Error();
        }
    }

    // @ts-ignore
    _redirectToLoginIfNotLogged(context) {
        if (!authentication.userIsLogged()) {
            // @ts-ignore
            this.redirect(routes.login);
        }
    }

    async _initializeCommon(context) {
        context.partials = {
            header: await context.load(`${Controller.templatesPath}/common/header.hbs`),
        };

        context.username = authentication.getUsername();
        context.isLogged = !!authentication.userIsLogged();
    }
}

export default Controller;
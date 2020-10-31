import routes from '../routes.js';
import Controller from './base-controller.js';

class UsersController extends Controller {

    constructor() {
        super();
    }

    async getRegister() {
        await super._initializeCommon(this);

        // @ts-ignore
        this.partials.content = await this.load(`${Controller.templatesPath}/users/register.hbs`);
        // @ts-ignore
        await this.partial(`${Controller.templatesPath}/container.hbs`);
    }

    postRegister() {
        // @ts-ignore
        const registerData = this.params;
        if (registerData.password !== registerData.repeatPassword) {
            Controller.notifications.error('Passwords should match!');

            return false;
        }

        Controller.authentication
            .register(registerData.email, registerData.password)
            .then(() => {
                Controller.notifications.success('Successfully register.')

                // @ts-ignore
                this.redirect(routes.login)
            })
            .catch(error => Controller.notifications.error(error.message));
    }

    async getLogin() {
        await super._initializeCommon(this);

        // @ts-ignore
        this.partials.content = await this.load(`${Controller.templatesPath}/users/login.hbs`);
        // @ts-ignore
        await this.partial(`${Controller.templatesPath}/container.hbs`);
    }

    postLogin() {
        // @ts-ignore
        const loginData = this.params;

        Controller.authentication
            .login(loginData.email, loginData.password)
            .then(() => {
                Controller.notifications.success('Successfully login.')

                // @ts-ignore
                this.redirect(routes.index);
            })
            .catch(error => Controller.notifications.error(error.message));
    }

    async getLogout() {
        try {
            await Controller.authentication.logout();

            Controller.notifications.success('Successfully logout.')
        } catch (error) {
            Controller.notifications.error(error.message);
        }

        // @ts-ignore
        this.redirect(routes.index)
    }
}

export default UsersController;
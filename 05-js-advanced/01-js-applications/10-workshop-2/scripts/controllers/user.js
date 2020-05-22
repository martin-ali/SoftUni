import Database from './database.js';
import authentication from './authentication.js';
import NotificationsHandler from './notificationHandler.js';
import helpers from './helpers.js';

const templatesPath = './templates';
const causes = new Database('https://don-uni.firebaseio.com/', 'causes');
const notifications = new NotificationsHandler(5000);

async function initializeCommon(context)
{
    context.partials = {
        nav: await context.load(`${templatesPath}/common/nav.hbs`),
        footer: await context.load(`${templatesPath}/common/footer.hbs`),
        notifications: await context.load(`${templatesPath}/common/notifications.hbs`)
    };

    context.username = authentication.getUsername();
    context.isLogged = authentication.userIsLogged;
}

function setupNotificationEvents()
{
    document
        .querySelector('#notifications')
        .addEventListener('click', event =>
        {
            // @ts-ignore
            event.target.style.display = 'none'
        });
}

async function getRegister()
{
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/user/register.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupNotificationEvents();
}

function postRegister()
{
    notifications.loading();

    const registerData = this.params;

    const usernameIsValid = helpers.stringIsValid(registerData.username);
    const passwordIsValid = helpers.stringIsValid(registerData.password);
    const bothPasswordsAreIdentical = registerData.password === registerData.rePassword;

    if (!usernameIsValid)
    {
        notifications.error('Invalid username');

        return false;
    }
    else if (!passwordIsValid)
    {
        notifications.error('Invalid password');

        return false;
    }
    else if (!bothPasswordsAreIdentical)
    {
        notifications.error('Passwords do not match');

        return false;
    }

    authentication
        .register(registerData.username, registerData.password)
        .then(() =>
        {
            notifications.success('Successfully registered user.');

            this.redirect('#/')
        })
        .catch(error => notifications.error(error.message))
}

async function getLogin()
{
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/user/login.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupNotificationEvents();
}

function postLogin()
{
    notifications.loading();

    const loginData = this.params;

    // @ts-ignore
    authentication
        .login(loginData.username, loginData.password)
        .then(() =>
        {
            notifications.success('Successfully logged user.');

            this.redirect('#/');
        })
        .catch(error => notifications.error(error.message));
}

async function getLogout()
{
    setupNotificationEvents();

    try
    {
        await authentication.logout();

        notifications.success('Logout successful.');

        this.redirect('#/');
    }
    catch (error)
    {
        notifications.error(error.message);
    }
}
const controller = {
    getRegister,
    postRegister,

    getLogin,
    postLogin,

    getLogout,
}

export default controller;
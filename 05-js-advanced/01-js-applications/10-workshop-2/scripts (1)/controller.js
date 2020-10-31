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

async function getHome()
{
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/home/home.hbs`);

    await this.partial(`${templatesPath}/container.hbs`);

    setupNotificationEvents();
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

async function getCreateCause()
{
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/causes/create.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupNotificationEvents();
}

function postCreateCause()
{
    notifications.loading();

    const token = authentication.getToken();
    const cause = this.params;
    cause.collectedFunds = 0;
    cause.donors = [];
    cause.creator = authentication.getUsername();

    const parametersToValidate = ['cause', 'pictureUrl', 'neededFunds']
    for (const parameter of parametersToValidate)
    {
        const parameterIsValid = helpers.stringIsValid(cause[parameter]);
        if (!parameterIsValid)
        {
            notifications.error(`Invalid ${parameter}`);

            return false;
        }
    }

    causes
        .create(cause, token)
        .then(() =>
        {
            notifications.success('Cause created successfully.');

            this.redirect('#/')
            // TODO: Alternatively redirect to the dashboard
        })
        .catch(error => notifications.error(error.message));
}

async function getAllCauses()
{
    await initializeCommon(this);

    const token = authentication.getToken();
    const username = authentication.getUsername();
    const causesList = await causes.getAll(token);
    this.causes = [];
    for (const cause of causesList)
    {
        this.causes.push(cause);
    }

    this.partials.content = await this.load(`${templatesPath}/causes/all.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupNotificationEvents();
}

async function getCauseDetails()
{
    await initializeCommon(this);

    const id = this.params.id;
    const token = authentication.getToken();
    const cause = await causes.getById(id, token)

    this.cause = cause;
    this.isAuthor = cause.creator === authentication.getUsername();

    this.partials.content = await this.load(`${templatesPath}/causes/details.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupNotificationEvents();
}

function postDonate()
{
    const id = this.params.id;
    const pledgedFunds = this.params.currentDonation;
    const token = authentication.getToken();
    const donor = authentication.getUsername();

    causes
        .getById(id, token)
        .then(async (cause) =>
        {
            try
            {
                const collectedFunds = parseFloat(cause.collectedFunds) + parseFloat(pledgedFunds);
                const donors = cause.donors || [];

                if (!donors.includes(donor))
                {
                    donors.push(donor);
                }

                await causes.patchById({ collectedFunds, donors }, id, token);

                notifications.success('Funds pledged successfully.');

                this.redirect(`#/causes/${id}`);

            }
            catch (error)
            {
                notifications.error(error.message)
            }
        });
}

async function getDeleteCause()
{
    await initializeCommon(this);

    const id = this.params.id;
    const token = authentication.getToken();
    const cause = await causes.getById(id, token)

    this.cause = cause;

    this.partials.content = await this.load(`${templatesPath}/causes/delete.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupNotificationEvents();
    document
        .querySelector('form button')
        .addEventListener('click', async event =>
        {
            const x = await fetch('/#');
            const y = await x.text();
            const response = await fetch(`#/cause/${id}`,
            {
                method: 'delete',
                body: JSON.stringify({ id })
            });

            console.log(await response.text())
        });
}

function deleteCause()
{
    const id = this.params.id;
    const token = authentication.getToken();
    const username = authentication.getUsername();

    causes
        .getById(id, token)
        .then(async (cause) =>
        {
            try
            {
                if (username !== cause.creator)
                {
                    notifications.error('You can only close your own causes!');

                    return;
                }

                await causes.deleteById(id, token);

                notifications.success('Cause closed successfully.');

                // this.redirect(`#/causes`);

            }
            catch (error)
            {
                notifications.error(error.message)
            }
        });
}


const controller = {
    getHome,

    getRegister,
    postRegister,

    getLogin,
    postLogin,

    getLogout,

    getCreateCause,

    postCreateCause,

    getAllCauses,
    getCauseDetails,

    postDonate,

    getDeleteCause,
    deleteCause
}

export default controller;
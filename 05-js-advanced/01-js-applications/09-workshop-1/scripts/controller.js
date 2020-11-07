import Database from './database.js';
import authentication from './authentication.js';
import NotificationsHandler from './notificationHandler.js';

const templatesPath = './templates';
const treks = new Database('https://the-trekking-zone-ff0b3.firebaseio.com/', 'treks');
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

function setupEvents()
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

    if (authentication.userIsLogged())
    {
        const token = authentication.getToken();
        this.treks = await treks.getAll(token);
    }

    this.partials.content = await this.load(`${templatesPath}/home/home.hbs`);
    this.partials.createInvitation = await this.load(`${templatesPath}/home/createInvitation.hbs`);
    // this.partials.advertisement = await this.load(`${templatesPath}/home/advertisement.hbs`);
    this.partials.treksList = await this.load(`${templatesPath}/treks/list.hbs`);

    await this.partial(`${templatesPath}/container.hbs`);

    setupEvents();
}

async function getRegister()
{
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/user/register.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupEvents();
}

function postRegister()
{
    notifications.loading();

    const registerData = this.params;

    const emailIsValid = registerData.email.length >= 3;
    const passwordIsValid = registerData.password.length >= 6;
    const bothPasswordsAreIdentical = registerData.password === registerData.rePassword;

    if (!emailIsValid)
    {
        notifications.error('Username should be 3 or more characters');

        return false;
    }
    else if (!passwordIsValid)
    {
        notifications.error('password should be 6 or more characters');

        return false;
    }
    else if (!bothPasswordsAreIdentical)
    {
        notifications.error('Passwords do not match');

        return false;
    }

    authentication
        .register(registerData.email, registerData.password)
        .then(() =>
        {
            notifications.success('Successfully registered user.');
            this.redirect('#/')
        })
        .catch(error => notifications.error(error.message))
}

async function getProfile()
{
    await initializeCommon(this);

    const token = authentication.getToken();
    const username = authentication.getUsername();
    const treksList = await treks.getAll(token);

    this.treks = [];
    for (const id in treksList)
    {
        const trek = treksList[id];

        if (username !== trek.organizer)
        {
            continue;
        }

        this.treks.push(trek.location);
    }

    this.partials.content = await this.load(`${templatesPath}/user/profile.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupEvents();
}

async function getLogin()
{
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/user/login.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupEvents();
}

function postLogin()
{
    notifications.loading();

    const loginData = this.params;

    // @ts-ignore
    authentication
        .login(loginData.email, loginData.password)
        .then(() =>
        {
            notifications.success('Successfully logged user.');
            this.redirect('#/');
        })
        .catch(error => notifications.error(error.message));
}

async function getLogout()
{
    setupEvents();

    try
    {
        await authentication.logout();

        notifications.success('Logout successful.');

        this.redirect('#/home');
    }
    catch (error)
    {
        notifications.error(error.message);
    }
}

async function getCreateTrek()
{
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/treks/create.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);

    setupEvents();
}

function postCreateTrek()
{
    notifications.loading();

    const token = authentication.getToken();
    const trek = this.params;
    trek.organizer = sessionStorage.getItem('username');
    trek.likes = 0;

    const locationIsValid = trek.location.length >= 6;
    const descriptionIsValid = trek.description.length >= 10

    if (!locationIsValid)
    {
        notifications.error('Trek name should be 6 or more characters.');

        return false;
    }
    else if (!descriptionIsValid)
    {
        notifications.error('Trek description should be 10 or more characters');

        return false;
    }

    treks
        .create(trek, token)
        .then(() =>
        {
            notifications.success('Trek created successfully.');

            this.redirect('#/')
        })
        .catch(error => notifications.error(error.message));
}

async function getTrekDetails()
{
    await initializeCommon(this);

    const id = this.params['id'];
    const token = authentication.getToken();
    const trek = await treks.getById(id, token)

    this.id = id;
    this.isOrganizer = trek.organizer === this.username;

    this.partials.content = await this.load(`${templatesPath}/treks/details.hbs`);
    await this.partial(`${templatesPath}/container.hbs`, trek);

    setupEvents();
}

async function getEditTrek()
{
    await initializeCommon(this);

    const id = this.params['id'];
    const token = authentication.getToken();
    const trek = await treks.getById(id, token)

    this.id = id;
    this.partials.content = await this.load(`${templatesPath}/treks/edit.hbs`);
    await this.partial(`${templatesPath}/container.hbs`, trek);

    setupEvents();
}


function postEditTrek()
{
    const id = this.params['id'];
    const trek = this.params;
    const token = authentication.getToken();

    if (this.username !== trek.organizer)
    {
        notifications.error('You can only edit your own treks.');

        return false;
    }

    treks
        .updateById(trek, id, token)
        .then(() =>
        {
            notifications.success('Trek edited successfully.');

            this.redirect('#/')
        })
        .catch(error => notifications.error(error.message));
}

async function getLikeTrek()
{
    setupEvents();

    const id = this.params['id'];
    const token = authentication.getToken();
    const trek = await treks.getById(id, token);
    const likes = parseInt(trek.likes) + 1;

    const username = authentication.getUsername();
    if (username === trek.organizer)
    {
        notifications.error('You can\'t like your own treks!');

        return false;
    }


    try
    {
        await treks.patchById({ likes }, id, token);

        notifications.success('You liked the trek successfully.');

        this.redirect(`#/treks/details/${id}`)
    }
    catch (error)
    {
        notifications.error(error.message)
    }
}

async function getDeleteTrek()
{
    setupEvents();

    const id = this.params['id'];
    const token = authentication.getToken();
    const trek = await treks.getById(id, token);

    const username = authentication.getUsername();
    if (username !== trek.organizer)
    {
        notifications.error('You can only delete your own treks!');

        return false;
    }

    await treks.deleteById(id, token);

    notifications.success('You closed the trek successfully.');

    this.redirect('#/');
}

const controller = {
    getHome,

    getRegister,
    postRegister,

    getLogin,
    postLogin,

    getLogout,

    getProfile,

    getTrekDetails,

    getCreateTrek,
    postCreateTrek,

    getEditTrek,
    postEditTrek,

    getLikeTrek,

    getDeleteTrek
}

export default controller;
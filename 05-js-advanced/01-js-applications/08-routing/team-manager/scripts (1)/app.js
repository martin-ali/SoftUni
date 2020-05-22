import { createFormEntity } from './form-helpers.js'
import { fireBaseRequestFactory } from './firebase-requests.js'

const fireBaseTeams = fireBaseRequestFactory('https://team-manager-7655b.firebaseio.com/', 'teams', sessionStorage.getItem('token'));

async function applyCommon()
{
    const partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.username = sessionStorage.getItem('username');
    this.loggedIn = !!sessionStorage.getItem('token');
    this.hasNoTeam = !sessionStorage.getItem('team');

    return partials;
}

async function homeViewHandler()
{
    this.partials = await applyCommon.call(this);

    await this.partial('/templates/home/home.hbs');
}

async function aboutViewHandler()
{
    this.partials = await applyCommon.call(this);

    await this.partial('/templates/about/about.hbs');
}

async function catalogHandler()
{
    this.partials = await applyCommon.call(this);
    this.partials.team = await this.load('/templates/catalog/team.hbs')

    const teamsResponse = await fireBaseTeams.getAll();
    this.teams = [];

    for (const teamId in teamsResponse)
    {
        const team = teamsResponse[teamId];
        this.teams.push(team);
    }

    console.log(this.teams)
    await this.partial('/templates/catalog/teamCatalog.hbs');
}

async function createTeamHandler()
{
    this.partials = await applyCommon.call(this);
    this.partials.createForm = await this.load('/templates/create/createForm.hbs')

    await this.partial('/templates/create/createPage.hbs');

    const formRef = document.getElementById('create-form');

    formRef.addEventListener('submit', async function (event)
    {
        event.preventDefault();

        const form = createFormEntity(formRef, ['name', 'comment']);
        const formValue = form.getValue();

        const response = await fireBaseTeams.createEntity(formValue);
        console.log(response)
    });
}

async function loginHandler()
{
    const page = this;
    this.partials = await applyCommon.call(this);
    this.partials.loginForm = await this.load('/templates/login/loginForm.hbs')

    await this.partial('/templates/login/loginPage.hbs');

    const formRef = document.getElementById('login-form');

    formRef.addEventListener('submit', function (event)
    {
        event.preventDefault();

        const form = createFormEntity(formRef, ['username', 'password']);
        const formValue = form.getValue();

        firebase
            .auth()
            .signInWithEmailAndPassword(formValue.username, formValue.password)
            .then(response =>
            {
                console.log(response);

                firebase
                    .auth()
                    .currentUser.getIdToken()
                    .then(token =>
                    {
                        sessionStorage.setItem('token', token);
                        sessionStorage.setItem('username', response.user.email);
                        // sessionStorage.setItem('team', response.user.teamId);

                        page.redirect('#/');
                    })
            });
    });
}


async function registerViewHandler()
{
    const page = this;
    this.partials = await applyCommon.call(this);
    this.partials.registerForm = await this.load('/templates/register/registerForm.hbs');

    await this.partial('/templates/register/registerPage.hbs');

    const formRef = document.getElementById('register-form');

    formRef.addEventListener('submit', function (event)
    {
        event.preventDefault();

        const form = createFormEntity(formRef, ['username', 'password', 'repeatPassword']);
        const formValue = form.getValue();

        if (formValue.password !== formValue.repeatPassword)
        {
            return;
        }

        firebase
            .auth()
            .createUserWithEmailAndPassword(formValue.username, formValue.password)
            .then(response =>
            {
                firebase.auth().currentUser.getIdToken()
                    .then(token =>
                    {
                        sessionStorage.setItem('token', token);
                        sessionStorage.setItem('username', response.user.email);

                        page.redirect('#/');
                    })
            });
    })
}

function logoutHandler()
{
    sessionStorage.clear();

    firebase.auth().signOut();

    this.redirect('#/');
}

const app = Sammy('#main', function ()
{
    this.use('Handlebars', 'hbs');

    this.get('#/', homeViewHandler);

    this.get('#/home', homeViewHandler);

    this.get('#/about', aboutViewHandler);

    this.get('#/catalog', catalogHandler);

    this.get('#/create', createTeamHandler);
    this.post('#/create', () => false);

    this.get('#/login', loginHandler);
    this.post('#/login', () => false);

    this.get('#/register', registerViewHandler);
    this.post('#/register', () => false);

    this.get('#/logout', logoutHandler);
});

window.addEventListener(
    'DOMContentLoaded',
    (event) =>
    {
        app.run('#/');
    });
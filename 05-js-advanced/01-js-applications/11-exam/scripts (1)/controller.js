import Database from './database.js';
import authentication from './authentication.js';

const templatesPath = './templates';
const articles = new Database('https://soft-wiki.firebaseio.com/', 'articles');

async function initializeCommon(context) {
    context.partials = {
        header: await context.load(`${templatesPath}/common/header.hbs`),
        footer: await context.load(`${templatesPath}/common/footer.hbs`)
    };

    context.username = authentication.getUsername();
    context.isLogged = authentication.userIsLogged;
}

async function getHome() {
    await initializeCommon(this);

    if (!authentication.userIsLogged()) {
        this.redirect('#/users/login');
    }

    const token = authentication.getToken();
    const articlesList = await articles.getAll(token);

    this.articles = {};

    for (const article of articlesList) {
        const category = article.category.toLowerCase();

        if (!this.articles[category]) {
            this.articles[category] = [];
        }

        this.articles[category].push(article);
    }

    for (const category in this.articles) {
        const categoryArticles = this.articles[category];
        categoryArticles.sort((a, b) => b.title.localeCompare(a.title));
    }

    this.partials.noArticles = await this.load(`${templatesPath}/home/noArticles.hbs`);
    this.partials.content = await this.load(`${templatesPath}/home/home.hbs`);

    await this.partial(`${templatesPath}/container.hbs`);
}

async function getRegister() {
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/users/register.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);
}

function postRegister() {
    const registerData = this.params;

    const bothPasswordsAreIdentical = registerData.password === registerData['rep-pass'];
    if (!bothPasswordsAreIdentical) {
        return false;
    }

    authentication
        .register(registerData.email, registerData.password)
        .then(() => {
            this.redirect('#/')
        });
}

async function getLogin() {
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/users/login.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);
}

function postLogin() {
    const loginData = this.params;

    authentication
        .login(loginData.email, loginData.password)
        .then(() => {
            this.redirect('#/');
        });
}

async function getLogout() {
    await authentication.logout();

    this.redirect('#/users/login');
}

async function getCreateArticle() {
    await initializeCommon(this);

    this.partials.content = await this.load(`${templatesPath}/articles/create.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);


}

function postCreateArticle() {
    const token = authentication.getToken();
    const article = this.params;
    article.creator = authentication.getUsername();

    articles
        .create(article, token)
        .then(() => {
            this.redirect('#/');
        });
}

async function getArticleDetails() {
    await initializeCommon(this);

    const id = this.params.id;
    const token = authentication.getToken();
    const article = await articles.getById(id, token)

    this.article = article;
    this.article.isAuthor = article.creator === authentication.getUsername();

    this.partials.content = await this.load(`${templatesPath}/articles/details.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);
}

async function getEditArticle() {
    await initializeCommon(this);

    const id = this.params.id;
    const token = authentication.getToken();
    this.article = await articles.getById(id, token);

    this.partials.content = await this.load(`${templatesPath}/articles/edit.hbs`);
    await this.partial(`${templatesPath}/container.hbs`);
}

function postEditArticle() {
    const token = authentication.getToken();
    const id = this.params.id;
    const editor = authentication.getUsername();

    articles.getById(id, token)
        .then(async article => {
            if (article.creator !== editor) {
                return;
            }

            const articleEdited = {
                title: this.params.title,
                category: this.params.category,
                content: this.params.content,
                creator: article.creator
            }

            await articles.updateById(articleEdited, id, token)

            this.redirect('#/');
        });
}

async function getDeleteArticle() {
    const token = authentication.getToken();
    const id = this.params.id;
    const editor = authentication.getUsername();

    const article = await articles.getById(id, token);

    if (article.creator !== editor) {
        return;
    }

    await articles.deleteById(id, token)

    this.redirect('#/');
}

const controller = {
    // Home
    getHome,

    // Users
    getRegister,
    postRegister,

    getLogin,
    postLogin,

    getLogout,

    // Articles
    getCreateArticle,
    postCreateArticle,

    getArticleDetails,

    getEditArticle,
    postEditArticle,

    getDeleteArticle
}

export default controller;
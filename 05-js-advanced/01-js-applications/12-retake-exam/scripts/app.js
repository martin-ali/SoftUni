import routes from './routes.js';
import UsersController from './controllers/users-controller.js';
import HomeController from './controllers/home-controller.js';
import PostsController from './controllers/posts-controller.js';

const usersController = new UsersController();
const homeController = new HomeController();
const postsController = new PostsController();

const app = Sammy('#root', function () {
    this.use('Handlebars', 'hbs');

    // Home
    this.get(routes.index, homeController.getHome);
    this.get(routes.home, homeController.getHome);

    // Users
    this.get(routes.register, usersController.getRegister);
    this.post(routes.register, usersController.postRegister);

    this.get(routes.login, usersController.getLogin);
    this.post(routes.login, usersController.postLogin);

    this.get(routes.logout, usersController.getLogout);

    // Posts
    this.post(routes.createPost, postsController.postCreatePost);

    this.get(`${routes.postDetails}/:id`, postsController.getPostDetails);

    this.get(`${routes.editPost}/:id`, postsController.getEditPost);
    this.post(`${routes.editPost}/:id`, postsController.postEditPost);

    this.get(`${routes.deletePost}/:id`, postsController.getDeletePost);
});

window.addEventListener(
    'DOMContentLoaded',
    () => {
        app.run('#/');
    });
``
import Controller from './base-controller.js';

class HomeController extends Controller {

    constructor() {
        super();
    }

    async getHome() {
        await super._initializeCommon(this);

        if (Controller.authentication.userIsLogged()) {
            const token = Controller.authentication.getToken();
            const postsList = await Controller.posts.getAll(token);
            const postsByCurrentUser = postsList.filter(p => p.creator === Controller.authentication.getUsername());

            this.posts = postsByCurrentUser
        };

        // @ts-ignore
        this.partials.postSummary = await this.load(`${Controller.templatesPath}/posts/summary.hbs`)
        // @ts-ignore
        this.partials.createPost = await this.load(`${Controller.templatesPath}/posts/create.hbs`)
        // @ts-ignore
        this.partials.postsRow = await this.load(`${Controller.templatesPath}/common/postsRow.hbs`)
        // @ts-ignore
        this.partials.content = await this.load(`${Controller.templatesPath}/home/home.hbs`);

        // @ts-ignore
        await this.partial(`${Controller.templatesPath}/container.hbs`);
    }
}

export default HomeController;
import Controller from './base-controller.js';
import routes from '../routes.js';

class PostsController extends Controller {

    constructor() {
        super();
    }

    postCreatePost() {
        super._redirectToLoginIfNotLogged(this);

        // @ts-ignore
        const post = this.params;
        const token = Controller.authentication.getToken();
        post.creator = Controller.authentication.getUsername();

        Controller.posts
            .create(post, token)
            .then(() => {
                Controller.notifications.success('Successfully created.')

                // @ts-ignore
                this.redirect(routes.index)
            })
            .catch(error => Controller.notifications.error(error.message));;
    }

    async getPostDetails() {
        super._redirectToLoginIfNotLogged(this);

        await super._initializeCommon(this);

        // @ts-ignore
        const id = this.params.id;
        const token = Controller.authentication.getToken();
        const post = await Controller.posts.getById(id, token)

        this.post = post;

        // @ts-ignore
        this.partials.content = await this.load(`${Controller.templatesPath}/posts/details.hbs`);
        // @ts-ignore
        await this.partial(`${Controller.templatesPath}/container.hbs`);
    }

    async getEditPost() {
        super._redirectToLoginIfNotLogged(this);

        await super._initializeCommon(this);

        // @ts-ignore
        const id = this.params.id;
        const token = Controller.authentication.getToken();
        this.post = await Controller.posts.getById(id, token);

        const editor = Controller.authentication.getUsername();
        if (this.post.creator !== editor) {
            // @ts-ignore
            this.redirect(routes.index);
        }

        // @ts-ignore
        this.partials.content = await this.load(`${Controller.templatesPath}/posts/edit.hbs`);
        // @ts-ignore
        this.partials.postsRow = await this.load(`${Controller.templatesPath}/common/postsRow.hbs`)

        // @ts-ignore
        await this.partial(`${Controller.templatesPath}/container.hbs`);
    }

    postEditPost() {
        super._redirectToLoginIfNotLogged(this);

        // @ts-ignore
        const id = this.params.id;
        const token = Controller.authentication.getToken();
        const editor = Controller.authentication.getUsername();

        Controller.posts
            .getById(id, token)
            .then(async post => {
                if (post.creator !== editor) {
                    Controller.notifications.error('You can only edit your own posts.')

                    return;
                }

                const postEdited = {
                    // @ts-ignore
                    title: this.params.title,
                    // @ts-ignore
                    category: this.params.category,
                    // @ts-ignore
                    content: this.params.content,
                    creator: post.creator
                }

                await Controller.posts.updateById(postEdited, id, token)

                Controller.notifications.success('Successfully edited.')

                // @ts-ignore
                this.redirect(routes.index);
            })
            .catch(error => Controller.notifications.error(error.message));;
    }

    async getDeletePost() {
        super._redirectToLoginIfNotLogged(this);

        // @ts-ignore
        const id = this.params.id;
        const token = Controller.authentication.getToken();
        const editor = Controller.authentication.getUsername();

        const post = await Controller.posts.getById(id, token);

        if (post.creator !== editor) {
            return;
        }

        try {
            await Controller.posts.deleteById(id, token)

            Controller.notifications.success('Successfully deleted.')
        } catch (error) {
            Controller.notifications.error(error.message);

            return false;
        }

        // @ts-ignore
        this.redirect(routes.index);
    }
}

export default PostsController;
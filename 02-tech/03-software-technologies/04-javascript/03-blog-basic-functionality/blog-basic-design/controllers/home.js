// jshint esversion:6
const Article = require('../models').Article;
const User = require('../models').User;

const homeController = {
    indexGet: (request, response) =>
    {
        response.redirect('/page/1');
    },
    indexPageGet: (request, response) =>
    {
        const page = request.params.page >= 1
            ? Number(request.params.page)
            : 1;
        Article
            .findAndCountAll(
            {
                offset: ((page - 1) * 6),
                limit: 6,
                include: [
                {
                    model: User
                }]
            })
            .then((articleData) =>
            {
                const { rows: articles, count: articleCount } = articleData;

                const pages = [page - 1, page, page + 1];

                if (pages[0] < 1) pages.shift();

                const articlesLeft = articleCount - (page * 6);
                if (articlesLeft <= 0) pages.pop();

                response.render('home/index', { articles, pages });
            });
    }
};

module.exports = homeController;
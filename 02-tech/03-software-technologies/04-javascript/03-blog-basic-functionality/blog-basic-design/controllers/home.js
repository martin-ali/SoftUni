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
        const page = request.params.page - 1;
        Article.findAll(
            {
                offset: (page * 6),
                limit: 6,
                include: [
                {
                    model: User
                }]
            })
            .then((articles) =>
            {
                response.render('home/index', { articles });
            });
    }
};

module.exports = homeController;
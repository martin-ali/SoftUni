// jshint esversion:6
const Sequelize = require('sequelize');

/**
 *
 * @param {Sequelize.Sequelize} sequelize
 * @param {*} dataTypes
 * @returns { Sequelize.Model }
 */
function createArticle(sequelize, dataTypes)
{
    const Article = sequelize.define('Article',
    {
        title:
        {
            type: Sequelize.STRING,
            allowNull: false,
            // @ts-ignore
            required: true
        },
        content:
        {
            type: Sequelize.STRING,
            allowNull: false,
            required: true
        },
        date:
        {
            type: Sequelize.DATE,
            allowNull: false,
            required: true,
            defaultValue: Sequelize.NOW
        }
    },
    {
        timestamps: false
    });

    Article.associate = (models) =>
    {
        Article.hasMany(models.Comment,
        {
            foreignKey: 'articleId',
            sourceKey: 'id'
        });

        Article.belongsTo(models.User,
        {
            foreignKey: 'authorId',
            targetKey: 'id'
        });
    };

    return Article;
}

module.exports = createArticle;
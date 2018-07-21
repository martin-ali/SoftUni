// jshint esversion:6
const Sequelize = require('sequelize');

/**
 *
 * @param {Sequelize.Sequelize} sequelize
 * @param {*} dataTypes
 * @returns { Sequelize.Model }
 */
function createComment(sequelize, dataTypes)
{
    const Comment = sequelize.define('Comment',
    {
        content:
        {
            type: Sequelize.STRING,
            allowNull: false,
            // @ts-ignore
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

    Comment.associate = (models) =>
    {
        Comment.belongsTo(models.Article,
        {
            foreignKey: 'articleId',
            targetKey: 'id'
        });

        Comment.belongsTo(models.User,
        {
            foreignKey: 'authorId',
            targetKey: 'id'
        });
    };

    return Comment;
}

module.exports = createComment;
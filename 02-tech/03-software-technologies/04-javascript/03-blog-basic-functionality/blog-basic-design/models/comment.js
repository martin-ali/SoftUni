// jshint esversion:6
const Sequelize = require('sequelize');

function createComment(sequelize, dataTypes)
{
    const Comment = sequelize.define('Comment',
    {
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
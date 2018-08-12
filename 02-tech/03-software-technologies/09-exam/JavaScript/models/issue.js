const Sequelize = require('sequelize');

/**
 *
 * @param {Sequelize.Sequelize} sequelize
 * @returns { Sequelize.Model }
 */
module.exports = function (sequelize)
{

    let Issue = sequelize.define("Issue",
    {
        title:
        {
            type: Sequelize.TEXT,
            allowNull: false,
            // @ts-ignore
            required: true,
            validate:
            {
                notEmpty: true
            }
        },
        content:
        {
            type: Sequelize.TEXT,
            allowNull: false,
            required: true,
            validate:
            {
                notEmpty: true
            }
        },
        priority:
        {
            type: Sequelize.INTEGER,
            allowNull: false,
            required: true
        }
    },
    {
        timestamps: false
    });

    return Issue;
};
const Sequelize = require('sequelize');

/**
 *
 * @param {Sequelize.Sequelize} sequelize
 * @returns { Sequelize.Model }
 */
module.exports = function (sequelize)
{
    let Project = sequelize.define("Project",
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
        description:
        {
            type: Sequelize.TEXT,
            allowNull: false,
            required: true,
            validate:
            {
                notEmpty: true
            }
        },
        budget:
        {
            type: Sequelize.INTEGER,
            allowNull: false,
            required: true
        }
    },
    {
        timestamps: false
    });

    return Project;
};
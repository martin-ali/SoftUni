const Sequelize = require('sequelize');

/**
 *
 * @param {Sequelize.Sequelize} sequelize
 * @returns { Sequelize.Model }
 */
module.exports = function (sequelize)
{
    let Task = sequelize.define("Task",
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
        status:
        {
            type: Sequelize.ENUM,
            values: ["Open", 'In Progress', 'Finished']
        }
    },
    {
        timestamps: false
    });

    return Task;
};
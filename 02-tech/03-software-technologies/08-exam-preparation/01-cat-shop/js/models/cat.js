const Sequelize = require('sequelize');

/**
 *
 * @param {Sequelize.Sequelize} sequelize
 * @returns { Sequelize.Model }
 */
module.exports = function (sequelize)
{
    let Cat = sequelize.define("Cat",
    {
        name:
        {
            type: Sequelize.STRING,
            allowNull: false,
            // @ts-ignore
            required: true

        },
        nickname:
        {
            type: Sequelize.STRING,
            allowNull: false,
            required: true
        },
        price:
        {
            type: Sequelize.DOUBLE,
            allowNull: false,
            required: true
        }
    },
    {
        timestamps: false
    });

    return Cat;
};
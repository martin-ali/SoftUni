const Sequelize = require('sequelize');
const encryption = require('../utilities/encryption');

function createUser(sequelize, dataTypes)
{
    const User = sequelize.define('User',
    {
        email:
        {
            type: Sequelize.STRING,
            required: true,
            unique: true,
            allowNull: false
        },
        passwordHash:
        {
            type: Sequelize.STRING,
            required: true
        },
        fullName:
        {
            type: Sequelize.STRING,
            required: true
        },
        salt:
        {
            type: Sequelize.STRING,
            required: true
        }
    },
    {
        timestamps: false
    });

    // FIXME: Fails with fat arrow syntax!
    User.prototype.authenticate = function (password)
    {
        console.log(this);
        const inputPasswordHash = encryption.hashPassword(password, this.salt);
        const passwordIsCorrect = (inputPasswordHash === this.passwordHash);

        return passwordIsCorrect;
    }

    User.associate = (models) =>
    {
        User.hasMany(models.Article,
        {
            foreignKey: 'authorId',
            sourceKey: 'id'
        });
    };

    return User;
}

module.exports = createUser;
// jshint esversion:6
const fileSystem = require('fs');
const path = require('path');
const Sequelize = require('sequelize');
const basename = path.basename(module.filename);
const environment = process.env.NODE_ENV || 'development';
const configuration = require(`${__dirname}/../config/config.js`).database[environment];
const database = {};

let sequelize;
if (configuration.use_env_variable)
{
    sequelize = new Sequelize(process.env[configuration.use_env_variable]);
}
else
{
    sequelize = new Sequelize(configuration.database, configuration.username, configuration.password, configuration);
}

fileSystem
    .readdirSync(__dirname)
    .filter(file =>
    {
        return (file.indexOf('.') !== 0)
            && (file !== basename)
            && (file.slice(-3) === '.js');
    })
    .forEach(file =>
    {
        const model = sequelize.import(path.join(__dirname, file));
        database[model.name] = model;
    });

Object.keys(database).forEach(modelName =>
{
    if (database[modelName].associate)
    {
        database[modelName].associate(database);
    }
});

const models = Object.keys(database);

/**
 *
 * @param {array} models
 */
async function create(models)
{
    console.log('Initializing...');
    await sequelize
        .authenticate()
        .then(function (error)
        {
            console.log('\x1b[32m%s\x1b[0m', 'Connection has been established successfully.');
        })
        .catch(function (error)
        {
            console.error('Unable to connect to the database!');
            process.exit(1);
        });

    for (let current = 0; current < models.length; ++current)
    {
        const modelName = models[current];
        try
        {
            await database[modelName].sync();
            models.splice(current, 1);
            current--;
        }
        catch (error) {}
    }

    if (models.length > 0)
    {
        create(models.slice());
    }
}

create(models.slice());

database.sequelize = sequelize;
database.Sequelize = Sequelize;

module.exports = database;
const Sequelize = require('sequelize');
const Task = require('../models').Task;

module.exports = {
    index: async (req, res) =>
    {
        const tasks = await Task.findAll();

        const openTasks = tasks.filter(t => t.status === 'Open');
        const finishedTass = tasks.filter(t => t.status === 'Finished');
        const inProgressTasks = tasks.filter(t => t.status === 'In Progress');

        return res.render('task/index',
        {
            'openTasks': openTasks,
            'finishedTasks': finishedTass,
            'inProgressTasks': inProgressTasks
        });
    },

    createGet: (req, res) =>
    {
        res.render('task/create');
    },

    createPost: async (req, res) =>
    {
        let task = req.body;

        await Task.create(task);
        res.redirect('/');
    },

    editGet: async (req, res) =>
    {
        let id = req.params.id;

        const task = await Task.findById(id);
        res.render('task/edit', task.dataValues);
    },

    editPost: async (req, res) =>
    {
        let id = req.params.id;
        const taskUpdatedInfo = req.body;

        const task = await Task.findById(id);
        await task.updateAttributes(taskUpdatedInfo);
        res.redirect('/');
    }
};
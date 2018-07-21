// jshint esversion:6
const date = {
    /**
     * @param {object} model
     *
     * @returns {string}
     */
    mapInternalDate: (model) =>
    {
        const dateIso = model.dataValues.date;
        model.dataValues.date = dateIso.toLocaleDateString();

        return model;
    }
};

module.exports = date;
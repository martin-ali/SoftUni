(function () {
    document.getElementById('btnLoadTowns')
        .addEventListener('click', event => {
            const template = document.getElementById('towns-template').innerText;

            const templateCompiled = Handlebars.compile(template);
            const towns = document.getElementById('towns')
                .value
                .split(', ');

            const renderedTemplate = templateCompiled(towns);

            document.getElementById('root')
                .innerHTML = renderedTemplate;
        });
})();
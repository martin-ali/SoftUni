(function () {
    function renderCatTemplate() {
        function toggleStatus(event) {
            const statusDiv = event.target.parentNode.getElementsByClassName('status')[0];
            const text = event.target.textContent

            if (statusDiv.style.display === 'block') {
                event.target.textContent = text.replace('Hide', 'Show');
                statusDiv.style.display = 'none';
            } else {
                event.target.textContent = text.replace('Show', 'Hide');
                statusDiv.style.display = 'block';
            }
        }

        const templateRaw = document.getElementById('cat-template').textContent;
        const template = Handlebars.compile(templateRaw);

        const templateProcessed = template(window.cats);
        const catsSection = document.getElementById('allCats');
        catsSection.innerHTML = templateProcessed;

        const buttons = document.getElementsByClassName('showBtn');
        for (const button of buttons) {
            button.addEventListener('click', toggleStatus);
        }
    }

    renderCatTemplate();
}())
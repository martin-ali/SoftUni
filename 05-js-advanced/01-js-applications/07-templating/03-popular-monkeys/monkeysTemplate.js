(function () {
    function toggleInfo(event) {
        const infoP = event.target.parentNode.getElementsByTagName('p')[0];

        if (infoP.style.display === 'block') {
            infoP.style.display = 'none';
        } else {
            infoP.style.display = 'block';
        }
    }

    const templateRaw = document.getElementById('monkey-template').innerText;
    const templateCompiled = Handlebars.compile(templateRaw);
    const templateRendered = templateCompiled(monkeys);

    const monkeysDiv = document.getElementsByClassName('monkeys')[0];
    monkeysDiv.innerHTML = templateRendered;

    const buttons = document.getElementsByTagName('button');
    for (const button of buttons) {
        button.addEventListener('click', toggleInfo);
    }
})();
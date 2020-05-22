function attachEvents() {
    async function handleCreatePlayer(event) {
        const nameInput = document.querySelector('input#addName');
        const name = nameInput.value;

        await database.createPlayer(name);

        nameInput.value = '';

        refreshAllPLayers();
    }

    async function refreshAllPLayers() {
        const players = await database.getAllPlayers();
        const playersDiv = document.querySelector('div#players');

        playersDiv.innerHTML = '';

        playersInRound = {};
        for (const id in players) {
            const player = players[id];

            playersInRound[id] = player;
            const card = createCardFromPlayer(player, id);
            playersDiv.appendChild(card);
        }
    }

    async function handleSave() {
        hideCanvas();

        await save();

        refreshAllPLayers()
    }

    async function save() {
        const canvas = document.querySelector('canvas#canvas');
        clearInterval(canvas.intervalId);

        const player = playersInRound[currentPlayerId];
        await database.updatePlayer(player, currentPlayerId);
    }

    async function handleDeletePlayer(event) {
        const id = event.target.parentNode.dataset['playerId'];

        await database.deletePlayer(id);

        refreshAllPLayers();
    }

    function handleReload(id) {
        const player = playersInRound[currentPlayerId];

        if (player.money >= 60) {
            player.money -= 60;
            player.bullets = 6;
        }
    }

    function handlePlay(event) {
        const id = event.target.parentNode.dataset['playerId'];
        const player = playersInRound[id];
        currentPlayerId = id;

        save();

        showCanvas();

        loadCanvas(player);
    }

    function capitalize(word) {
        return `${word[0].toUpperCase()}${word.slice(1)}`;
    }

    // Using separate show and hide functions instead of toggle
    // to avoid bug where while playing with one player, selecting play with another without saving hides the canvas
    function showCanvas() {
        const canvas = document.querySelector('canvas#canvas');
        const saveButton = document.querySelector('button#save');
        const reloadButton = document.querySelector('button#reload');

        canvas.style.display = 'block';
        saveButton.style.display = 'inline-block';
        reloadButton.style.display = 'inline-block';
    }

    function hideCanvas() {
        const canvas = document.querySelector('canvas#canvas');
        const saveButton = document.querySelector('button#save');
        const reloadButton = document.querySelector('button#reload');

        canvas.style.display = 'none';
        saveButton.style.display = 'none';
        reloadButton.style.display = 'none';
    }

    function createCardFromPlayer(player, id) {
        const card = document.createElement('div');
        card.classList.add('player');
        card.dataset['playerId'] = id;

        for (const property in player) {
            const item = document.createElement('div');
            item.classList.add('stat');

            item.textContent = ` ${capitalize(property)}: ${player[property]}`;

            card.appendChild(item);
        }

        const playButton = document.createElement('button');
        playButton.textContent = 'Play';
        playButton.classList.add('play');
        playButton.addEventListener('click', handlePlay)
        card.appendChild(playButton);

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.classList.add('delete');
        deleteButton.addEventListener('click', handleDeletePlayer)
        card.appendChild(deleteButton);

        return card;
    }

    let playersInRound = {};
    let currentPlayerId = null;
    refreshAllPLayers();

    document.querySelector('button#addPlayer')
        .addEventListener('click', handleCreatePlayer);

    document.querySelector('button#save')
        .addEventListener('click', handleSave);

    document.querySelector('button#reload')
        .addEventListener('click', handleReload);
}
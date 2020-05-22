const database = (function () {
    // Some of these functions appear unnecessarily async
    // because otherwise synchronization issues appear between functions like deletePlayer() and loadAllPlayers(),
    // wherein it refreshes before the player is actually deleted. The solution is to await a response,
    // therefore making sure that the action has been taken before refreshing
    async function createPlayerAsync(name) {
        const playerData = {
            name,
            money: 500,
            bullets: 6
        };

        await fetch(`${api}.json`, {
            method: 'POST',
            body: JSON.stringify(playerData)
        });
    }

    async function getAllPlayersAsync() {
        const response = await fetch(`${api}.json`);
        const players = await response.json();

        return players;
    }

    async function updatePlayerASync(playerData, id) {
        await fetch(`${api}/${id}.json`, {
            method: 'PUT',
            body: JSON.stringify(playerData)
        });
    }

    async function deletePlayerAsync(id) {
        await fetch(`${api}/${id}.json`, {
            method: 'DELETE'
        });
    }

    const api = 'https://wild-wild-west-252b8.firebaseio.com/players';

    return {
        createPlayerAsync,
        getAllPlayersAsync,
        updatePlayerASync,
        deletePlayerAsync
    }
})();
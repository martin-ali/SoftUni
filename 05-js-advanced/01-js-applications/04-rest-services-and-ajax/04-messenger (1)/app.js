function attachEvents()
{
    const messagesTextArea = document.getElementById('messages');
    const refreshButton = document.getElementById('refresh');
    const sendButton = document.getElementById('submit');

    async function handleRefresh(event)
    {
        const messagesJson = await http.getAsync('https://rest-messanger.firebaseio.com/messanger.json');
        const messages = JSON.parse(messagesJson);

        let chat = '';
        for (const id in messages)
        {
            const { author, content } = messages[id];
            chat += `${author}: ${content}\n`;
        }

        messagesTextArea.textContent = chat.trim();
    };

    async function handleSend(event)
    {
        const authorInput = document.getElementById('author');
        const messageInput = document.getElementById('content');

        const author = authorInput.value;
        const message = messageInput.value;

        const postJson = JSON.stringify({ author, content: message });

        authorInput.value = '';
        messageInput.value = '';

        await http.postAsync('https://rest-messanger.firebaseio.com/messanger.json', postJson);

        handleRefresh();
    }

    refreshButton.addEventListener('click', handleRefresh);
    sendButton.addEventListener('click', handleSend);
}

attachEvents();
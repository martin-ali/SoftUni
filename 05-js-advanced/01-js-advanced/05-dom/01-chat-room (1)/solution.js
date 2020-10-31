function solve()
{
    const sendButton = document.getElementById('send');
    sendButton.addEventListener('click', event =>
    {
        const messageTextArea = document.getElementById('chat_input');
        const message = messageTextArea.value;

        const textDiv = document.createElement('div');
        textDiv.classList.add('message');
        textDiv.classList.add('my-message');
        textDiv.textContent = message;

        const messagesDiv = document.getElementById('chat_messages');
        messagesDiv.appendChild(textDiv);

        messageTextArea.value = '';
    });
}
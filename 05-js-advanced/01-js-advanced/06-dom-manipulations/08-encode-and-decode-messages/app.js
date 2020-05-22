function encodeAndDecodeMessages()
{
    const [encodeButton, decodeButton] = document.getElementsByTagName('button');
    const [senderTextArea, receiverTextArea] = document.getElementsByTagName('textarea');

    encodeButton.addEventListener('click', event =>
    {
        const rawMessage = senderTextArea.value;
        let encodedMessage = '';

        for (let index = 0; index < rawMessage.length; index++)
        {
            encodedMessage += String.fromCharCode(rawMessage.charCodeAt(index) + 1);
        }

        receiverTextArea.value = encodedMessage;
        senderTextArea.value = '';
    });

    decodeButton.addEventListener('click', event =>
    {
        const encodedMessage = receiverTextArea.value;
        let rawMessage = '';

        for (let index = 0; index < encodedMessage.length; index++)
        {
            rawMessage += String.fromCharCode(encodedMessage.charCodeAt(index) - 1);
        }

        receiverTextArea.value = rawMessage;
    });
}
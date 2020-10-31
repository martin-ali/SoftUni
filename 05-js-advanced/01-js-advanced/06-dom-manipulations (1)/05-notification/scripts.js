function notify(message)
{
    const notificationDiv = document.getElementById('notification');

    notificationDiv.textContent = message;
    notificationDiv.style.display = 'block';

    setTimeout(event =>
        {
            notificationDiv.style.display = 'none';
        },
        2000);
}
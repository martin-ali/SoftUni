class NotificationsHandler
{
    timeoutMs;

    constructor(timeoutMs)
    {
        this.timeoutMs = timeoutMs;
    }

    success(message)
    {
        const notificationBox = document.querySelector('#successNotification');

        notificationBox.textContent = message;
        // @ts-ignore
        notificationBox.style.display = 'block';

        setTimeout(() =>
            {
                // @ts-ignore
                notificationBox.style.display = 'none';
            },
            this.timeoutMs);
    }

    error(message)
    {
        const notificationBox = document.querySelector('#errorNotification');

        notificationBox.textContent = message;
        // @ts-ignore
        notificationBox.style.display = 'block';

        setTimeout(() =>
            {
                // @ts-ignore
                notificationBox.style.display = 'none';
            },
            this.timeoutMs);
    }

    loading()
    {
        const notificationBox = document.querySelector('#loadingNotification');

        // @ts-ignore
        notificationBox.style.display = 'block';

        setTimeout(() =>
            {
                // @ts-ignore
                notificationBox.style.display = 'none';
            },
            this.timeoutMs);
    }
}

export default NotificationsHandler;

/* <div id="successBox" class="alert alert-success" role="alert">{{notification.message}}</div>
    <div id="loadingBox" class="alert alert-info" role="alert">Loading...</div>
    <div id="errorBox" class="alert alert-danger" role="alert">{{notification.message}}</div> */
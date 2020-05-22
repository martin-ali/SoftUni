class NotificationHandler {

    container;
    timeoutMs;

    constructor(containerSelector, timeoutMs) {
        this.container = document.querySelector(containerSelector);
        this.timeoutMs = timeoutMs;
    }

    success(message) {
        this._appendNotification(message, 'bg-success')
    }

    error(message) {
        this._appendNotification(message, 'bg-danger')
    }

    _appendNotification(message, type) {
        const notification = document.createElement('div');
        notification.classList.add(type, 'p-3', 'mb-2', 'text-white', 'text-center')

        notification.textContent = message;
        this.container.appendChild(notification);

        setTimeout(
            () => this.container.removeChild(notification),
            this.timeoutMs);
    }
}

export default NotificationHandler;
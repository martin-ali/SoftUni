// jshint esversion: 6

const
{
    app,
    BrowserWindow
} = require('electron');
const path = require('path');
const url = require('url');

let window;

function createWindow()
{
    window = new BrowserWindow(
    {
        width: 750,
        height: 350,
        rezisable: false
    });

    window.loadURL(url.format(
    {
        pathname: path.join(__dirname, 'index.html'),
        protocol: 'file:',
        slashes: true
    }));

    window.on('closed', () =>
    {
        wind = null;
    });
}

app.on('ready', createWindow);

app.on('window-all-closed', () =>
{
    app.quit();
});

app.on('activate', () =>
{
    if (win == null)
    {
        createWindow();
    }
});
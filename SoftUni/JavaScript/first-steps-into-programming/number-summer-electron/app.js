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
        height: 250,
        resizable: false
    });

    window.loadURL(url.format(
    {
        pathname: path.join(__dirname, 'index.html'),
        protocol: 'file:',
        slashes: true
    }));

    window.on('closed', () =>
    {
        window = null;
    });
}

app.on('ready', createWindow);
app.on('window-all- closed', () =>
{
    app.quit();
});

app.on('activate', () =>
{
    if (window === null)
    {
        createWindow();
    }
});

function calc()
{
    let num1 = Number(document.getElementById("num1").value);
    let num2 = Number(document.getElementById("num2").value);
    document.getElementById("sum").value = num1 + num2;
}
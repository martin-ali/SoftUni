// jshint esversion:6
const
{
    app,
    BrowserWindow
} = require("electron");
const path = require("path");
const url = require("url");
let win;

function createWindow()
{
    win = new BrowserWindow(
    {
        width: 750,
        height: 300,
        resizable: false,
        darkTheme: true
    });
    win.loadURL(url.format(
    {
        pathname: path.join(__dirname, "index.html"),
        protocol: "file:",
        slashes: true
    }));

    win.on("closed", () =>
    {
        win = null;
    });
}

app.on("ready", createWindow);
app.on("window-all- closed", () =>
{
    app.quit();
});

app.on("activate", () =>
{
    if (win === null)
    {
        createWindow();
    }
});

function draw()
{
    //Create canvas element
    let canvas = document.getElementById("a");
    let context = canvas.getContext("2d");

    //Clear canvas window
    context.clearRect(0, 0, canvas.width, canvas.height);

    //Get input for rectangle coordinates
    let rectX1 = Number(document.getElementById("rect-x1").value) * 10;
    let rectY1 = Number(document.getElementById("rect-y1").value) * 10;
    let rectX2 = Number(document.getElementById("rect-x2").value) * 10;
    let rectY2 = Number(document.getElementById("rect-y2").value) * 10;

    //Calculate rectangle parameters
    let rectWidth = Math.abs(rectX1 - rectX2);
    let rectHeight = Math.abs(rectY1 - rectY2);

    //Set rectangle style
    context.strokeStyle = "#ff0000";
    context.lineWidth = 3;

    //Draw rectangle with given parameters
    context.strokeRect(rectX1, rectY1, rectWidth, rectHeight);

    //Get input for point coordinates
    let pointX = Number(document.getElementById("point-x").value) * 10;
    let pointY = Number(document.getElementById("point-y").value) * 10;

    //Set point style and draw point
    context.beginPath();
    context.fillStyle = "#ffcc00";
    context.arc(pointX, pointY, 4, 0, 2 * Math.PI);
    context.closePath();
    context.fill();

    //Assign variables to (div id="result") and (span id="status") html elements
    let result = document.getElementById("status");
    let output = document.getElementById("result");
    //Check point position
    if (pointX > rectX1 && pointX < rectX2 && pointY > rectY1 && pointY < rectY2)
    {
        result.innerHTML = "Inside";
        output.style.backgroundColor = "palegreen";
    }
    else if ((pointX == rectX1 || pointX == rectX2) && pointY > rectY1 && pointY < rectY2 ||
        (pointY == rectY1 || pointY == rectY2) && pointX > rectX1 && pointX < rectX2)
    {
        result.innerHTML = "Border";
        output.style.backgroundColor = "gold";
    }
    else
    {
        result.innerHTML = "Outside";
        output.style.backgroundColor = "lightsalmon";
    }
}
function chaseMaus()
{
    let imageToChase = document.getElementById('imgMaus');

    imageToChase.style.position = "absolute";
    imageToChase.style.top = (Math.random() * 300) + 'px';
    imageToChase.style.left = (Math.random() * 300) + 'px';
}

function catchMaus()
{
    alert("Conglaturation! You are winner!");
}
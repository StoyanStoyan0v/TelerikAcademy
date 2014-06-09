function onClickButton() {
    var bodyElem = document.getElementsByTagName('body')[0],
        count = document.getElementById('count').value;

    function generateRandomColor() {
        var red = (Math.random() * 256) | 0;
        var green = (Math.random() * 256) | 0;
        var blue = (Math.random() * 256) | 0;

        return "rgb(" + red + "," + green + "," + blue + ")";
    }

    for (var i = 0; i < count; i++) {
        var divElem = document.createElement('div');

        divElem.style.width =   Math.random()+0.2 * 100 + 'px';
        divElem.style.height = Math.random() + 0.2 * 100 + 'px';
        divElem.style.backgroundColor = generateRandomColor();
        divElem.style.color = generateRandomColor();
        divElem.innerHTML = '<strong>div<strong>';
        divElem.style.borderWidth = Math.random() * 20 + 'px';
        divElem.style.borderStyle = 'solid';
        divElem.style.borderColor = generateRandomColor();
        divElem.style.borderRadius = Math.random() * 50 + 'px';
        divElem.style.position = 'absolute';
        divElem.style.top = Math.random()* (screen.height - 100)+'px';
        divElem.style.left = Math.random() * (screen.width - 100)+'px';
        bodyElem.appendChild(divElem);
    }
}









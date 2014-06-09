function onLoad() {
    
    function moveDiv(degrees, divsArr) {
        for (var i in divsArr) {
            degrees = degrees + 5/2;
            var r = 100,
                xcenter = 200,
                ycenter = 200,
                x = Math.floor(xcenter + (r * Math.cos(degrees / 2))), //circles parametric function
                y = Math.floor(ycenter + (r * Math.sin(degrees / 2))); //circles parametric function
            divsArr[i].style.top = x + "px";
            divsArr[i].style.left = y + "px";
        }

        setTimeout(function () {
            moveDiv(degrees, divsArr);
        }, 40);
    }

    function generateRandomColor() {
        var red = (Math.random() * 256) | 0;
        var green = (Math.random() * 256) | 0;
        var blue = (Math.random() * 256) | 0;

        return "rgb(" + red + "," + green + "," + blue + ")";
    }

    var divs = [5],
        bodyElem = document.getElementsByTagName('body')[0];

    for (var i = 0; i < 5; i++) {
        divs[i] = document.createElement('div');
        divs[i].innerHTML = '☻';
        divs[i].style.width = '100px';
        divs[i].style.heigth = '100px';
        divs[i].style.color = generateRandomColor();
        divs[i].style.fontSize = '100px';
        divs[i].style.position = 'absolute';
        bodyElem.appendChild(divs[i]);               
    }
    moveDiv(1, divs)
}
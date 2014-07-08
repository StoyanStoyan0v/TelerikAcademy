var Renderer= (function () {


    var canvas = document.getElementById('canvas-container'),
        ctx = canvas.getContext('2d');
    function Renderer () {
    }


    Renderer.renderScreen = function (screen) {
        if (!screen instanceof GameObjects.Screen) {
            throw new Error('Invalid object passed!');
        }
        canvas.clientWidth = screen.width;
        canvas.clientHeight = screen.height;
        canvas.style.border= '1px solid #ff0000';

    };


    Renderer.renderCell = function (cell, strokeColor, fillColor) {

        ctx.beginPath();
        ctx.strokeStyle = strokeColor;
        ctx.fillStyle = fillColor;
        ctx.moveTo(cell.x + cell.r, cell.y);
        ctx.arc(cell.x, cell.y, 20, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.fill();

    };

    Renderer.renderScore = function (score,font) {
        ctx.font = font;
        ctx.fillText("Result: " + score, 5, canvas.clientHeight - 15);
    };

    Renderer.clear = function (screen) {
        ctx.clearRect(0, 0, screen.width, screen.height);
    };

    return Renderer;
})();




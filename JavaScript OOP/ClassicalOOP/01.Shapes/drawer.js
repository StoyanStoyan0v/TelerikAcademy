var Drawer = (function () {
    var ctx;

    function Drawer() {
        var canvas = document.getElementById('canvas-container');
            ctx = canvas.getContext('2d');
    }

    Drawer.prototype.draw = function (shape) {
        if (shape.draw) {
            shape.draw(ctx);
        } else {
            alert('This '+typeof shape+' has not a draw function!');
        }
    };
    return Drawer;
}());

window.addEventListener('load', function () {
    var drawer = new Drawer(),
        cachedPosition = new Position(700, 400),
        shapes = [
            new Rect(10, 10, 100, 50),
            new Rect(new Position(100, 500), 200, 100),
            new Circle(300, 150, 100),
            new Circle(new Position(500, 150), 100),
            new Circle(400, 320, 100),
            new Line(500, 400, 600, 500),
            new Line(new Position(600, 500), cachedPosition),
            new Line(cachedPosition, 800, 500),
            new Line(800, 500, new Position(900, 400))
    ];


    for (var i = 0; i < shapes.length; i++) {
        drawer.draw(shapes[i]);
    }

    //Invalid shape
    drawer.draw("Some string that has not draw function!");
});

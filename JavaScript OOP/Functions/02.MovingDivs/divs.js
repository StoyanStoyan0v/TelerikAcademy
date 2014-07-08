var movingShapes = (function () {

    function getRandomColour() {
        var red = (Math.random() * 256) | 0;
        var green = (Math.random() * 256) | 0;
        var blue = (Math.random() * 256) | 0;

        return "rgb(" + red + "," + green + "," + blue + ")";
    }

    function generateShape() {

        var div = $('<div/>');
        div.css('width', '50px').css('height', '50px').
            css('backgroundColor', getRandomColour()).
            css('color', getRandomColour()).css('borderColor', getRandomColour()).
            css('position', 'absolute').text('☻').css('textAlign', 'center').
            css('fontSize', '35px');


        return div;
    }

    function moveRectangular(shape) {
        var direction = 4,
            width = Math.random() * 300+1,
            height = Math.random() * 150+1,
            top = Math.random() * 600,
            left = Math.random() * 800;
        shape.css('top', top).css('left', left)
        $('#container').append(shape);

        move(left, top);
        function move(x, y) {
            if (x - left < width && y - top <= 0) {
                y = top;
                x += direction;
            } else if (x - left >= width && y - top < height) {
                x = left + width;
                y += direction;
            }

            if (y - top >= height && x - left > 0) {
                y = top + height;
                x -= direction;
            } else if (y - top > 0 && x - left <= 0) {
                x = left;
                y -= direction;
            }
            shape.css('top', y).css('left', x);

            setTimeout(function () {
                move(x, y)
            }, 20);
        }
    }

    function moveCircular(shape) {

        var top = Math.random() * 600,
            left = Math.random() * 800,
            r = Math.random() * 200+1;
        shape.css('borderRadius', '50px');
        $('#container').append(shape);

        move(1);

        function move(degrees) {
            degrees += 0.1;
            var x = Math.floor(left + (r * Math.cos(degrees / 2))), //circles parametric function
                y = Math.floor(top + (r * Math.sin(degrees / 2))); //circles parametric function
            shape.css('top', y).css('left', x);

            setTimeout(function () {
                move(degrees);
            }, 20);
        }

    }

    function add(movementType) {
        var shape = generateShape();

        switch (movementType) {
            case 'rect':
                moveRectangular(shape);
                break;
            case 'ellipse':
                moveCircular(shape);
                break;
            default:
                alert('Unknown movement type!');
                break;
        }
    }

    return{
        add: add
    }

})();

$(document).ready(function () {
    $('#add-shape-btn').click(function () {
        var movementType = $('#movement-type').val();
        movingShapes.add(movementType);
    });
});
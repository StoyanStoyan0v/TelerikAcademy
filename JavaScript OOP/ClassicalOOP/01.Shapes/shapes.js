//Position objects can be passed to the shapes constructors as well as x and y coordinates. Check the constructors below
var Position = (function () {
    function Position(x,y) {
        this.x=x;
        this.y=y;
    }
    return Position;
}());

var Rect= (function () {
    function Rect(x, y, width, height) {
        if (arguments.length === 4) {
            this.startPosition = new Position(arguments[0], arguments[1]);
            this.width = arguments[2];
            this.height = arguments[3];
        } else {
            this.startPosition = arguments[0];
            this.width = arguments[1];
            this.height = arguments[2];
        }


    }

    Rect.prototype.draw = function (ctx) {
        ctx.fillRect(this.startPosition.x, this.startPosition.y, this.width, this.height);
        ctx.strokeRect(this.startPosition.x, this.startPosition.y, this.width, this.height);
    };

    return Rect;
}());

var Circle= (function () {
    function Circle(x, y, r) {
        if (arguments.length === 3) {
            this.center = new Position(arguments[0], arguments[1]);
            this.r = arguments[2];
        } else {
            this.center = arguments[0];
            this.r = arguments[1];
        }
    }

    Circle.prototype.draw = function (ctx) {
        ctx.beginPath();
        ctx.arc(this.center.x, this.center.y, this.r, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.fill();
    };

    return Circle;
}());

var Line = (function () {
    function Line(x1, y1, x2, y2) {
        if (arguments.length === 4) {
            this.startPosition = new Position(arguments[0], arguments[1]);
            this.endPosition = new Position(arguments[2], arguments[3]);
        } else if (arguments.length === 2) {
            this.startPosition = arguments[0];
            this.endPosition = arguments[1];
        } else {
            if (arguments[0] instanceof Position) {
                this.startPosition = arguments[0];
                this.endPosition = new Position(arguments[1], arguments[2]);
            } else {
                this.startPosition = new Position(arguments[0], arguments[1]);
                this.endPosition = arguments[2];
            }
        }
    }

    Line.prototype.draw = function (ctx) {
        ctx.beginPath();
        ctx.moveTo(this.startPosition.x, this.startPosition.y);
        ctx.lineTo(this.endPosition.x, this.endPosition.y);
        ctx.stroke();
    }
    return Line;
}());
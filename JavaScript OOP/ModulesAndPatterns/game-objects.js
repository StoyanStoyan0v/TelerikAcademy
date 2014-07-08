var GameObjects = (function () {
    var Screen, Snake, Food, Cell, Score, SPEED = 14, SnakeConstants = {
        DIRECTIONS: {
            RIGHT: {X: SPEED,
                Y: 0},
            LEFT: {X: -SPEED,
                Y: 0},
            UP: {X: 0,
                Y: -SPEED},
            DOWN: {X: 0,
                Y: SPEED}
        },
        INITIAL_DIRECTION: 'RIGHT'

    };

    Cell = (function () {

        function Cell(x, y, r) {
            this.x = x;
            this.y = y;
            this.r = r;
        }

        Cell.prototype.render = function (cell, strokeColor, fillColor) {

            Renderer.renderCell(this, strokeColor, fillColor);

        };

        return Cell;
    }());

    Screen = (function () {

        function Screen(width, height) {
            this.width = width;
            this.height = height;
        }

        Screen.prototype.render = function () {

            Renderer.renderScreen(this);
        };

        return Screen;
    }());

    Snake = (function () {

        function initializeSnake(body, r) {

            for (var i = 0; i < body.length; i++) {
                body[i] = new Cell(r + SnakeConstants.DIRECTIONS.RIGHT.X * i, r, r);
            }
        }

        function Snake(r, length) {

            this.body = new Array(length);
            initializeSnake(this.body, r);
            this.head = new Cell(this.body[length - 1].x, this.body[length - 1].y, r);
            this.direction = SnakeConstants.INITIAL_DIRECTION;


        }

        Snake.prototype.update = function () {
            this.head.x += SnakeConstants.DIRECTIONS[this.direction].X;
            this.head.y += SnakeConstants.DIRECTIONS[this.direction].Y;
            this.body.push(new Cell(this.head.x, this.head.y, this.head.r));
        };


        Snake.prototype.render = function () {
            for (var i = 0; i < this.body.length; i++) {
                this.body[i].render(this.body[i], 'red', 'red');
            }
        };

        return Snake;
    }());

    Food = (function () {

        function generateFood(width, height, r) {
            var randomX = Math.round(Math.random() * width),
                randomY = Math.round(Math.random() * height);

            while ((randomX - r) % SPEED !== 0) {
                randomX = Math.round(Math.random() * width);
            }

            while ((randomY - r) % SPEED !== 0) {
                randomY = Math.round(Math.random() * height);
            }

            return new Cell(randomX, randomY, r)
        }

        function Food(dimensions, r) {

            if (!dimensions instanceof Screen) {
                throw new Error('Invalid object passed to the constructor!');
            }

            this.foodCell = generateFood(dimensions.width, dimensions.height, r);
        }


        Food.prototype.render = function () {
            Renderer.renderCell(this.foodCell, 'red', 'blue');
        };

        return Food;
    }());

    Score = (function () {

        function Score(font) {
            this.font = font;
            this.points = 0;
        }

        Score.prototype.render = function () {
            Renderer.renderScore(this.points, this.font);
        };

        return Score;
    }());


    return {
        Screen: Screen,
        Snake: Snake,
        Food: Food,
        Score: Score
    }
}());

var SnakeGame = (function () {


    SnakeGame = (function () {
        var SCREEN = {
                WIDTH: 800,
                HEIGHT: 600
            }, SNAKE_INITIAL_LENGTH = 5,
            SNAKE_HEAD_R = 7,
            SNAKE_DIRECTIONS = ['RIGHT', "LEFT", "UP", "DOWN"],
            FONT = "20px Verdana",
            GAME_SPEED =70,
            screen, snake, food, score;

        function SnakeGame() {
            screen = new GameObjects.Screen(SCREEN.WIDTH, SCREEN.HEIGHT);
            snake = new GameObjects.Snake(SNAKE_HEAD_R, SNAKE_INITIAL_LENGTH);
            food = new GameObjects.Food(screen, snake.head.r);
            score = new GameObjects.Score(FONT);
        }


        function update() {
            snake.update();

            if (CollisionDetector.checkWallCollision(screen, snake) || CollisionDetector.selfEatingCollision(snake)) {
                SnakeGame();
            }

            if (CollisionDetector.checkFoodCollision(snake.head, food.foodCell)) {
                score.points += 10;
                food = new GameObjects.Food(screen,snake.head.r);

            } else {
                snake.body.shift();
            }



        }

        function render() {
            snake.render();
            food.render();
            score.render();
        }

        function events() {
            $(window).on('keydown', function (e) {
                if (e.keyCode == "37" && snake.direction !== SNAKE_DIRECTIONS[0]) {
                    snake.direction = SNAKE_DIRECTIONS[1];
                } else if (e.keyCode == "38" && snake.direction !== SNAKE_DIRECTIONS[3]) {
                    snake.direction = SNAKE_DIRECTIONS[2];
                } else if (e.keyCode == "39" && snake.direction !== SNAKE_DIRECTIONS[1]) {
                    snake.direction = SNAKE_DIRECTIONS[0];
                } else if (e.keyCode == "40" && snake.direction !== SNAKE_DIRECTIONS[2]) {
                    snake.direction = SNAKE_DIRECTIONS[3];
                }
            });
        }

        SnakeGame.prototype.start = function () {
            var gameLoop;
            events();
            screen.render();

            function animationFrame() {
                Renderer.clear(screen);
                update();
                render();

                if (typeof gameLoop !== "undefined") {
                    clearInterval(gameLoop);
                }
                gameLoop = setInterval(animationFrame, GAME_SPEED);

            }

            animationFrame();

        };
        return SnakeGame;

    }());


    return SnakeGame;
}());

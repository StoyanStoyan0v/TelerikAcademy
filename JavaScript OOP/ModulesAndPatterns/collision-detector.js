var CollisionDetector = (function () {

    function CollisionDetector() {

    }

    CollisionDetector.checkFoodCollision = function (snakeHead,food) {

        return  snakeHead.x === food.x && snakeHead.y=== food.y;

    };

    CollisionDetector.checkWallCollision = function (screen,snake) {
        return (snake.head.x + snake.head.r > screen.width || snake.head.x - snake.head.r < 0) ||
            (snake.head.y + snake.head.r > screen.height || snake.head.y - snake.head.r < 0)
    };

    CollisionDetector.selfEatingCollision= function (snake) {
        var snakeBody = snake.body;
        for (var i = 0; i < snakeBody.length - 1; i++) {
            if (snakeBody[i].x === snake.head.x && snakeBody[i].y === snake.head.y) {
                return true;
            }
        }
        return false;
    };
    return CollisionDetector;

})();

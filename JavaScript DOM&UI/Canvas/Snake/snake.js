(function () {
    function initializeGame() {
        r = 10,
        changeX = 20,
        changeY = 20,
        direction = 'right',
        snakeLength = 4,
        snake = [{ x: 10, y: 10 }, { x: 30, y: 10 }, { x: 50, y: 10 }, { x: 70, y: 10 }],
        headX = snake[snakeLength - 1].x,
        headY = snake[snakeLength - 1].y,
        result = 0;

        generateFoodCoords();
    }

    window.addEventListener("keydown", checkForPressedKey, false);
    
    function checkForPressedKey(e) {
        if (e.keyCode == "37" && direction !== "right") {
            direction = "left";
        } else if (e.keyCode == "38" && direction !== "down") {
            direction = "up";
        } else if (e.keyCode == "39" && direction !== "left") {
            direction = "right";
        } else if (e.keyCode == "40" && direction !== "up") {
            direction = "down";
        }
    }

    function drawSnake() {
        ctx.strokeStyle = "white";
        ctx.fillStyle = "blue";
        var stX = 0,
            stY = 0;

        for (var i = 0; i < snakeLength; i++) {
            stX = snake[i].x;
            stY = snake[i].y;
            ctx.moveTo(stX + r, stY);
            ctx.arc(stX, stY, r, 0, 2 * Math.PI);
        }
        ctx.fill();
        ctx.stroke();

        switch (direction) {
            case 'right':
                headX += changeX;
                break;
            case 'left':
                headX -= changeX;
                break;
            case 'down':
                headY += changeY;
                break;
            case 'up':
                headY -= changeY;
                break;
        }

        snake.push({ x: headX, y: headY });
        if (headX === food.x && headY === food.y) {
            snakeLength++;
            result += 10;
            generateFoodCoords();
        } else {
            snake.shift();
        }

        ctx.font = "20px Verdana";
        ctx.fillText("Result: " + result, 5, canvas.clientHeight - 15);

    }

    function generateFoodCoords() {
        var randomX = Math.round(Math.random() * canvas.clientWidth),
            randomY = Math.round(Math.random() * canvas.clientHeight);

        while ((randomX - 10) % 20 !== 0) {
            randomX = Math.round(Math.random() * canvas.clientHeight);
        }

        while ((randomY - 10) % 20 !== 0) {
            randomY = Math.round(Math.random() * canvas.clientHeight);
        }

        food = {
            x: randomX,
            y: randomY
        };
    }

    function drawFood() {
        ctx.beginPath();
        ctx.strokeStyle = "white";
        ctx.fillStyle = "red";
        ctx.moveTo(food.x + r, food.y);
        ctx.arc(food.x, food.y, r, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.fill();
    }

    function checkForCollision() {
        if (headX + r > canvas.clientWidth || headX - r < 0) {
            initializeGame();
        }
        if (headY + r > canvas.clientHeight || headY - r < 0) {
            initializeGame();
        }
        for (var i = 0; i < snakeLength - 1; i++) {
            if (snake[i].x === headX && snake[i].y === headY) {
                initializeGame();
            }
        }
    }

    function animationFrame() {
        ctx.clearRect(0, 0, canvas.clientWidth, canvas.clientHeight);
        ctx.beginPath();
        checkForCollision();
        drawSnake();
        drawFood();

        if (typeof gameLoop !== "undefined")
            clearInterval(gameLoop);
        gameLoop = setInterval(animationFrame, 200);
    }
    
    var canvas = document.getElementById('canvas-container'),
        ctx = canvas.getContext('2d'),
        food;
        
    initializeGame();
    animationFrame();
})();
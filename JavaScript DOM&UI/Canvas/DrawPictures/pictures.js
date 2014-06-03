(function () {
    var canvas = document.getElementById('canvas-container'),
        ctx = canvas.getContext('2d');

    ctx.fillStyle = "#90cad7";
    ctx.strokeStyle = "#327a8c";

    function drawCircle(x, y, r, startAngle, endAngle) {
        ctx.arc(x, y, r, startAngle, endAngle);
        ctx.fill();
        ctx.stroke();
    }
    
    function drawElipse(x, y, r, startAngle, endAngle, scaleX, scaleY) {
        ctx.save();
        ctx.scale(scaleX, scaleY);
        drawCircle(x, y, r, startAngle, endAngle);
        ctx.restore();
    }

    function drawEye(x, y, r, startAngle, endAngle, scaleX, scaleY) {
        drawElipse(x, y, r, startAngle, endAngle, scaleX, scaleY);
        ctx.moveTo(x * 1.5 + r / 2, y);
        ctx.save();

        ctx.beginPath();
        ctx.fillStyle = "#327a8c";
        drawElipse(x * 1.5 - 2 , y / 1.5, r / 2, startAngle, endAngle, scaleY, scaleX);
        ctx.restore();
    }

    function drawHat(x, y) {
        ctx.moveTo(x + 40, y);
        ctx.beginPath();
        ctx.fillStyle = "#327a8c";
        ctx.strokeStyle = "#000";
        ctx.lineWidth = 2;
        drawElipse(x, y, 40, 0, 2 * Math.PI, 1.5, 0.3);
        
        ctx.beginPath();
        drawElipse(x, (y - 130), 20, 0, 2 * Math.PI, 1.5, 0.5);

        ctx.beginPath();
        ctx.moveTo(x + 26 , y - 200);
        ctx.lineTo(x + 26, y - 250);
        ctx.lineTo(x + 87, y - 250);
        ctx.lineTo(x + 87, y - 200);
        ctx.fill();
        ctx.stroke();
        ctx.beginPath();

        drawElipse(x, (y - 230), 20, 0, 2 * Math.PI, 1.5, 0.5);
    }

    function drawBike() {
        var wheelsY = 300,
            firstWheelX = 100,
            secondWheelX = 250;
        drawCircle(firstWheelX, wheelsY, 45, 0, 2 * Math.PI);
        ctx.moveTo(secondWheelX + 45, wheelsY);
        drawCircle(secondWheelX, wheelsY, 45, 0, 2 * Math.PI);

        ctx.moveTo(secondWheelX, wheelsY);
        ctx.lineTo(220, 210);
        ctx.stroke();

        ctx.lineTo(190, 220);
        ctx.moveTo(220, 210);
        ctx.lineTo(240, 185);
        ctx.stroke();

        ctx.moveTo(firstWheelX, wheelsY);
        ctx.lineTo(170, wheelsY);

        ctx.moveTo(180, wheelsY);
        ctx.arc(170, wheelsY, 10, 0, 2 * Math.PI);
        ctx.moveTo(170, wheelsY);
        ctx.lineTo(230, 240);
        ctx.lineTo(140, 240);
        ctx.lineTo(170, wheelsY);
        ctx.moveTo(140, 240);
        ctx.lineTo(firstWheelX, wheelsY)
        ctx.moveTo(140, 240);
        ctx.lineTo(132, 224);
        ctx.moveTo(117, 224);
        ctx.lineTo(147, 224);
        ctx.moveTo(183, 313);
        ctx.lineTo(177, 307);
        ctx.moveTo(163, 293);
        ctx.lineTo(157, 286);
        ctx.stroke();
    }

    function drawHead() {
        ctx.beginPath();
        ctx.moveTo(220, 130);
        drawCircle(170, 130, 50, 0, 2 * Math.PI);
        ctx.moveTo(105, 240);

        ctx.beginPath();
        ctx.lineWidth = 1.5;
        ctx.save();       
        ctx.rotate(Math.PI / 18);
        drawElipse(120, 240, 15, 0, 2 * Math.PI, 1.5, 0.5)
        ctx.restore();
        ctx.moveTo(160, 130);
        ctx.lineTo(150, 130);
        ctx.lineTo(160, 110);
        ctx.stroke();
        ctx.moveTo(150, 110);        

        ctx.beginPath();
        drawEye(92, 110, 5, 0, 2 * Math.PI, 1.5, 1)

        ctx.beginPath();
        drawEye(118, 110, 5, 0, 2 * Math.PI, 1.5, 1)
      
        drawHat(113, 270);
    }

    function drawHouse() {
        var rectangleY = 200,
            rectangleX = 515,
            rectangleW = 35,
            rectangleH = 25;
        
        //The building
        ctx.beginPath();
        ctx.moveTo(500, 350);
        ctx.lineTo(700, 350);
        ctx.lineTo(700, 180);
        ctx.lineTo(600, 70);       
        ctx.lineTo(500, 180);
        ctx.lineTo(500, 350);
        ctx.moveTo(700, 180);
        ctx.lineTo(500, 180);
        ctx.fillStyle = "#975b5b";
        ctx.fill();
        ctx.stroke();

        //The chimney
        ctx.beginPath();
        ctx.moveTo(640, 150);
        ctx.lineTo(640, 100);
        ctx.lineTo(660, 100);
        ctx.lineTo(660, 150);
        ctx.fill();
        ctx.stroke();
        ctx.beginPath();
        drawElipse(650, 200, 10, 0, 2 * Math.PI, 1, 0.5);

        //The windows
        
        //First row of windows:
        ctx.fillStyle = "#000";
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleX +=rectangleW + 3;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleX += rectangleW + 25;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleX += rectangleW + 3;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);

        //Second row of windows:
        rectangleX = 515;
        rectangleY +=rectangleH + 3;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleX += rectangleW + 3;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleX += rectangleW + 25;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleX += rectangleW + 3;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        
        //Third row of windows:
        rectangleX = 515 + 2 * rectangleW + 28;
        rectangleY += rectangleH + 20;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleX += rectangleW + 3;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);

        //Fourth row of windows:
        rectangleX = 515 + 2 * rectangleW + 28;
        rectangleY += rectangleH + 3;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleX += rectangleW + 3;
        ctx.fillRect(rectangleX, rectangleY, rectangleW, rectangleH);
        rectangleY -= 2 * rectangleH - 23;

        //Door:
        
        ctx.moveTo(550, rectangleY);
        ctx.lineTo(550, 350);
        ctx.stroke();
        ctx.moveTo(550, rectangleY);
        ctx.save();
        ctx.scale(1, 0.5);
        ctx.beginPath();
        ctx.arc(550, rectangleY + 302, 30, 0, Math.PI, true);
        ctx.restore();
        ctx.stroke();

        ctx.moveTo(520, rectangleY + 14);
        ctx.lineTo(520, 350);
        ctx.moveTo(580, rectangleY + 14);
        ctx.lineTo(580, 350);
        ctx.stroke();


        ctx.moveTo(546, 325);
        ctx.arc(543, 325, 3, 0, 2 * Math.PI);

        ctx.moveTo(554, 325);
        ctx.arc(557, 325, 3, Math.PI, 3 * Math.PI);
        ctx.stroke();
    }

    drawBike();       
    drawHead();
    drawHouse();

})();
var point = {
    x: 5,
    y: 5
}

checkPoint(point);

point = {
    x: -1,
    y: -1
}
checkPoint(point);
function checkPoint() {
    var inCircle = Math.sqrt((point.x - 1) * (point.x - 1) + (point.y - 1) * (point.y - 1)) <= 3;
    var outOfRectangle = (point.x < (-1) || point.x >= (5)) || (point.y >= 1 || point.y <= (-1));
    var isInCircleAndOutOfRectangle = inCircle && outOfRectangle;
    document.write(isInCircleAndOutOfRectangle ? "The point p(" + point.x + "," + point.y +
                   ") is in the circle K((1,1)3) and out of the rectangle R(top=1, left=-1, width=6, height=2).<br>" :
                   "The point p(" + point.x + "," + point.y +
                   ") is either out of the circle K((1,1)3) or/and in the rectangle R(top=1, left=-1, width=6, height=2).<br>");
}
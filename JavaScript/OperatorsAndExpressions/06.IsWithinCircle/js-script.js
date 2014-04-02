var point = {
    x: 2,
    y: 3
}

checkIfInCircle(point);
point = {
    x: 6,
    y: 5
}
checkIfInCircle(point);
function checkIfInCircle(point) {
    if (Math.sqrt(point.x * point.x + point.y + point.y) <= 5) {
        document.writeln("The point p(" + point.x + "," + point.y + ") lies inside the circle K(0,5).<br>")
    } else {
        document.writeln("The point p(" + point.x + "," + point.y + ") lies outside the circle K(0,5).<br>")
    }
}
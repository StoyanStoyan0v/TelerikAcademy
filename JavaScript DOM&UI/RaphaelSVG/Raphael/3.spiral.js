function drawSpiral(paper) {
    var x = 700;
    var y = 400;

    var points = [];
    points.push("M900 400");
    points.push()

    for (i = 0; i < 360; i++) {
        var angle = 0.1 * i;

        x = 900 + (0 + 3 * angle) * Math.cos(angle);
        y = 400 + (0 + 3 * angle) * Math.sin(angle);
        points.push("L" + x + " " + y);
    }
    var spiral = points.join(' ');
    paper.path(spiral);
    
}
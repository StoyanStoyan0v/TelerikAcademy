var Point = function (x, y) {
    return {
        X: parseInt(x),
        Y:parseInt(y),
        toString:function() {
            return "(" + this.X + "," + this.Y + ")";
        }
    }
}
var Line = function (p1, p2) {
    return {       
        P1: p1,
        P2: p2,
        toString: function () {
            return "L(P1" + this.P1 + "," + "P2" + this.P2 + ")";
        },
        calculateLength: function () {
            return Math.sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        }
    }
}

function getLine(p1x, p1y, p2x, p2y) {
    var x1 = document.getElementById(p1x).value;
    var y1 = document.getElementById(p1y).value;
    var x2 = document.getElementById(p2x).value;
    var y2 = document.getElementById(p2y).value;
    var firstPoint = new Point(x1, y1);
    var secondPoint = new Point(x2, y2);
    return new Line(firstPoint, secondPoint);
}

function getLineStats() {
    line = getLine("p1x", "p1y", "p2x", "p2y");
    document.getElementById("generateLine").value = line;
    document.getElementById("lineLen").value = line.calculateLength();
}

function check(firstLine, secondLine, thirdLine) {
    if (firstLine.calculateLength() + secondLine.calculateLength() > thirdLine.calculateLength() && 
        firstLine.calculateLength() + thirdLine.calculateLength() > secondLine.calculateLength() &&
        thirdLine.calculateLength() + secondLine.calculateLength() > firstLine.calculateLength()) {
        return " ";
    } else {
        return " not ";
    }
}
function onClickCheck() {
    var firstLine = getLine("firstLfirstX", "firstLfirstY", "firstLsecondX", "firstLsecondY");
    var secondLine = getLine("secondLfirstX", "secondLfirstY", "secondLsecondX", "secondLsecondY");
    var thirdLine = getLine("thirdLfirstX", "thirdLfirstY", "thirdLsecondX", "thirdLsecondY");
    var lens = [firstLine.calculateLength(),secondLine.calculateLength(),thirdLine.calculateLength()];
    document.getElementById("lens").value = lens;
    document.getElementById("result").value = "The three segment lines can" + check(firstLine, secondLine, thirdLine) + "form a triangle.";
}
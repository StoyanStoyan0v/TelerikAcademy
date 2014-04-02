function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function solve() {
    var a = parseInt(document.getElementById("a").value);
    var b = parseInt(document.getElementById("b").value);
    var c = parseInt(document.getElementById("c").value);
    var det = Math.sqrt(b * b - 4 * a * c);
    
    var x1 = 0;
    var x2 = 0;
    var result = null;

    document.getElementById("equation").value = a + "x^2 + " + b + "x + " + c + " = 0";
    if (a !== 0) {
        if (b !== 0) {
            if (c !== 0) {
                if (det >= 0) {
                    if (det > 0) {
                        x1 = (((-b) + det)) / 2;
                        x2 = (((-b) - det)) / 2;
                    } else {
                        x1 = x2=((-b) / 2 * a);
                    }
                } else {
                    result = "No real roots.";
                }
            } else {
                x1 = 0;
                x2 = (-b) / a;
            }
        } else {
            x1 = -(Math.sqrt((-c) / a));
            x2 = Math.sqrt((-c) / a);
        }
    } else {
        if (b !== 0) {
            result = (-c) / b;
        } else {
            result = "No real roots!";
        }
    }
    if (result !== null) {
        if (result === "No real roots!") {
            document.getElementById("result").value = result;
        } else {
            document.getElementById("result").value = "x= " + result;
        }
    } else {
        document.getElementById("result").value = "x1= " + x1 + "\n" + "x2= " + x2;
    }
}
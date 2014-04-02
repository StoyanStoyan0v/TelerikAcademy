function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function getDigit() {
    var n = parseInt(document.getElementById("n").value);

    var result = "";

    for (var i = 1; i <= n; i++) {
        if (i % 3 === 0 && i % 7===0) {
            result += i + " ";
        }
    }
    
    document.getElementById("result").value = result;
}
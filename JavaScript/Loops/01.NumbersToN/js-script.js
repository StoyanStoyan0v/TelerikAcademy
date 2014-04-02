function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function getDigit() {
    var n = parseInt(document.getElementById("n").value);

    var result = new Array(n);

    for (var i = 0; i < n; i++) {
        result[i] = i + 1;
    }
    
    document.getElementById("result").value = result;
}
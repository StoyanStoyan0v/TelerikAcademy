function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function getMax() {
    var sequence = document.getElementById("seq").value.split(" ");
    var max = parseInt(sequence[0]);

    for (var i = 1; i < sequence.length; i++) {
        if (parseInt(sequence[i]) > max) {
            max = parseInt(sequence[i]);
        }
    }
    document.getElementById("max").value = max;
}

function getMin() {
    var sequence = document.getElementById("seq").value.split(" ");
    var min = parseInt(sequence[0]);
    
    for (var i = 1; i < sequence.length; i++) {
        if (parseInt(sequence[i]) < min) {
            min = parseInt(sequence[i]);
        }
    }
    document.getElementById("min").value = min;
}
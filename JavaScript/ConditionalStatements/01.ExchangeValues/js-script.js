function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function swap() {
    var firstNum = parseInt(document.getElementById("firstNum").value);
    var secondNum = parseInt(document.getElementById("secondNum").value);
    if (firstNum > secondNum) {
        var temp = firstNum;
        firstNum = secondNum;
        secondNum = temp;
    }
    var result = "First number: " + firstNum + " " + "Second number: " + secondNum
    document.getElementById("result").value = result;
}
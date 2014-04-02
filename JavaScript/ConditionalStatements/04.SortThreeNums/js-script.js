function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function sort() {
    var firstNum = parseInt(document.getElementById("firstNum").value);
    var secondNum = parseInt(document.getElementById("secondNum").value);
    var thirdNum = parseInt(document.getElementById("thirdNumber").value)

    var result;
    if (firstNum > secondNum && firstNum > thirdNum) {
        if (thirdNum < secondNum) {
            result = firstNum + "," + secondNum + "," + thirdNum;
        } else {
            result = firstNum + "," + thirdNum + "," + secondNum;
        }
    } else if (firstNum > secondNum && firstNum < thirdNum) {
        result = thirdNum + "," + numberOne + "," + secondNum;
    } else if (firstNum < secondNum && firstNum < thirdNum) {
        if (secondNum > thirdNum) {
            result = secondNum + "," + thirdNum + "," + firstNum;
        } else {
            result = thirdNum + "," + secondNum + "," + firstNum;
        }
    } else {
        result = secondNum + "," + firstNum + "," + thirdNum;
    }

    document.getElementById("result").value = result;
}
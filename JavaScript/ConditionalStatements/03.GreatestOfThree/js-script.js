function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function sort() {
    var firstNum = parseInt(document.getElementById("firstNum").value);
    var secondNum = parseInt(document.getElementById("secondNum").value);
    var thirdNum = parseInt(document.getElementById("thirdNumber").value)
    
    var result;
    if (firstNum > secondNum) {
        if (thirdNum > firstNum) {
            result = thirdNum;
        } else {
            result = firstNum;
        }
    } else {
        if (thirdNum > secondNum) {
            result = thirdNum;
        } else {
            result = secondNum;
        }
    }

    document.getElementById("result").value = result;
}
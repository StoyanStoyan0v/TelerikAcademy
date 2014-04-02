function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function sort() {
    var firstNum = parseInt(document.getElementById("firstNum").value);
    var secondNum = parseInt(document.getElementById("secondNum").value);
    var thirdNum = parseInt(document.getElementById("thirdNumber").value)
   
    var result;
    if (firstNum === 0 || secondNum === 0 || thirdNum === 0) {
        result = "Zero.";
    } else if ((firstNum < 0 && secondNum < 0) || firstNum > 0 && secondNum > 0) {
        if (thirdNum > 0) {
            result = "Positive.";
        } else {
            result = "Negative.";
        }
    } else {
        if (secondNum < 0) {
            if (thirdNum < 0) {
                result = "Positive.";
            } else {
                result = "Negative.";
            }
        } else {
            if (thirdNum > 0) {
                result = "Positive.";
            } else {
                result = "Negative.";
            }
        }
    }
    document.getElementById("result").value = result;
}
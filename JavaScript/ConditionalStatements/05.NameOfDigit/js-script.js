function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function getDigit() {
    var firstNum = parseInt(document.getElementById("digit").value);
    
    var result;
    switch (firstNum) {
        case 1:
            result = "One!";
            break;
        case 2:
            result = "Two!";
            break;
        case 3:
            result = "Three!";
            break;
        case 4:
            result = "Four!";
            break;
        case 5:
            result = "Five!";
            break;
        case 6:
            result = "Six!";
            break;
        case 7:
            result = "Seven!";
            break;
        case 8:
            result = "Eight!";
            break;
        case 9:
            result = "Nine!";
            break;
        case 0:
            result = "Zero!";
            break;
        default:
            result = "Unknow digit!";
            break;
    }
    document.getElementById("result").value = result;
}
function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function getNumber() {
    var firstNum = document.getElementById("number").value;

    var result;
    switch (parseInt((firstNum / 100))) {
        case 1:
            result = "one hundred ";
            break;
        case 2:
            result = "two hundreds ";
            break;
        case 3:
            result = "three hundreds ";
            break;
        case 4:
            result = "four hundreds ";
            break;
        case 5:
            result = "five hundreds ";
            break;
        case 6:
            result = "six hundreds ";
            break;
        case 7:
            result = "seven hundreds ";
            break;
        case 8:
            result = "eight hundreds ";
            break;
        case 9:
            result = "nine hundreds ";
            break;
        case 0:
            result = "";
            break;
        default:
            result = "Invalid number";
            document.getElementById("result").value = result;
            return;
    }

    if (parseInt(firstNum / 100) !== 0) {
        result += "and "
    }
    
    switch (parseInt((firstNum / 10)) % 10) {
        case 0:
            break;
        case 1: {
                switch (firstNum % 10) {
                    case 0:
                        result += "ten ";
                        break;
                    case 1:
                        result += "eleven ";
                        break;
                    case 2:
                        result += "twelve ";
                        break;
                    case 3:
                        result += "thirteen ";
                        break;
                    case 4:
                        result += "fourteen ";
                        break;
                    case 5:
                        result += "fifteen ";
                        break;
                    case 6:
                        result += "sixteen ";
                        break;
                    case 7:
                        result += "seventeen ";
                        break;
                    case 8:
                        result += "eighteen ";
                        break;
                    case 9:
                        result += "nineteen ";
                        break;
                }
            }
            break;
        case 2:
            result += "twenty ";
            break;
        case 3:
            result += "thirty ";
            break;
        case 4:
            result += "fourty ";
            break;
        case 5:
            result += "fifty ";
            break;
        case 6:
            result += "sixty ";
            break;
        case 7:
            result += "seventy ";
            break;
        case 8:
            result += "eighty ";
            break;
        case 9:
            result += "ninty ";
            break;
        default:
            break;
    }
    if (parseInt(firstNum / 10) % 10 !== 1) {
        switch (firstNum % 10) {
            case 0:
                if (firstNum === 0) {
                    result += "Zero.";
                }
                break;
            case 1:
                result += "one";
                break;
            case 2:
                result += "two";
                break;
            case 3:
                result += "three";
                break;
            case 4:
                result += "four";
                break;
            case 5:
                result += "five";
                break;
            case 6:
                result += "six";
                break;
            case 7:
                result += "seven";
                break;
            case 8:
                result += "eight";
                break;
            case 9:
                result += "nine";
                break;
        }
    }
    
    document.getElementById("result").value = result;
}
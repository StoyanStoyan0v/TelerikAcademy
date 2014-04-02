function isValidNumber(number) {
    var intRegex = /^\d+$/;
    if (!intRegex.test(number)) {
        return false;
    }
    return true;
}

function reverse(number) {
    if (isValidNumber(number)) {
        return number.split("").reverse().join("");
    } else {
        return "Invalid number!";
    }
}

function onClick() {
    var num = document.getElementById("num").value;
    document.getElementById("result").value = reverse(num);
}
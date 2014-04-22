function check(str) {
    var stack = 0;

    for (var i = 0; i < str.length && stack >= 0; i++) {
        if (str[i] === '(') {
            stack++;
        }
        else if (str[i] === ')') {
            stack--;
        }
    }

    return stack === 0;
}

function onClickCheck() {
    document.getElementById("result").value = check(document.getElementById("string").value) ? "Yes." : "No";
}
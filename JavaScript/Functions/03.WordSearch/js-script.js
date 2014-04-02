function search(text, word, isCaseSensitive) {
    var count = 0;
    if (isCaseSensitive) {
        text.split(/[\s,]+/).forEach(function (element) {
            if (element === word) {
                count++
            }
        });
        return count;
    } else {
        text.split(/[\s,.]+/).forEach(function (element) {
            if (element.toLowerCase() === word.toLowerCase()) {
                count++
            }
        });
        return count;
    }
}
function onClickSens() {
    var count = search(document.getElementById("inp").value, document.getElementById("word").value, true);
    document.getElementById("senswords").value = count + " times.";
}
function onClickInsens() {
    var count = search(document.getElementById("inp").value, document.getElementById("word").value, false);
    document.getElementById("insenswords").value = count + " times.";
}
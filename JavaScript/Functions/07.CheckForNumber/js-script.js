function check(array) {
    for (var i = 1; i < array.length - 1; i++) {
        if (parseInt(array[i]) > parseInt(array[i - 1]) && parseInt(array[i]) > parseInt(array[i + 1])) {
            return i;
        }
    }
    return -1;
}
function onClick() {
    var array = document.getElementById("seq").value.split(/[\s,]+/);
    document.getElementById("result").value = check(array) === -1 ? "Element not found!" :
                                              "Element " + array[check(array)] + " at index " + check(array) + ".";
}
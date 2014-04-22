if (!String.reverse) {
    String.prototype.reverse = function () {
        var reversed = "";
        for (var i = this.length - 1; i >= 0 ; i--) {
            reversed += this[i];
        }
        return reversed;
    }
}
function onClickReverse() {
    document.getElementById("result").value = document.getElementById("string").value.reverse();
}
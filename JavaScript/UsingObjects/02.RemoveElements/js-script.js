Array.prototype.remove = function (element) {
    var arr = [];
    this.forEach(function (currentElement) {
        if (currentElement !== element && currentElement!=="") {
            arr.push(currentElement);
        }
    });
    return arr;
}

function onClickRemove() {
    var array=document.getElementById("seq").value.trim().split(/[\s,]+/);
    document.getElementById("result").value = array.remove(document.getElementById("element").value);
}

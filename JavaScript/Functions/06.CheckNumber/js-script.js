function check(seq, pos) {
    if (parseInt(seq[pos]) > parseInt(seq[pos - 1]) && parseInt(seq[pos]) > parseInt(seq[pos + 1])) {
        return true;
    } else {
        return false;
    }
}

function onClick() {
    var seq = document.getElementById("seq").value.split(/[\s,]+/);
    var pos = document.getElementById("pos").value;
    var result;
    if (parseInt(pos) === seq.length - 1 || parseInt(pos) === 0) {
        result = "Number " + seq[pos] + " at position " + pos + " has no two neighbours.";
    } else if (parseInt(pos) > seq.length - 1 || parseInt(pos) < 0) {
        result = "The position " + pos + " is outside of the boundaries of the array."
    } else {
        result = check(seq, parseInt(pos)) ? "Number " + seq[pos] + " at position " + pos + " is bigger thant its neighbours." :
                 "Number " + seq[pos] + " at position " + pos + " is lesser than one or both of its neighbours";
    }
    document.getElementById("result").value = result;
}
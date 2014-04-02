function compare() {
    var firstArr = document.getElementById("firstArr").value.split(" ").join("");
    var secondArr = document.getElementById("secondArr").value.split(" ").join("");

    if (firstArr.length===0 || secondArr.length===0) {
        document.getElementById("result").value = "";
    } else if (firstArr > secondArr) {
        document.getElementById("result").value = secondArr + " is before " + firstArr + ".";
    } else if (firstArr < secondArr) {
        document.getElementById("result").value = firstArr + " is before " + secondArr + ".";
    } else {
        document.getElementById("result").value = "Both arrays(words) are equal lexicographically.";
    }
}
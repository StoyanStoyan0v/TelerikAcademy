var getDivCount = function () {
    var count = document.getElementsByTagName("div").length;
    var paragraph = document.createElement("p");
    var t = document.createTextNode("There are " + count + " divs in document.");
    paragraph.appendChild(t);
    document.getElementById("firstDiv").appendChild(paragraph);
}
window.onload = getDivCount;
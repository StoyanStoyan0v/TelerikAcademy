function changeBackgroundColor() {
    var color = document.getElementById('background-colour').value;
    document.getElementsByTagName('textarea')[0].style.backgroundColor = color;
}
function changeTextColor() {
    var color = document.getElementById('text-colour').value;
    document.getElementsByTagName('textarea')[0].style.color = color;
}
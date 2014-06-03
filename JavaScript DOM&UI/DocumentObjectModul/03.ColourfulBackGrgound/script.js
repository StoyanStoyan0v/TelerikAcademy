function onChangeColourButtonClick() {
    var color = document.getElementById('background-colour').value;
    document.getElementsByTagName('body')[0].style.backgroundColor = color;
}

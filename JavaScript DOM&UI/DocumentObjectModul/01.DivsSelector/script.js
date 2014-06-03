function onQuerrySelectorButtonClick() {
    var divsArr = document.querySelectorAll('div>div');
    console.log(divsArr);
    return divsArr;
}

function onTagNameSelectorButtonClick() {
    var divs = document.getElementsByTagName('div');

    var divsArr = [];

    for (var i = 0; i < divs.length; i++) {
        if (divs[i].parentNode.nodeName === 'DIV') {
            divsArr.push(divs[i]);
        }
    }

    console.log(divsArr);
    return divsArr;
}
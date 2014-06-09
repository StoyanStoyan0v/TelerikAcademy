window.onload = function () {
    var elems = document.getElementsByClassName('changeble');

    for (var i = 0; i < elems.length; i++) {
        elems[i].addEventListener('click', changeVisibility);
    }
    
    function changeVisibility(event) {
        var target;
      
        target = event.target ? event.target : event.srcElement;
        if (event.target !== this) {
            if (target.childNodes[1].style.display === 'none') {
                target.childNodes[1].style.display = 'block'
            } else {
                target.childNodes[1].style.display = 'none'
            }
        }
    }
}
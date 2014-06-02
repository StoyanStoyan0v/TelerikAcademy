function changeVisibility(event) {
    var target;

    if (!event) {
        event = window.event;
    }

    target = event.target ? event.target : event.srcElement;

    if (target.childNodes[1].style.display === 'none') {
        target.childNodes[1].style.display = 'block'
    } else {
        target.childNodes[1].style.display = 'none'
    }
}
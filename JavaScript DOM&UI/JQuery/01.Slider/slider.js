window.onload=function() {
    var current = $('.selected');
    animation();
    function moveNext() {

        if (!current.next().hasClass('arrow')) {
            current.fadeOut(1000);
            current = current.next();
            current.css({
                opacity: 0,
                display: 'inline'
            }).animate({opacity: 1}, 1000);
        } else {
            current.fadeOut(1000);
            current = current.siblings().first().next();
            current.css({
                opacity: 0,
                display: 'inline'
            }).animate({opacity: 1}, 1000);
        }
    }

    $('#right-arrow').click(moveNext);

    $('#left-arrow').click(function () {

        if (!current.prev().hasClass('arrow')) {
            current.fadeOut(500);
            current = current.prev();
            current.css({
                opacity: 0,
                display: 'inline'
            }).animate({opacity: 1}, 1000);
        } else {
            current.fadeOut(500);
            current = current.siblings().last().prev();
            current.css({
                opacity: 0,
                display: 'inline'
            }).animate({opacity: 1}, 1000);
        }
    });

    function animation () {
        setInterval(moveNext,5000);
    }

}

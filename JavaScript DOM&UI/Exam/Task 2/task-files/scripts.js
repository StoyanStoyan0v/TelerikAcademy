$.fn.gallery = function (rows) {
    var $this =$(this),
        selected=$this.find('.selected'),
        gallery=$this.find('.gallery-list'),
        next,
        prev,
        current;


    if(rows===3){
        $this.css('width','780');
    }else if(rows===4){
        $this.css('width','1045');
    }else{
        $this.css('width','1300');
    }


    $this.addClass('gallery');
    selected.hide();

    $this.find('.image-container').on('click', function () {
        var elem = $(this);

        if(elem.next().length)
        {
            next = elem.next();
        }else{
            next=$('.image-container').first();
        }

        if(elem.prev().length) {
            prev = elem.prev();
        }else{
            prev=$('.image-container').last();
        }

        current=elem;

        $('.current-image').html(elem.html());
        $('.next-image').html(next.html());
        $('.previous-image').html(prev.html());
        gallery.addClass('blurred');
        selected.show();

    });
    $this.find('.current-image').on('click', function () {
       gallery.removeClass('blurred');
       gallery.removeClass('prev').removeClass('next').removeClass('current');
        current=null;
        next=null;
        prev=null;
        selected.hide();
    });

    $this.find('.next-image').on('click', function () {
        var elem = $(this);;
        prev=current;
        current=next;
        if(next.next().length) {

            next = next.next();
        }else{
            next=$('.image-container').first();
        }

        elem.prev().prev().html(prev.html());
        elem.prev().html(current.html());
        elem.html(next.html())


    });

    $this.find('.previous-image').on('click', function () {
        var elem = $(this);;
        next=current;
        current=prev;
        if(prev.prev().length) {
            prev = prev.prev();
        }else{
            prev=$('.image-container').last();
        }
        console.log(prev);
        elem.next().next().html(next.html());
        elem.next().html(current.html());
        elem.html(prev.html())


    });
};

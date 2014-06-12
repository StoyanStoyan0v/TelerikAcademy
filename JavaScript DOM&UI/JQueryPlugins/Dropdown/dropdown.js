(function ($) {
    $.fn.dropdown= function () {
        var $this = $(this),
            $ul = $('<ul>'),
            $div = $('<div>'),
            $li,
            i,
            opts = $this.find('option');

        $this.css('display', 'none');
        $div.addClass('dropdown-list-container');
        $ul.addClass('dropdown-list-options');

        for (i = 0; i < opts.length; i++) {
            $li = $('<li>');
            $li.css('listStyleType', 'none')
                .css('width', '100px').css('border','1px solid black').css('width','90px');
            $li.html(opts[i].text);
            $ul.append($li);
        }
        $ul.css('margin','-2px -40px').hide();

        $div.append($ul);
        $('body').append($div);
        $div=$('<div>');
        $div.css('border','1px solid black').css('width','90');
        $('li').first().addClass('selected');
        $div.html($('.selected').text());
        $div.insertBefore($ul);
        $div.click(function () {
            $ul.slideToggle('slow');
        });
        $('li').mouseover(function () {
           this.style.color='white';
            this.style.background='blue';

        }).mouseout(function () {
            this.style.color='black';
            this.style.background='white';
        }).click(function () {
            $('li').removeClass('selected');
            $(this).addClass('selected');
            $div.html($('.selected').text());
        });

        return $this;
    };
}(jQuery));

$.fn.tabs = function () {
    $('#tabs-container').addClass('tabs-container');
    $('.tab-item').click(function () {
      $('.tab-item').removeClass('current');
        $('.tab-item-content').css('display','none');
        $(this).addClass('current').find('.tab-item-content').css('display','block');
    });
    $('.tab-item-content').css('display','none')
        $('.tab-item').first().addClass('current').find('.tab-item-content').css('display','block');
};
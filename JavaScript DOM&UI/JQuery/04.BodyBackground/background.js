$(document).ready(function() {
    $('#colorPicker').change(function () {
      var color= $('#colorPicker').val();
      $('body').css('background',color);
   });
});


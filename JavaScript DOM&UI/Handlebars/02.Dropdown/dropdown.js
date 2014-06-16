$(document).ready(function () {
    var items = [
        {
            value: 1,
            text: 'One'
        },
        {
            value: 2,
            text: 'Two'
        },
        {
            value: 3,
            text: 'Three'
        },
        {
            value: 4,
            text: 'Four'
        },
        {
            value: 5,
            text: 'Five'
        },
        {
            value: 6,
            text: 'Six'
        },
        {
            value:7,
            text:'Pesho'
        }
    ];


    var templateNodeHtml=$('#dropdown-template').html(),
        template = Handlebars.compile(templateNodeHtml);
    $('#dropdown-container').html(template({items:items}));
});

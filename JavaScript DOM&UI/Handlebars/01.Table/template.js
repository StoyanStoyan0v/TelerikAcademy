$('document').ready(function () {
    var table = [{ num: '0', title: 'Course Introduction',date1:'Wed 18:00,28-May-2014',date2:'Thu 14:00, 29-May-2014' },
        { num: '1', title: 'Document Object Model',date1:'Wed 18:00,28-May-2014',date2:'Thu 14:00, 29-May-2014' },
        { num: '2', title: 'HTML5 Canvas',date1:'Thu 18:00,29-May-2014',date2:'Fri 14:00, 30-May-2014' },
        { num: '3', title: 'KineticJS Overview',date1:'Thu 18:00,29-May-2014',date2:'Fri 14:00, 30-Jun-2014' },
        { num: '4', title: 'SVG and RaphaelJS',date1:'Wed 18:00,04-Jun-2014',date2:'Thu 14:00, 05-Jun-2014' },
        { num: '5', title: 'Animations with Canvas and SVG',date1:'Wed 18:00,04-Jun-2014',date2:'Thu 14:00, 05-Jun-2014' },
        { num: '6', title: 'DOM Operations',date1:'Thu 18:00,05-Jun-2014',date2:'Fri 14:00, 06-Jun-2014' },
        { num: '7', title: 'Event model',date1:'Thu 18:00,05-Jun-2014',date2:'Fri 14:00, 06-Jun-2014' },
        { num: '8', title: 'jQuery overview',date1:'Wed 18:00,11-Jun-2014',date2:'Thu 14:00, 12-Jun-2014' },
        { num: '9', title: 'HTML Templates',date1:'Wed 18:00,11-Jun-2014',date2:'Thu 14:00, 12-Jun-2014' },
        { num: '10', title: 'Exam Preparation',date1:'Thu 18:00,28-Jun-2014',date2:'Fri 14:00, 13-Jun-2014' },
        { num: '11', title: 'Exam',date1:'Tue 18:00,28-Jun-2014',date2:'Thu 16:30, 29-Jun-2014' },
        { num: '12', title: 'Teamwork Defense',date1:'Thu 18:00,28-Jun-2014',date2:'Thu 14:00, 29-Jun-2014' }
    ];

    var templateNode = $('#table-template'),
        templateHtml = templateNode.html(),
        tableTemplate = Handlebars.compile(templateHtml);
    $('#table-container').html(tableTemplate({table:table}));
});



window.onload = function () {
    var svg = document.getElementById('the-svg');
       
    createRect(svg, '0', '0', '900', '550', '#06173F', 'none', false, true);

    //Header
    createText(svg, '70', '50', '25', 'none', 'Segoe UI', '#B0BDD7', 'Start', true);
    createText(svg, '790', '45', '15', 'none', 'Segoe UI', '#B0BDD7', 'Richard', true)
    createText(svg, '816', '55', '10', 'none', 'Segoe UI', '#B0BDD7', 'Perry', true)       
    createImage(svg, '845', '33', '25', '25', 'images/MikeGibbs.jpg', true);

    //first row:
    createRect(svg, '70', '100', '85', '90', '#2776ec', 'none', true);   
    createImage(svg, '85', '115', '55', '50', 'images/store.png');
    createText(svg, '80', '185', '9', 'none', 'Segoe UI', '#fff', 'Store'), 

    createRect(svg, '165', '100', '85', '90', '#69b71d', 'none', true);
    createImage(svg, '177', '105', '60', '65', 'images/XboxLiveGames.png');
    createText(svg, '175', '185', '9', 'none', 'Segoe UI', '#fff', 'Xbox LIVE Games');

    createRect(svg, '260', '100', '165', '90', '#af1b3d', 'none', true);
    createImage(svg, '315', '115', '45', '50', 'images/photos.png');
    createText(svg, '270', '185', '9', 'none', 'Segoe UI', '#fff', 'Photos');

    createRect(svg, '435', '100', '190', '90', '#009418', 'none', true);
    createText(svg, '550', '150', '50', 'none', 'Segoe UI', '#fff', '12');
    createText(svg, '547', '160', '10', 'none', 'Segoe UI', '#fff', 'Monday');
    createText(svg, '445', '185', '9', 'none', 'Segoe UI', '#fff', 'Calendar');

    createRect(svg, '655', '100', '165', '90', '#5334ac', 'none', true);
    createImage(svg, '710', '115', '45', '50', 'images/music.png');
    createText(svg, '665', '185', '9', 'none', 'Segoe UI', '#fff', 'Music');

    createImage(svg, '815', '100', '100', '90', 'images/2s.jpg');

    //Second row

    createRect(svg, '70', '200', '85', '90', '#5334ac', 'none', true);
    createImage(svg, '85', '215', '55', '50', 'images/maps.png');
    createText(svg, '80', '285', '9', 'none', 'Segoe UI', '#fff', 'Maps'),

    createRect(svg, '165', '200', '85', '90', '#2776ec', 'none', true);
    createImage(svg, '177', '205', '60', '65', 'images/IE.png');
    createText(svg, '175', '285', '9', 'none', 'Segoe UI', '#fff', 'Internet Explorer');

    createRect(svg, '260', '200', '165', '90', '#5334ac', 'none', true);
    createImage(svg, '305', '195', '85', '90', 'images/message.png');
    createText(svg, '270', '285', '9', 'none', 'Segoe UI', '#fff', 'Messaging');//

    createRect(svg, '435', '200', '190', '90', '#d9512b', 'none', true);
    createImage(svg, '445', '210', '40', '45', 'images/MikeGibbs.jpg');
    createText(svg, '490', '222', '9', 'none', 'Segoe UI', '#B0BDD7', 'Mike Gibs, Troll Scout');
    createText(svg, '490', '232', '9', 'none', 'Segoe UI', '#B0BDD7', 'and 5 others commented');
    createText(svg, '490', '242', '9', 'none', 'Segoe UI', '#B0BDD7', 'on your photo');
    createImage(svg, '445', '260', '30', '30', 'images/ppl.png');

    createRect(svg, '655', '200', '165', '90', '#009418', 'none', true);
    createImage(svg, '710', '215', '45', '50', 'images/finance.png');
    createText(svg, '665', '285', '9', 'none', 'Segoe UI', '#fff', 'Finance');

    createRect(svg, '830', '200', '100', '90', '#0061a6', 'none', true);
    createImage(svg, '835', '210', '70', '70', 'images/pinguin.png');

    //Third row
    createRect(svg, '70', '300', '180', '90', '#d9512b', 'none', true);
    createImage(svg, '130', '315', '55', '50', 'images/video.png');
    createText(svg, '80', '385', '9', 'none', 'Segoe UI', '#fff', 'Video'),

    createRect(svg, '260', '300', '165', '90', '#009418', 'none', true);
    createText(svg, '270', '320', '15', 'none', 'Segoe UI', '#B0BDD7', 'Devon Hipnotize');
    createText(svg, '270', '330', '10', 'none', 'Segoe UI', '#B0BDD7', 'something they can do about him');
    createText(svg, '270', '340', '10', 'none', 'Segoe UI', '#B0BDD7', 'pile of books and scrools next to');
    createImage(svg, '265', '355', '35', '40', 'images/letter.png');
    createText(svg, '405', '385', '9', 'none', 'Segoe UI', '#fff', '3');

    createImage(svg, '435', '297', '90', '97', 'images/Pinball.jpg');
    createImage(svg, '535', '295', '90', '100', 'images/solitaire.png');
    
    createRect(svg, '655', '300', '77', '90', '#d9512b', 'none', true);
    createImage(svg, '670', '315', '45', '50', 'images/reader.png');
    createText(svg, '665', '385', '9', 'none', 'Segoe UI', '#fff', 'Reader');

    createRect(svg, '743', '300', '77', '90', '#01296e', 'none', true);
    createText(svg, '753', '325', '14', 'none', 'Segoe UI', '#B0BDD7', 'Windows');
    createText(svg, '753', '340', '14', 'none', 'Segoe UI', '#B0BDD7', 'Explorer');
    createImage(svg, '753', '360', '25', '25', 'images/WindowsExplorer.png');

    createRect(svg, '830', '300', '100', '90', '#2877ed', 'none', true);
    createImage(svg, '835', '310', '70', '70', 'images/skyDrive.png');
    createText(svg, '840', '385', '9', 'none', 'Segoe UI', '#B0BDD7', 'SkyDrive');

    //Fourth row
    createRect(svg, '70', '400', '180', '90', '#297c86', 'none', true);
    createImage(svg, '130', '415', '55', '50', 'images/Fish.png');
    createText(svg, '80', '485', '9', 'none', 'Segoe UI', '#fff', 'Desktop'),

    createRect(svg, '260', '400', '165', '90', '#2877ed', 'none', true);
    createImage(svg, '315', '415', '55', '50', 'images/weather.png');
    createText(svg, '270', '485', '9', 'none', 'Segoe UI', '#fff', 'Weather');

    createRect(svg, '435', '400', '90', '90', '#af1b3d', 'none', true);
    createImage(svg, '450', '415', '65', '60', 'images/camera.png');
    createText(svg, '445', '485', '9', 'none', 'Segoe UI', '#fff', 'Camera');
  

    createRect(svg, '535', '400', '90', '90', '#69b71d', 'none', true);
    createImage(svg, '550', '415', '55', '50', 'images/XboxCompanion.png');
    createText(svg, '545', '485', '9', 'none', 'Segoe UI', '#fff', 'Xbox Companion');


    createImage(svg, '655', '340', '170', '210', 'images/WordPress.jpg');


}
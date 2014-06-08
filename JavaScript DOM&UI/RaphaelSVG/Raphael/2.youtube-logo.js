function drawYouTubeLogo(paper) {

    paper.text('150', '400', 'You').attr({
        "font-weight": "bold",
        "font-size": 130,
        "font-family": "Calibri, Consolas, Arial",
        fill: "#4b4b4b"
    });

    paper.rect('260', '340', '300', '130', '35').attr({
        fill: "#EC262A",
        stroke: "#fff"
    });

    paper.text('405', '400', 'Tube').attr({
        "font-weight": "bold",
        "font-size": 130,
        "font-family": "Calibri, Consolas, Arial",
        fill: "#fff",
    });
    
}
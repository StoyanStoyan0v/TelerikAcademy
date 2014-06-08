function drawTelerikLogo(paper) {

    paper.path("M40 60 L75 25 L 150 100 L110 140 L70 100 L145 25 L180 60").attr({
        "stroke-width": 15,
        stroke: "#5ce600"
    });

    paper.text(450, 90, "Telerik®").attr({
        "font-weight": "bold",
        "font-size": 150,
        "font-family": "Calibri, Consolas, Arial"
    });

    paper.text(510, 190, "Develop experiences").attr({
        "font-size": 68,
        "font-family": "Calibri, Consolas, Arial"
    });

}
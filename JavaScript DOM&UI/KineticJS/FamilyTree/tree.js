window.onload = function () {
    function drawCell(x, y, name, cornerRadius) {
        var text = new Kinetic.Text({
                                        x: x,
                                        y: y,
                                        text: name,
                                        fontSize: 15,
                                        fill: '#000',
                                        fontFamily: 'Calibri',
                                        width: widthCell,
                                        padding: 15,
                                        align: 'center'
                                    });

        var rect = new Kinetic.Rect({
                                        x: x,
                                        y: y,
                                        stroke: "#77b300",
                                        width: text.width(),
                                        height: heigthCell,
                                        cornerRadius: cornerRadius
                                    });
        widthCell = rect.width();
        heigthCell = rect.height();
        layer.add(rect);
        layer.add(text);
    }

    function drawRelation(x1, y1, x2, y2) {
        var line = new Kinetic.Line({
                                        points: [x1, y1, x2, y2],
                                        stroke: "#77b300",

                                    });

        layer.add(line);
        drawArrow(x2, y2 + 8);
    }

    function drawArrow(x, y) {
        var triangle = new Kinetic.Line({
                                            points: [x, y, x - 5, y - 8, x + 5, y - 8],
                                            fill: "#77b300",
                                            closed: true

                                        });
        layer.add(triangle);
    }

    function checkIfMarried(person, family) {
        for (var i = 0; i < family.length; i++) {
            if (family[i].mother === person || family[i].father === person) {
                return true;
            }
        }
        return false;
    }

    function drawFamily(family) {
        if (!isLeadingFamily) {
            for (var person in stack) {
                if (family.mother === person) {
                    startingX = parseInt(stack[person].split(' ')[0]);
                    startingY = parseInt(stack[person].split(' ')[1]);
                    isFatherDrawn = false;
                } else if (family.father === person) {
                    startingX = parseInt(stack[person].split(' ')[0]);
                    startingY = parseInt(stack[person].split(' ')[1]);
                    isFatherDrawn = true;
                }
            }
        }
        isLeadingFamily = false;

        if (isFatherDrawn) {
            drawCell(startingX, startingY, family.father, maleCornerRadius);
            startingX += widthCell;

            fatherRelCoords = {
                x: startingX - widthCell / 2,
                y: startingY + heigthCell
            }

            startingX += widthIncrement;

            motherRelCoords = {
                x: startingX + widthCell / 2,
                y: startingY + heigthCell
            }
        } else {
            drawCell(startingX, startingY, family.mother, femaleCornerRadius);
            startingX += widthCell;

            motherRelCoords = {
                x: startingX - widthCell / 2,
                y: startingY + heigthCell
            }

            startingX += widthIncrement;

            fatherRelCoords = {
                x: startingX + widthCell / 2,
                y: startingY + heigthCell
            }
        }

        if (isFatherDrawn) {
            drawCell(startingX, startingY, family.mother, femaleCornerRadius);
        } else {
            drawCell(startingX, startingY, family.father, maleCornerRadius);
        }

        startingY += heigthCell + heigthIncrement;

        startingX -= 1.5 * widthCell ;

        for (var i = family.children.length - 1; i >= 0; i--) {
            if (family.children[i].indexOf('ova') !== -1) {
                drawCell(startingX, startingY, family.children[i], femaleCornerRadius);
            } else {
                drawCell(startingX, startingY, family.children[i], maleCornerRadius);
            }

            drawRelation(motherRelCoords.x, motherRelCoords.y, startingX + widthCell / 2, startingY - 8);
            drawRelation(fatherRelCoords.x, fatherRelCoords.y, startingX + widthCell / 2, startingY - 8);

            if (checkIfMarried(family.children[i], familyMembers)) {
                stack[family.children[i]] = startingX + " " + startingY;
                startingX += widthCell;
                startingX += widthIncrement;
            }
            startingX += widthCell;
            startingX += widthIncrement;
        }
    }

    var stage = new Kinetic.Stage({
                                      container: 'canvas-container',
                                      width: 1000,
                                      height: 600,
                                  }),
        layer = new Kinetic.Layer(),
        maleCornerRadius = 7,
        femaleCornerRadius = 20,
        widthCell = 150,
        heigthCell = 45,
        widthIncrement = 40,
        heigthIncrement = 50,
        startingX = 200,
        startingY = 5,
        motherRelCoords,
        fatherRelCoords,
        stack = [],
        isLeadingFamily = true,
        isFatherDrawn = true,
        familyMembers = [{
                mother: 'Petra Stamatova',
                father: 'Todor Stamatov',
                children: ['Maria Petrova']
            }, {
                mother: 'Maria Petrova',
                father: 'Georgi Petrov',
                children: ['Teodora Petrova', 'Peter Petrov']
            },{
                mother: 'Teodora Petrova',
                father: 'Stamat Ivanov',
                children: ['Teodora Ivanova', 'Georgi Ivanov']
            },{
                mother: 'Gergana Petrova',
                father: 'Peter Petrov',
                children: ['Asen Petrov', 'Margarit Petrov']
            }
        ];

    for (var i = 0; i < familyMembers.length; i++) {
        drawFamily(familyMembers[i], stack);
    }
 
    stage.add(layer);
}
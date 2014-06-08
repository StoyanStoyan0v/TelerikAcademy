window.onload = function() {
    var svg = document.getElementById('the-svg');

    createCircle(svg, '450', '130', '60', '#3E3F37');

    createPath(svg, 'M 450 110 C420 130 450 160 450 160', '#5EB14A', '#5EB14A', 'none');

    createPath(svg, 'M 450 110 C480 130 450 160 450 160', '#449644', '#449644', 'none');

    createCircle(svg, '450', '200', '60', '#282827');

    createText(svg, '405', '210', '24px', 'bold', 'Arial', '#F3F3F2', 'express')

    createCircle(svg, '450', '270', '60', '#E23337');

    createPath(svg, 'M 450 250 L470 260 L450 330', '#B3B3B3', '#B63032', '2');

    createPath(svg, 'M 450 250 L430 260 L450 330', '#B3B3B3', '#E23337', '2');

    createPath(svg, 'M 430 310 L450 256 L470 310', '#F1F0F0', 'E23337', '3');

    createPath(svg, 'M 432 310 L450 260 L450 310Z', 'none', '#E13638', 'none');

    createPath(svg, 'M 450 310 L450 260 L468 310Z', 'none', '#B63032', 'none');

    createCircle(svg, '450', '340', '60', '#8EC74E');

    createImage(svg, '400', '315', '100', '50', 'images/node.jpg');

    createText(svg, '340', '150', '40px', 'bold', 'Arial', '#3E3F37', 'M')

    createText(svg, '340', '220', '40px', 'bold', 'Arial', '#231F20', 'E')
    
    createText(svg, '340', '290', '40px', 'bold', 'Arial', '#E23337', 'A')

    createText(svg, '340', '360', '40px', 'bold', 'Arial', '#8EC74E', 'N')
}
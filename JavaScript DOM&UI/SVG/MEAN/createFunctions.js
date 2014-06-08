var svgNameSpace = 'http://www.w3.org/2000/svg';

function createPath(svg, points, stroke, fill, strokeWidth) {
    var path;
    path = document.createElementNS(svgNameSpace, 'path');
    path.setAttribute('d', points);
    path.setAttribute('stroke', stroke);
    path.setAttribute('fill', fill);
    path.setAttribute('stroke-width', strokeWidth);
    svg.appendChild(path);
}

function createCircle(svg, x, y, r, fill) {
    var circle;
    circle = document.createElementNS(svgNameSpace, 'circle');
    circle.setAttribute('cx', x);
    circle.setAttribute('cy', y);
    circle.setAttribute('r', r);
    circle.setAttribute('fill', fill);
    svg.appendChild(circle);
}

function createText(svg, x, y, fontSize, fontWeight, fontFamily, fill, value) {
    var text;

    text = document.createElementNS(svgNameSpace, 'text');
    text.setAttribute('x', x);
    text.setAttribute('y', y);
    text.setAttribute('font-size', fontSize);
    text.setAttribute('font-weight', fontWeight);
    text.setAttribute('font-family', fontFamily);
    text.setAttribute('fill', fill);
    text.textContent = value;
    svg.appendChild(text);
}

function createImage(svg, x, y, width, height, href) {
    var image;
    image = document.createElementNS(svgNameSpace, 'image');
    image.setAttribute('x', x);
    image.setAttribute('y', y);
    image.setAttribute('width', width);
    image.setAttribute('height', height);
    image.setAttributeNS('http://www.w3.org/1999/xlink', 'xlink:href', href);
    
    svg.appendChild(image);
}
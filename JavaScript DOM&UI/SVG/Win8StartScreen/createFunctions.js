
var svgNameSpace = 'http://www.w3.org/2000/svg';

function createImage(svg, x, y, width, height, href) {
    var image;
    image = document.createElementNS(svgNameSpace, 'image');
    image.setAttribute('x', x);
    image.setAttribute('y', y);
    image.setAttribute('width', width);
    image.setAttribute('height', height);
    image.setAttributeNS('http://www.w3.org/1999/xlink', 'xlink:href', href);
   
    image.addEventListener('mouseover', onMouseIn);
    image.addEventListener('mouseout', onMouseOut);
    
    svg.appendChild(image);
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
    
    text.addEventListener('mouseover', onMouseIn);
    text.addEventListener('mouseout', onMouseOut);
    
    svg.appendChild(text);
}

function createRect(svg, x, y, width, height, fill, stroke, hasEvent, rouded) {
    var rect;
    rect = document.createElementNS(svgNameSpace, 'rect');
    rect.setAttribute('x', x);
    rect.setAttribute('y', y);
    rect.setAttribute('width', width);
    rect.setAttribute('height', height);  
    rect.setAttribute('fill', fill);
    rect.setAttribute('stroke', stroke);
    if (rouded) {
        rect.setAttribute('rx', 20)
        rect.setAttribute('ry', 20)
    }

    if (hasEvent) {
        rect.addEventListener('mouseover', onMouseIn);
        rect.addEventListener('mouseout', onMouseOut);
    }

    svg.appendChild(rect);
}

function createPath(points, stroke, fill, strokeWidth) {
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

function onMouseIn(event) {
    event.target.style.opacity = '0.5';
    event.target.style.cursor = 'pointer';
}
function onMouseOut(event) {
    event.target.style.opacity = '1';
    event.target.style.cursor = 'auto';
}
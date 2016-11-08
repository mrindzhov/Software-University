'use strict';
function circleArea(r) {
    let area = r * r * Math.PI;
    console.log(area);
    let roundedArea=area.toFixed(2);
    console.log(roundedArea);
}
circleArea(['5']);
'use strict';
function cone([r,h]) {
    [r, h] = [r, h].map(Number);
    let volume = (1 / 3) * Math.PI * r * r * h;
    let area = Math.PI * r * (r + Math.sqrt(Math.pow(r, 2) + Math.pow(h, 2)));
    console.log(volume);
    console.log(area);
}
cone(['3','5']);
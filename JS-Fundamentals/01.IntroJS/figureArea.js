'use strict';
function figureArea(input) {
    let w = Number(input[0]);
    let h = Number(input[1]);
    let W = Number(input[2]);
    let H = Number(input[3]);
    let area=w*h+W*H;
    let smallArea=Math.min(w,W)*Math.min(h,H);

    console.log(area-smallArea);
}
figureArea(['13', '2', '5', '8']);
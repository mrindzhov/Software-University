'use strict';
function nextDay(input) {

    let year = Number(input[0]);
    let month = Number(input[1]);
    let day = Number(input[1]);
    var today = new Date(year/month/day);
    var tomorrow = new Date();
    tomorrow.setDate(today.getDate()+1);

    console.log(tomorrow.getDay());

}
nextDay(['2016', '9', '30']);
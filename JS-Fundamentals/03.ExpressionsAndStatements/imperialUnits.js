function imperialUnits([a]) {
    [a]=[a].map(Number);
    let feet=parseInt(a/12);
    let inches=a%12;
    console.log(feet+"\'-"+inches+"\"");
}
imperialUnits(['55']);
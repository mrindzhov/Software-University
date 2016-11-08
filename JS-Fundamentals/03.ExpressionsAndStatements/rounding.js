function rounding([a,b]) {
    [a,b]=[a,b].map(Number);
    if(b>15)
        b=15;
    console.log(Math.round(a*Math.pow(10,b))/Math.pow(10,b));
}
rounding(['3.1415926535897932384626433832795', '2']);
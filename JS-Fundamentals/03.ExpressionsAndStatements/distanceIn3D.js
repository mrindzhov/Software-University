function distance3d([x,y,z,x1,y1,z1]) {
    [x, y, z, x1, y1, z1] = [x, y, z, x1, y1, z1].map(Number);
     let d =Math.sqrt(Math.pow(x1-x,2)+Math.pow(y1-y,2)+Math.pow(z1-z,2));
    console.log(d);
}
distance3d(['1', '1', '0', '5', '4', '0']);
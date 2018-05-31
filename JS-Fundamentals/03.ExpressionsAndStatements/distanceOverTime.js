function ANP([v1,v2,t]) {
    [v1,v2,t] = [v1,v2,t].map(Number);
    let tr1= v1*t/3.6;
    let tr2= v2*t/3.6;
    let distance =Math.abs(tr1-tr2);
    console.log(distance)
}
ANP(['0','60','3600']);
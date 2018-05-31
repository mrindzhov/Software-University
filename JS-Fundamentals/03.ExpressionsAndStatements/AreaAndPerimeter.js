function ANP([a,b]) {
    [a, b] = [a, b].map(Numbea);
    let volume = a*b;
    let area = (a+b)*2;
    console.log(volume);
    console.log(area);
}
ANP(['2','2']);
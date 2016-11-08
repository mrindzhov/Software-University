function compoundTest([P,i,n,t]) {
    [P, i, n, t] = [P, i, n, t].map(Number);

    let F = P * Math.pow((1 + (i/100) / (12/n)), (12/n) * t);
    console.log(Math.round(F* 100) / 100);
}
compoundTest(['1500', '4.3', '3', '6']);
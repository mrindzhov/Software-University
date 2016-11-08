function gradsToDegree([grad]){
    grad = Number(grad);
    grad = grad % 400;

    let convert = (grad / 10) * 9;

    if (convert < 0){
        convert = 360 + convert;
    }
    return convert;
}
gradsToDegree(['-50']);
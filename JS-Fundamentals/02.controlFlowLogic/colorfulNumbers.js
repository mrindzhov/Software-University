function colNums(input) {
    console.log('<ul>');
    for (let i = 1; i <= input; i++) {
        if (i % 2 == 0)
            console.log(`<li><span style='color:blue'>` + i + `</span></li>`);
        else
            console.log(`<li><span style='color:green'>` + i + `</span></li>`);

    }
    console.log('</ul>');

}
colNums([10]);


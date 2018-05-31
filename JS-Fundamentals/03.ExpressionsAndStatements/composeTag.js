function composeTag([name,tag]) {
    console.log(`<img src="`+name+`" alt="`+tag+`">`);
}
composeTag(['smiley.gif', 'Smiley Face']);

// ['smiley.gif', 'Smiley Face']	<img src="smiley.gif" alt="Smiley Face">
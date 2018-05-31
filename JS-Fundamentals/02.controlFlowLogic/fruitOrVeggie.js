function fruitOrVeggie(input) {
    if(input=='banana' ||input=='kiwi' ||input=='cherry'
        ||input=='peach'||input=='grapes' ||input=='lemon'||input=='apple' )
        console.log(`fruit`);
    else if(input=='tomato' ||input=='cucumber' ||input=='onion'
        ||input=='parsley'||input=='garlic' ||input=='pepper' )
        console.log(`vegetable`);
    else
        console.log(`unknown`);
}
fruitOrVeggie(['banana']);
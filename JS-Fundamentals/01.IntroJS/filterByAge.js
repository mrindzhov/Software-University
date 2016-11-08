'use strict';
function filterByAge(input) {

    let minimumAge = Number(input[0]);
    let name1= String(input[1]);
    let age1=Number(input[2]);
    let name2= String(input[3]);
    let age2=Number(input[4]);

    var person1={name:name1, age:age1};
    var person2={name:name2, age:age2};
    if(age1>age2)
        if(age1>=minimumAge)
            console.log(person1);
        if(age2>=minimumAge)
            console.log(person2);
}
filterByAge(['12', 'Ivan', '15', 'Asen', '9']);
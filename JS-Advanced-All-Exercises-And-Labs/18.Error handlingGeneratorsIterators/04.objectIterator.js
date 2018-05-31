function makeIterable(object) {
    let arr=[];
    for(let key in object) {
        arr.push(key + '');
    }
    arr.sort()
    let index=arr.length-1;
    return {
        // [Symbol.iterator]: function () {return this;},
        ['next']: function () {
            if (index >= 0)
                return {value: arr[index--], done: false};
            else
                return {done: true};
        }
    }
}

/*let obj = {age: 27, name: "pesho", book: "Lord of the Rings"};
 let iterator = makeIterable(obj);
 while(true){
 let res = iterator.next();
 if(res.done) break;
 console.log(res.value);
 }*/

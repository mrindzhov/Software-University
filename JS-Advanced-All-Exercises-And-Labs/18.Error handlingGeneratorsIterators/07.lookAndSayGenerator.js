function * lookAndSay(start) {
    let next = start.toString() ;
    while (true) {
        next = next.replace(/(.)\1*/g, function (seq, p1) {
            return seq.length.toString() + p1;
        });
        yield next;
    }
}
/*let lookSequence = lookAndSay(1);
console.log(lookSequence.next().value); //11
console.log(lookSequence.next().value); //21
console.log(lookSequence.next().value); //1211
console.log(lookSequence.next().value); //111221
console.log(lookSequence.next().value); //312211*/

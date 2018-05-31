function* fibonacci() {
    let num = 1;
    let num2 = 1;
    while (true) {
        yield num;
        let num3 = num2 + num;
        num= num2;
        num2=num3;
    }
}
/*let fib = fibonacci();
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);*/

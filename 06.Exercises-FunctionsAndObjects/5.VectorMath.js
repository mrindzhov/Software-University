let vectorMath = (function() {
    function add(a, b) {
        let f = a[0] + b[0];
        let s = a[1] + b[1];
        let arr = [];
        arr.push(f);
        arr.push(s);

        return arr;
    }
    function multiply(arr, m) {
        let a = arr[0] * m;
        let b = arr[1] * m;

        let res = [];
        res.push(a);
        res.push(b);

        return res;
    }
    function length(arr) {
        let a = Math.pow(arr[0], 2);
        let b = Math.pow(arr[1], 2);

        let r = Math.sqrt(a + b);

        return r;
    }
    function dot(a, b) {
        let f = a[0] * b[0];
        let s = a[1] * b[1];

        return f + s;
    }
    function cross(a, b) {
        let f = a[0] * b[1];
        let s = a[1] * b[0];

        return f - s;
    }
    return { add, multiply, length, dot, cross };
})();
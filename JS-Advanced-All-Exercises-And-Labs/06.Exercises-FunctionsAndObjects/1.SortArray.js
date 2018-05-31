function sortArray(arr, arg) {
    let ascending = function (a, b) {
        return a - b;
    };
    let descending = function (a, b) {
        return b - a;
    };

    var sorting = {
        'asc': ascending,
        'desc' : descending
    };

    return arr.sort(sorting[arg]);
}
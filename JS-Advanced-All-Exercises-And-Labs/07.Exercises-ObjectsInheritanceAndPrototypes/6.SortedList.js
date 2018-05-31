function sortedList() {
    return (function () {
        let collection = [];

        function add(element) {
            collection.push(element);
            sort();
        }
        
        function remove(index) {
            if (index >= 0 && index < collection.length) {
                collection.splice(index, 1);
                sort();
            } else {
                throw new Error;
            }
        }
        
        function get(index) {
            if (index >= 0 && index < collection.length) {
                return collection[index];
            } else {
                throw new Error;
            }
        }
        function getSize() {
            return collection.length;
        }
        
        function sort() {
            collection = collection.sort((a, b) => a - b);
        }

        let res = {add, remove, get};
        res.__defineGetter__("size", getSize);
        return res;
    })();
}
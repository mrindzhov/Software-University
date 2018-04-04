class Textbox {
    constructor(selector, regexInvalidSymbols) {
        this.selector = selector;
        this._invalidSymbols = regexInvalidSymbols;
        this._elements = $(this.selector);
        let self = this;
        $(this._elements).on('input change', function (e) {
            self._value = $(this).val();
            self.symb();
        })
    }
    get value() {
        return this._value;
    }
    set value(newValue) {
        $(this._elements).val(newValue);
    }
    get elements() {
        return this._elements;
    }
    symb() {
        for (let element of this._elements) {
            $(element).val(this._value)
        }
    }
    isValid() {
        return !this._invalidSymbols.test(this._value)
    }
}

let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);
let inputs = $('.textbox');

inputs.on('input', function () {
    console.log(textbox.value);
});

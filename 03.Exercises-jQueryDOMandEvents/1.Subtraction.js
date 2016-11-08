function subtract(){
    let firstNum = $('#firstNumber');
    let secondNum = $('#secondNumber');
    let resultDiv = $('#result');

    let result = parseFloat(firstNum.val()) - parseFloat(secondNum.val());
    resultDiv[0].textContent = result;
}
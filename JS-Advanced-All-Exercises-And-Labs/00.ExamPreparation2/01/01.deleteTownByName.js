function attachEvents() {
    $('#btnDelete').click(function() {
        let townName = $('#townName').val();
        $('#townName').val('');
        let found = false;
        for (let option of $('#towns option'))
            if (option.textContent == townName) {
                found = true;
                option.remove();
            }
        if (found)
            $('#result').text(townName + " deleted.");
        else
            $('#result').text(townName + " not found.");
    });
}/*Deletes all appearances of the searched word*/

/*function attachEvents() {
    $('#btnDelete').on('click', function () {
        let townName = $('#townName').val();
        let towns= $("#towns").find("option");
        let resultDiv=$('#result');
        for (let town of towns) {
            resultDiv.empty();
            if (townName == town.value) {
                let div = `${townName} deleted.`;
                resultDiv.append(div);
                $('#townName').val('');
                break;
            }else {
                let div = `${townName} not found.`;
                resultDiv.append(div);
                $('#townName').val('');
            }
        }
    });
}*/
/*Deletes only one appearance of the searched word*/


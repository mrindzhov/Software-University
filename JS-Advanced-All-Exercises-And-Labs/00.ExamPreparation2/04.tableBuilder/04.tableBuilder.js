function tableBuilder(selector) {
    return {
        createTable: function (columnNames) {
            let table = $('<table></table>');
            let headerRow = $('<tr></tr>');
            headerRow.appendTo(table);
            for (let colName of columnNames) {
                headerRow.append($('<th></th>').text(colName))
            }
            headerRow.append($('<th></th>').text('Action'));
            $(selector).empty();
            $(selector).append(table);
        },
        fillData: function (dataRows) {
            let table=$(selector + ' table');
            for (let dataRow of dataRows) {
                let row = $('<tr>');
                for (let colAttr of dataRow) {
                    row.append($('<td>').text(colAttr));
                }
                let delBtn = $("<button>Delete</button>");
                delBtn.on('click', function () {
                    row.remove()
                });
                row.append($('<td>').append(delBtn));
                row.appendTo(table);
            }
        }
    }
}
/*fillData: function(dataRows) {
    for (let dataRow of dataRows) {
        let row = $("<tr>");
        for (let cellData of dataRow)
            row.append($("<td>").text(cellData));
        let delButton = $("<button>Delete</button>");
        delButton.click(function() {
            $(this).parent().parent().remove();
        });
        row.append($("<td>").append(delButton));
        row.appendTo($(selector + ' table'));
    }
}*/
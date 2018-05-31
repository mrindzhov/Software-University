function increment(selector) {
    let container = $(selector);
    let fragment = document.createDocumentFragment();
    let textArea = $('<textarea></textarea>');
    let incrementButton = $('<button>Increment</button>');
    let addButton = $('<button>Add</button>');
    let list = $('<ul>');

    textArea.val(0);
    textArea.addClass('counter');
    textArea.attr('disabled', true);
    incrementButton.addClass('btn');
    incrementButton.attr('id', 'incrementBtn');
    addButton.addClass('btn');
    addButton.attr('id', 'addBtn');
    list.addClass('results');

    incrementButton.on('click', function (event) {
         let value = parseInt(textArea.val());
        textArea.val(++value);
    });

    addButton.on('click', function (event) {
        let value = parseInt(textArea.val());
        let li = $('<li>');
        li.text(value);
        list.append(li);
    });

    textArea.appendTo(fragment);
    incrementButton.appendTo(fragment);
    addButton.appendTo(fragment);
    list.appendTo(fragment);

    container.append(fragment);
}
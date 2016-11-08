(function bookGenerator() {
    let i = 1;
    return function createBook(selector, titleToAdd, authorToAdd, isbnToAdd){
        let container = $(selector);
        let fragment = document.createDocumentFragment();

        let book = $('<div></div>');
        book.attr('id', 'book' + i);
        book.css('border', '2px solid blue');

        let title = $('<p></p>');
        title.addClass('title');
        title.text(titleToAdd);

        let author = $('<p></p>');
        author.addClass('author');
        author.text(authorToAdd);

        let isbn = $('<p></p>');
        isbn.addClass('isbn');
        isbn.text(isbnToAdd);

        let selectButton = $('<button>Select</button>');
        selectButton.on(function () {
            book.css('border', '2px solid blue');
        });

        let deselectButton = $('<button>Deselect</button>');
        deselectButton.on(function () {
            book.css('border', 'none');
        });

        title.appendTo(book);
        author.appendTo(book);
        isbn.appendTo(book);
        selectButton.appendTo(book);
        deselectButton.appendTo(book);

        book.appendTo(fragment);
        container.append(fragment);

        i++;
    }
}())
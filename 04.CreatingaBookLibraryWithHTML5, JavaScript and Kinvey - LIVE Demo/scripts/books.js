// Nakov's LIVE video tutorial

const kinveyAppId = 'kid_rJ1skPRB';
const kinveyAppSecret = '18eeb94276d74b95bb51f0896ceef932';
const kinveyServiceBaseUrl = 'https://baas.kinvey.com/';

function showView(viewId) {
    $("main > section").hide();
    $("#" + viewId).show();
    // alternatively call function with showView('#viewId')
    // $(viewId).show();
}
function showHideNavigationLinks() {
    let loggedIn = sessionStorage.authToken != null;
    if (loggedIn){
        $("#linkLogin").hide();
        $("#linkRegister").hide();
        $("#linkListBooks").show();
        $("#linkCreateBook").show();
        $("#linkLogout").show();
    }
    else {
        $("#linkLogin").show();
        $("#linkRegister").show();
        $("#linkListBooks").hide();
        $("#linkCreateBook").hide();
        $("#linkLogout").hide();
    }
}

function showHomeView() {
    showView('viewHome');
}

function showLoginView() {
    showView('viewLogin');
}
function login() {
    let authBase64 = btoa(kinveyAppId + ":" + kinveyAppSecret);
    let loginUrl = kinveyServiceBaseUrl + "user/" + kinveyAppId + "/login";
    let loginData = {
        username: $('#loginUser').val(),
        password: $('#loginPass').val()
    };
    let loginHeaders = {
        "Authorization": "Basic " + authBase64
    };
    $.ajax({
        method: "POST",
        url: loginUrl,
        data: loginData,
        headers: loginHeaders,
        success: loginSuccess,
        error: showAjaxError
    });
    function loginSuccess(data, status) {
        sessionStorage.authToken = data._kmd.authtoken;
        showListBooksView();
        showHideNavigationLinks();
        showInfo("Login successful");
    }
}

function showInfo(messageText) {
    $('#infoBox').text(messageText).show().delay(3000).fadeOut();
}
function showAjaxError(data, status) {
    let errorMsg = '';
    if (typeof(data.readyState) != 'undefined' && data.readyState == 0) {
        errorMsg = "Network error";
    }
    else if (data.responseJSON && data.responseJSON.description) {
        errorMsg = data.responseJSON.description;
    }
    else {
        errorMsg = "Error: " + JSON.stringify(data);
    }
    if (errorMsg != '') {
        $('#errorBox').text(errorMsg).show();
    }
}

function showRegisterView() {
    showView('viewRegister');
}
function register() {
    let authBase64 = btoa(kinveyAppId + ":" + kinveyAppSecret);
    let registerUrl = kinveyServiceBaseUrl + "user/" + kinveyAppId + "/";
    let registerData = {
        username: $('#registerUser').val(),
        password: $('#registerPass').val()
    };
    let registerHeaders = {
        "Authorization": "Basic " + authBase64
    };
    $.ajax({
        method: "POST",
        url: registerUrl,
        data: registerData,
        headers: registerHeaders,
        success: registerSuccess,
        error: showAjaxError
    });
    function registerSuccess(data, status) {
        sessionStorage.authToken = data._kmd.authtoken;
        showListBooksView();
        showHideNavigationLinks();
        showInfo("User registered successfully");
    }
}

function showListBooksView() {
    showView('viewListBooks');
    $('#books').text('');
    let booksUrl = kinveyServiceBaseUrl + "appdata/" + kinveyAppId + "/books";
    let authHeaders = {
        "Authorization": "Kinvey " + sessionStorage.authToken
    };
    $.ajax({
        method: "GET",
        url: booksUrl,
        headers: authHeaders,
        success: booksLoaded,
        error: showAjaxError
    });
    function booksLoaded(books, status) {
        showInfo("Books loaded");
        if(books.length == 0) {
            $('#books').text("No books in the library")
        }
        else {
            let booksTable = $('<table>')
                .append($('<tr>')
                    .append($('<th>Title</th>'))
                    .append($('<th>Author</th>'))
                    .append($('<th>Description</th>')));
            for (let book of books) {
                // add book data
                booksTable.append(
                    $('<tr>')
                        .append($('<td></td>').text(book.title))
                        .append($('<td></td>').text(book.author))
                        .append($('<td></td>').text(book.description))
                );

                // add book comments
                let bookComments = [];
                if (typeof(book.comments) != 'undefined' && book.comments.length > 0) {
                    for (let comment of book.comments) {
                        bookComments.push(comment);
                    }
                }
                let comments = $('<div class="divComments">');
                for (let bookComment of bookComments) {
                    let commentAuthor = $('<div class="divCommentAuthor">')
                        .append(' ~~ ')
                        .append(bookComment.author);
                    comments
                        .append(bookComment.text)
                        .append(commentAuthor);
                }

                // add Create Comment link
                comments.append($('<div style="display: inline">')
                    .append($('<a href="#" id="linkCreateComment" onclick="showFormCreateComment()" >Add comment</a>')));

                // add [hidden] Create Comment Form
                comments.append(
                    $('<div>')
                        .append($('<form id="formCreateComment" style="display: none">' +
                            'Comment: <input type="text" id="commentText" required="true">' + ' ' +
                            'Author: <input type="text" id="commentAuthor" required="true">' + ' ' +
                            '<input type="submit" value="Add comment">' + ' ' +
                            '<input type="button" value="Cancel" onclick="hideFormCreateComment()">' +
                            '</form>'))
                );

                // append comments to table
                booksTable.append(
                    $('<tr>').append(
                        $('<td colspan="3"></td>')
                            .append(comments)));
            }

            // append table to ListBooks View
            $('#books').append(booksTable);
        }
    }
}

function showCreateBookView() {
    showView('viewCreateBook');
}
function createBook() {
    let booksUrl = kinveyServiceBaseUrl + "appdata/" + kinveyAppId + "/books";
    let newBookData = {
        title: $('#bookTitle').val(),
        author: $('#bookAuthor').val(),
        description: $('#bookDescription').val()
    };
    let authHeaders = {
        "Authorization": "Kinvey " + sessionStorage.authToken
        // "Content-Type": "application/json"
    };
    $.ajax({
        method: "POST",
        url: booksUrl,
        data: newBookData,
        // data: JSON.stringify(newBookData), // used with Content-Type: application/json
        headers: authHeaders,
        success: bookCreated,
        error: showAjaxError
    });
    function bookCreated(data) {
        showListBooksView();
        showInfo("Book created");
        $('#formCreateBook')[0].reset();
    }
}

function showFormCreateComment() {
    // hiding and revealing forms and links does not work correctly !
    $('#formCreateComment').show();
    $('#linkCreateComment').hide();
}
function hideFormCreateComment() {
    // hiding and revealing forms and links does not work correctly !
    $('#formCreateComment').hide();
    $('#linkCreateComment').show();
}

function addBookComment(bookData, commentText, commentAuthor) {
    // adding comments not working!
    const kinveyBooksUrl = kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books" + "/" + bookData._id;
    const kinveyAuthHeaders = {
        "Authorization": "Kinvey " + sessionStorage.getItem('authToken'),
        'Content-type': 'application/json'
    };
    if (!bookData.comments) {
        bookData.comments = [];
    }
    bookData.comments.push({
        text: commentText,
        author: commentAuthor
    });
    $.ajax({
        method: "PUT",
        url: kinveyBooksUrl,
        headers: kinveyAuthHeaders,
        data: JSON.stringify(bookData),
        success: addBookCommentSuccess,
        error: handleAjaxError
    });
    function addBookCommentSuccess() {
        listBooks();
        showInfo("Book comment added");
    }
}

function logout() {
    sessionStorage.clear();
    showView('viewHome');
    showHideNavigationLinks();
}

$(function () {
    $("#linkHome").click(showHomeView);
    $("#linkLogin").click(showLoginView);
    $("#linkRegister").click(showRegisterView);
    $("#linkListBooks").click(showListBooksView);
    $("#linkCreateBook").click(showCreateBookView);
    $("#linkLogout").click(logout);

    $('#formLogin').submit(function (e) {
        e.preventDefault(); login();
    });
    $('#formRegister').submit(function (e) {
        e.preventDefault(); register();
    });
    $('#formCreateBook').submit(function (e) {
        e.preventDefault(); createBook();
    });
    $('#formCreateComment').submit(function (e, bookData, commentText, commentAuthor) {
        e.preventDefault(); addBookComment(bookData, commentText, commentAuthor);
    });

    showHomeView();
    showHideNavigationLinks();

    $(document)
        .ajaxStart(function () {
            $('#loadingBox').show();
        })
        .ajaxStop(function () {
            $('#loadingBox').hide();
        })
});
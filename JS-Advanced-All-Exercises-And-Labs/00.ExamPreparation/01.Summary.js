function solve(selector) {
    $(`${selector}`).on('click',function () {
        let b =$('#content').find(`strong`).text();
        let str = `<div id="summary"><h2>Summary</h2>` + `<p>${b}</p></div>`;
        $('#content').append(str);
    });
}
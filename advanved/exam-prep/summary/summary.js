function solve(selector) {
    $(selector).on('click', () => {
        let strongElements = $('#content').find('strong').text();
        let summary = `<div id="summary">
                            <h2>Summary</h2>
                            <p>${strongElements}</p>
                       </div>`;
        $('#content').append(summary)
    });
}

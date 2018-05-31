$(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        let template = await $.get('./cat-template.hbs')
        template = Handlebars.compile(template)
        let result = template({
            cats: window.cats
        })
        $('body').html(result)
        $('.btn-primary').on('click', (ev) => {
            let clickedBtn = $(ev.target);
            if (clickedBtn.text() === 'Show status code') {
                clickedBtn.text('Hide status code');
            } else {
                clickedBtn.text('Show status code');
            }

            clickedBtn.next('div').toggle();
        })
    }

})
function attachEvents() {
  $('#btnLoadTowns').click(function () {
    let towns = $('#towns').val()
      .split(',')
      .map(e => ({
        name: e.trim()
      }))
      .filter(t => t.name !== '')
    loadTowns(towns)

  });

  async function loadTowns(towns) {
    let source = await $.get('./towns-template.hbs')
    let template = Handlebars.compile(source)
    let resultHtml = source({
      towns: towns
    })
    $('#root').html(resultHtml)
  }

}
async function handeAdRequest(type) {
  let targetForm = $('#form' + type)
  let title = targetForm.find('input[name=title]').val()
  let description = targetForm.find('textarea[name=description]').val()
  let datePublished = targetForm.find('input[name=datePublished]').val()
  let price = targetForm.find('input[name=price]').val()

  let adData = {
    title,
    description,
    datePublished,
    price
  }

  let headers = {
    Authorization: 'Kinvey ' + sessionStorage.getItem('authtoken')
  }

  let method = 'POST'
  let param = null
  if (type == 'EditAd') {
    method = 'PUT'
    param = '/' + targetForm.find('input[name=id]').val()
  }

  try {
    let ad = await webApi().sendRequest(method, 'Advert', headers, adData, param);
    targetForm.trigger('reset')
    loadAds()
    viewSection('Ads')
    showInfo('Added ad successfully: ' + ad.title);
  } catch (error) {
    showError(error.message)
  }
}

async function loadAds() {
  let headers = {
    Authorization: 'Kinvey ' + sessionStorage.getItem('authtoken')
  }

  try {
    let allAds = await webApi().sendRequest('GET', 'Advert', headers);
    console.log(allAds);
    fillTable(allAds)
    viewSection('Ads')
  } catch (error) {
    showError(error.message)
  }
}

function fillTable(ads) {
  let table = $('#ads > table')
  let headerRow = table.find('tr')[0]
  table.empty()
  table.append($(headerRow))
  for (const ad of ads) {
    let rowTemplate = $(`<tr>`)
      .append($(`<td>`).text(ad.title))
      .append($(`<td>`).text(ad._acl.creator))
      .append($(`<td>`).text(ad.description))
      .append($(`<td>`).text(ad.price))
      .append($(`<td>`).text(ad.datePublished))

    let actionTd = $('<td>')

    if (ad._acl.creator == sessionStorage.getItem('id'))
      actionTd.append($(`<a>`).text('Delete').attr('href', '#').on('click', () => {
        alert(ad._id)
      }))
      .append(' ')
      .append($(`<a>`).text('Edit').attr('href', '#').on('click', () => {
        loadEditAd(ad)
      }))
    rowTemplate.append(actionTd)
    table.append(rowTemplate)
  }
}

function loadEditAd(ad) {
  let targetForm = $('#formEditAd')
  targetForm.find('input[name=id]').val(ad._id)
  targetForm.find('input[name=publisher]').val(ad._acl.creator)
  targetForm.find('input[name=title]').val(ad.title)
  targetForm.find('textarea[name=description]').val(ad.description)
  targetForm.find('input[name=datePublished]').val(ad.datePublished)
  targetForm.find('input[name=price]').val(ad.price)
  viewSection('EditAd')
}
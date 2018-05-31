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

async function fillTable(ads) {
  let source = await $.get('templates/view-ads.hbs')
  let compiled = Handlebars.compile(source)
  Handlebars.registerHelper("alert", function (item) {
   alert(item)
  });
  ads = ads.map(a => {
    if (a._acl.creator == sessionStorage.getItem('id')) {
      a.isAuthenticated = true
    }
    return a
  })

  let template = compiled({
    ads
  })
  let viewAds = $('#viewAds')
  if (viewAds.length) {
    viewAds.html(template)
  } else
    $('#app').append(template)
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
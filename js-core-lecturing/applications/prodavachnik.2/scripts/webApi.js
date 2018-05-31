function webApi() {
  const appKey = 'kid_HJf9xRcMx'
  const appSecret = 'c0138adfe9f74362976b1020b5902e90'
  const baseUrl = 'https://baas.kinvey.com'
  const authHeaders = {
    Authorization: 'Basic ' + btoa(appKey + ':' + appSecret)
  }
  const actions = {
    Login: baseUrl + '/user/' + appKey + '/login',
    Register: baseUrl + '/user/' + appKey,
    Advert: baseUrl + '/appdata/' + appKey + '/ads',
  }

  function sendRequest(method, action, headers, data, params) {
    headers = headers == null ? authHeaders : headers
    let url = params == null ? actions[action] : actions[action] + params
    return $.ajax({
      method,
      url: url,
      headers,
      data,
    });
  }
  return {
    sendRequest
  }
}
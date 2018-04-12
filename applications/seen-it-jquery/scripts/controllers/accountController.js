let account = (() => {
  async function handleLoginRequest(e) {
    e.preventDefault()
    let loginForm = $('#loginForm')
    let username = loginForm.find('input[name=username]').val()
    let password = loginForm.find('input[name=password]').val()

    try {
      let user = await auth.login(username, password)
      auth.saveSession(user)
      handleAuthenticatedUser(loginForm, 'Successfully logged in!');
    } catch (error) {
      notify.showError(error)
    }
  }

  async function handleRegisterRequest(e) {
    e.preventDefault()
    let registerForm = $('#registerForm')
    let username = registerForm.find('input[name=username]').val()
    let password = registerForm.find('input[name=password]').val()

    try {
      let user = await auth.register(username, password)
      auth.saveSession(user)
      handleAuthenticatedUser(registerForm, 'Successfully registered!')
    } catch (error) {
      notify.showError(error)
    }
  }

  function handleAuthenticatedUser(form, message) {
    form.trigger('reset');
    $('#linkCatalog').trigger('click')
    notify.showInfo(message);
    $('#profile > span').text(sessionStorage.getItem('username'))
  }

  return {
    handleLoginRequest,
    handleRegisterRequest
  }
})()
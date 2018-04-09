let accountController = (() => {

  function registerUser(ctx) {
    const password = ctx.params.password;
    const repeatPassword = ctx.params.repeatPassword;
    if (password === repeatPassword) {
      auth.register(ctx.params.username, password).then(function (userData) {
        auth.showInfo('You have registered successfully! :)')
        auth.saveSession(userData)
        ctx.redirect('#/home')
      })
    }
  }

  function loginUser(ctx) {
    const password = ctx.params.password;
    const username = ctx.params.username;
    auth.login(username, password).then(function (userData) {
      auth.showInfo('You have loged in successfully! :)')
      auth.saveSession(userData)
      ctx.redirect('#/home')
    })
  }

  function loadLoginPage(ctx) {
    this.loadPartials({
      header: '../templates/common/header.hbs',
      footer: '../templates/common/footer.hbs',
      loginForm: '../templates/login/loginForm.hbs'
    }).then(function () {
      this.partial('../templates/login/loginPage.hbs');
    });
  }

  function loadRegisterPage(ctx) {
    this.loadPartials({
      header: '../templates/common/header.hbs',
      footer: '../templates/common/footer.hbs',
      registerForm: '../templates/register/registerForm.hbs'
    }).then(function () {
      this.partial('../templates/register/registerPage.hbs');
    });
  }
  return {
    registerUser,
    loadRegisterPage,
    loginUser,
    loadLoginPage,
  }
})()
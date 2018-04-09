let homeController = (() => {
  function loadAboutPage(ctx) {
    ctx.loggedIn = auth.isAuthenticated()
    ctx.username = auth.getUserName()
    this.loadPartials({
      header: '../templates/common/header.hbs',
      footer: '../templates/common/footer.hbs'
    }).then(function () {
      this.partial('../templates/about/about.hbs');
    });
  }

  function loadHomePage(ctx) {
    ctx.loggedIn = auth.isAuthenticated()
    ctx.username = auth.getUserName()
    this.loadPartials({
      header: '../templates/common/header.hbs',
      footer: '../templates/common/footer.hbs'
    }).then(function () {
      this.partial('../templates/home/home.hbs');
    });
  }
  return {
    loadAboutPage,
    loadHomePage
  }
})()
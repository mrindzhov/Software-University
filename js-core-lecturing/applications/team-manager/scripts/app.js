$(() => {
    const app = Sammy('#main', function () {
        let appCtx = this
        appCtx.use('Handlebars', 'hbs')

        appCtx.get('#/home', homeController.loadHomePage)

        appCtx.get('#/about', homeController.loadAboutPage)

        appCtx.get('#/catalog', teamsController.loadCatalog)
        appCtx.get('#/catalog/:id', teamsController.loadTeamDetails)
        appCtx.get('#/join/:id', teamsController.joinTeam)


        appCtx.get('#/login', accountController.loadLoginPage)
        appCtx.post('#/login', accountController.loginUser)

        appCtx.get('#/register', accountController.loadRegisterPage)
        appCtx.post('#/register', accountController.registerUser)
    });

    app.run();
});
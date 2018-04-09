let teamsController = (() => {
  function loadCatalog(ctx) {
    teamsService.loadTeams().then((userData) => {
      ctx.loggedIn = auth.isAuthenticated()
      ctx.username = auth.getUserName()
      userData = userData.filter(t => t.members != undefined)
      ctx.teams = userData.map(e => {
        return {
          _id: e._id,
          name: e.name,
          comment: e.description,
        }
      })
      this.loadPartials({
        header: '../../templates/common/header.hbs',
        footer: '../../templates/common/footer.hbs',
        team: '../../templates/catalog/team.hbs',
      }).then(function () {
        this.partial('../../templates/catalog/teamCatalog.hbs');
      });
    })
  }

  function loadTeamDetails(ctx) {
    let teamId = ctx.params.id.substr(1);

    teamsService.loadTeamDetails(teamId).then((details) => {
      ctx.loggedIn = auth.isAuthenticated()
      ctx.username = auth.getUserName()
      ctx.name = details.name
      ctx.comment = details.comment
      ctx.teamId = details._id
      ctx.isAuthor = details._acl.creator == auth.getUserId()
      ctx.isOnTeam = true
      ctx.members = details.members == null ?
        null : JSON.parse(details.members).map(username => {
          return {
            username
          }
        })
      this.loadPartials({
        header: '../../templates/common/header.hbs',
        footer: '../../templates/common/footer.hbs',
        teamMember: '../../templates/catalog/teamMember.hbs',
        teamControls: '../../templates/catalog/teamControls.hbs',
      }).then(function () {
        this.partial('../../templates/catalog/details.hbs');
      });
    })
  }

  function joinTeam(ctx) {
    let teamId = ctx.params.id.substr(1);
    teamsService.joinTeam(teamId).then((details) => {
      ctx.loggedIn = auth.isAuthenticated()
      ctx.username = auth.getUserName()
      auth.showInfo('You have successfully joined team')
    })
  }
  return {
    loadCatalog,
    loadTeamDetails,
    joinTeam
  }
})()
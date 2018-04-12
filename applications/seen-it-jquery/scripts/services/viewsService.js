let viewsService = (() => {
  let sections = {
    welcome: 'Welcome',
    catalog: 'Catalog',
    myposts: 'MyPosts',
    createPost: 'CreatePost',
    editPost: 'EditPost',
    comments: 'Coments'
  }

  function viewSection(section) {
    $('.content > section').hide()
    $('#view' + section).show()
    if (!auth.isAuth()) {
      $('#profile').hide()
      $('#menu').hide()
    } else {
      $('#profile').show()
      $('#menu').show()
    }

  }
  return {
    sections,
    viewSection
  }
})()
(() => {
  viewsService.viewSection(viewsService.sections.welcome);
  attachEvents();

  function attachEvents() {
    attachEventsToButtons();
    attachEventsToLinks();

    function attachEventsToLinks() {
      $('#linkCatalog').on('click', () => {
        postController.renderPosts()
        viewsService.viewSection(viewsService.sections.catalog)
      });
      $('#linkMyPosts').on('click', () => viewsService.viewSection(viewsService.sections.myposts));
      $('#linkCreatePost').on('click', () => viewsService.viewSection(viewsService.sections.createPost));
      $('#linkLogout').on('click', () => {
        sessionStorage.clear();
        viewsService.viewSection(viewsService.sections.welcome);
      });
    }

    function attachEventsToButtons() {
      $('#loginForm').submit(account.handleLoginRequest);
      $('#registerForm').submit(account.handleRegisterRequest);
      $('#editPostForm').submit(postController.editPost);
      $('#createPostForm').submit(postController.createPost);
    }
  }
})()
let postController = (() => {
  async function renderPosts() {
    $('.posts').empty()
    let posts = await postService.getAllPosts()
    let counter = 1;

    for (const post of posts) {
      let article =
        `<article class="post" id="${post._id}">
            <div class="col rank">
                <span>${counter++}</span>
            </div>
            <div class="col thumbnail">
                <a href="${post.url}">
                    <img src="${post.imageUrl}">
                </a>
            </div>
            <div class="post-content">
                <div class="title">
                      ${post.title}
                </div>
                <div class="details">
                    <div class="info">
                        submitted HELPERA DA DOBAVIM day ago by ${post.author}
                    </div>
                    <div class="controls">
                        <ul>
                            <li class="action">
                                <a class="commentsLink" href="#">comments</a>
                            </li>
                            <li class="action">
                                <a class="editLink" href="#">edit</a>
                            </li>
                            <li class="action">
                                <a class="deleteLink" href="#">delete</a>
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
        </article>`
      $(article).appendTo('.posts')
    }

    (function attachEventsToPostButtons() {
      $('.deleteLink').click(deletePost)
      $('.editLink').click(editPostFromCatalog)
      $('.commentsLink').click(viewComments)
    })()

    function deletePost(e) {
      let button = $(e.target)
      let postId = getPostIdByChildButton(button)
      postController.deletePost(postId)
    }

    function editPostFromCatalog(e) {
      let button = $(e.target)
      let postId = getPostIdByChildButton(button)
      viewPost(postId)
    }

    function viewComments(e) {
      let button = $(e.target)
      let postId = getPostIdByChildButton(button)
    }

    function getPostIdByChildButton(button) {
      let post = button.closest('.post');
      let id = post.attr('id');
      return id;
    }
  }

  async function viewPost(postId) {
    let post = await postService.getPostById(postId)
    let editPostForm = $('#editPostForm')
    editPostForm.find('input[name=id]').val(postId)
    editPostForm.find('input[name=url]').val(post.url)
    editPostForm.find('input[name=title]').val(post.title)
    editPostForm.find('input[name=image]').val(post.imageUrl)
    editPostForm.find('textarea[name=description]').text(post.description)
    viewsService.viewSection(viewsService.sections.editPost)
  }

  async function editPost(e) {
    e.preventDefault()
    let editPostForm = $('#editPostForm')
    let postId = editPostForm.find('input[name=id]').val()
    let url = editPostForm.find('input[name=url]').val()
    let title = editPostForm.find('input[name=title]').val()
    let imageUrl = editPostForm.find('input[name=image]').val()
    let description = editPostForm.find('textarea[name=description]').text()
    let authorId = sessionStorage.getItem('userId')
    await postService.editPost(postId, authorId, title, description, url, imageUrl)
    viewPost(postId)
  }

  async function createPost(e) {
    e.preventDefault()
    let createPostForm = $('#createPostForm')
    let url = createPostForm.find('input[name=url]').val()
    let title = createPostForm.find('input[name=title]').val()
    let imageUrl = createPostForm.find('input[name=image]').val()
    let description = createPostForm.find('textarea[name=description]').val()
    let username = sessionStorage.getItem('username')
    let post = await postService.createPost(username, title, description, url, imageUrl)
    viewPost(post.id)
  }

  return {
    renderPosts,
    editPost,
    createPost
  }
})()
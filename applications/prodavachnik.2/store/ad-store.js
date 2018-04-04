(function () {
  class Ad {
    constructor(title, publisher, description, price, datePublished) {
      this.title = title
      this.publisher = publisher
      this.description = description
      this.price = price
      this.datePublished = datePublished
    }
  }
  let ads = [
    new Ad('linkRegister', 'Register'),
  ]
  window.ads = ads
})()
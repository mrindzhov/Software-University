package P02_BookShop;

class GoldenEditionBook extends Book {

    GoldenEditionBook(String author, String title, Double price) {
        super(author, title, price);
    }

    @Override
    protected void setPrice(Double price) {
        super.setPrice(price * 1.3);
    }
}
package P02_BookShop;

class Book {
    private String author;
    private String title;
    private Double price;

    Book(String author, String title, Double price) {
        setAuthor(author);
        setTitle(title);
        setPrice(price);
    }

    public Double getPrice() {
        return price;
    }

    protected void setPrice(Double price) {
        if (price <= 0) {
            throw new IllegalArgumentException("Price not valid!");
        } else {
            this.price = price;
        }
    }

    public String getTitle() {
        return title;
    }

    private void setTitle(String title) {
        if (title.length() < 3) {
            throw new IllegalArgumentException("Title not valid!");
        } else {
            this.title = title;
        }
    }

    public String getAuthor() {
        return author;
    }

    private void setAuthor(String author) {
        if (!author.matches(".*\\d+.*")) {
            this.author = author;
        } else {
            throw new IllegalArgumentException("Author not valid!");
        }
    }

    @Override
    public String toString() {
        return String.format("Type: %s%nTitle: %s%nAuthor: %s%nPrice: %.1f%n",
                this.getClass().getSimpleName(),
                this.getTitle(),
                this.getAuthor(),
                this.getPrice()
        );
    }
}
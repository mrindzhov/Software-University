package P03_ShoppingSpree;

class Product {
    private String name;
    private Double price;
    Product(String name,Double price) {
        setName(name);
        setPrice(price);
    }
    public String getName() {
        return name;
    }
    private void setName(String name) {
        if (name.isEmpty() || name.contains(" ")) {
            throw new IllegalStateException("Name cannot be empty.");
        } else {
            this.name = name;
        }
    }
    public Double getPrice() {
        return price;
    }
    private void setPrice(Double price) {
        if (price >= 0) {
            this.price = price;
        } else {
            throw new IllegalStateException("Money cannot be negative");
        }
    }

    @Override
    public String toString() {
        return getName();
    }
/*    message ("[Person name] can't afford [Product name]")*/
}

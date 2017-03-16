package P03_ShoppingSpree;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class Person {
    private String name;
    private Double money;
    private ArrayList<Product> bagOfProducts;

    Person(String name, Double money) {
        setName(name);
        setMoney(money);
        bagOfProducts = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        if (name.isEmpty() || name.contains(" ")) {
            throw new IllegalStateException("Name cannot be empty");
        } else {
            this.name = name;
        }
    }

    public Double getMoney() {
        return money;
    }

    private void setMoney(Double money) {
        if (money >= 0) {
            this.money = money;
        } else {
            throw new IllegalStateException("Money cannot be negative");
        }
    }

    public void buyProduct(Product product) {
        if (product.getPrice() > this.getMoney()) {
            throw new IllegalStateException(this.getName() + " can't afford " + product.getName());
        } else {
            bagOfProducts.add(product);
            setMoney(this.money - product.getPrice());
        }
    }

    public List<Product> getBagOfProducts() {
        return Collections.unmodifiableList(bagOfProducts);
    }
}

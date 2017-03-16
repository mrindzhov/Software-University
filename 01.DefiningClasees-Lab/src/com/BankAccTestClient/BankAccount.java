package com.BankAccTestClient;

public class BankAccount {
    private int id;
    private double balance;
    public void setId(int id) {
        this.id = id;
    }

    public double getBalance() {
        return balance;
    }

    public void withdraw(double amount) {
        if (amount>balance) {
            System.out.println("Insufficient balance");
            return;
        }
        this.balance -= amount;
    }

    public void deposit(double amount) {
        if (amount < 0) {
            System.out.println("Deposit should be non negative.");
            return;
        }
        this.balance += amount;
    }

    @Override
    public String toString() {
        return "ID" + this.id;
    }
}


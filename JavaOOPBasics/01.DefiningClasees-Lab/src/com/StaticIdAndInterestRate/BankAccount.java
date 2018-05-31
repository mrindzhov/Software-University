package com.StaticIdAndInterestRate;

public class BankAccount {
    private static final double DEFAULT_INTEREST_RATE = 0.02;

    private static double rate = DEFAULT_INTEREST_RATE;
    private static int bankAccountCount;


    private double balance;
    private int id;

    public BankAccount() {
        this.id = ++bankAccountCount;
    }

    public static void setInterestRate(double interest) {
        BankAccount.rate = interest;
    }
    public int getId() {
        return id;
    }

    public double getInterest(int years) {
        return rate * years * this.balance;
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
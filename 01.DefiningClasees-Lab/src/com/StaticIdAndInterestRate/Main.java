package com.StaticIdAndInterestRate;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        HashMap<Integer, BankAccount> records = new HashMap<>();

        while (true) {
            String input = scanner.nextLine();
            if (input.equals("End")) {
                break;
            }
            String[] cmdArgs = input.split(" ");
            switch (cmdArgs[0]) {
                case "Create":
                    BankAccount account = new BankAccount();
                    System.out.printf("Account %s created %n", account);
                    records.put(account.getId(), account);
                    break;
                case "Deposit":
                    executeDepositCommand(records, cmdArgs);
                    break;
                case "SetInterest":
                    BankAccount.setInterestRate(Double.valueOf(cmdArgs[1]));
                    break;
                case "GetInterest":
                    System.out.println(executeGetInterestCommand(records, cmdArgs));
                    break;
            }
        }
    }


    private static void executeDepositCommand(HashMap<Integer, BankAccount> records, String[] cmdArg) {
        int id = Integer.valueOf(cmdArg[1]);
        int amount = Integer.valueOf(cmdArg[2]);

        if (!records.containsKey(id)) {
            System.out.println("Account does not exist");
            return;
        }
        records.get(id).deposit(amount);
        System.out.printf("Deposited %s to %s%n", amount, records.get(id));
    }

    private static String executeGetInterestCommand(HashMap<Integer, BankAccount> records, String[] cmdArgs) {
        int id = Integer.valueOf(cmdArgs[1]);
        int years = Integer.valueOf(cmdArgs[2]);
        if (!records.containsKey(id)) {
            return "Account does not exist";
        }
        return String.format("%.2f", records.get(id).getInterest(years)).replace(',', '.');

    }
}
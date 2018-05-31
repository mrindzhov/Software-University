package com.BankAccTestClient;

import java.util.HashMap;
import java.util.Locale;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner=new Scanner(System.in);
        HashMap<Integer,BankAccount>records=new HashMap<>();

        while (true) {
            String input = scanner.nextLine();
            if (input.equals("End")) {
                break;
            }
            String[] cmdArgs = input.split(" ");
            int id=Integer.valueOf(cmdArgs[1]);
            switch (cmdArgs[0]) {
                case "Create":
                    executeCreateCommand(records, id);
                    break;
                case "Deposit":
                    executeDepositCommand(records, cmdArgs);
                    break;
                case "Withdraw":
                    executeWithdrawCommand(records, cmdArgs);
                    break;
                case "Print":
                    executePrintCommand(records.get(Integer.valueOf(cmdArgs[1])));
                    break;
            }
        }
//
//        bankAccount.setId(1);
//        bankAccount.deposit(15);
//        bankAccount.withdraw(5);
//        System.out.printf("Account %s, balance %.2f", bankAccount, bankAccount.getBalance());

    }

    private static void executePrintCommand(BankAccount bankAccount) {
        try {
            System.out.printf(String.format(Locale.ROOT,"Account %s, balance %.2f %n",
                    bankAccount,
                    bankAccount.getBalance()));
        } catch (Exception e) {
            System.out.println("Account does not exist");
        }
    }

    private static void executeWithdrawCommand(HashMap<Integer, BankAccount> records, String[] cmdArg) {
        int id = Integer.valueOf(cmdArg[1]);
        int value = Integer.valueOf(cmdArg[2]);
        if (!records.containsKey(id)) {
            System.out.println("Account does not exist");
            return;
        }
        records.get(id).withdraw(value);
    }

    private static void executeDepositCommand(HashMap<Integer, BankAccount> records, String[] cmdArg) {
        int id=Integer.valueOf(cmdArg[1]);
        int value=Integer.valueOf(cmdArg[2]);

        if (!records.containsKey(id)) {
            System.out.println("Account does not exist");
            return;
        }
        records.get(id).deposit(value);
    }

    private static void executeCreateCommand(HashMap<Integer, BankAccount> records, int id) {
        if (records.containsKey(id)) {
            System.out.println("Account already exists");
            return;
        }
        BankAccount bankAccount = new BankAccount();
        records.put(id,bankAccount);
        records.get(id).setId(id);
    }
}

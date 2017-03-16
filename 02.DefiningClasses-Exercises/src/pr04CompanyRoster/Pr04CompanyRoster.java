package solutions.pr04CompanyRoster;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

class Employee {
    String name;
    double salary;
    String position;
    String department;
    String email;
    int age;

    Employee(String name, double salary,
             String position, String department) {
        this(name, salary, position, department, "n/a", -1);
    }

    Employee(String name, double salary, String position,
             String department, String email) {
        this(name, salary, position, department, email, -1);
    }

    Employee(String name, double salary, String position,
             String department, int age) {
        this(name, salary, position, department, "n/a", age);
    }

    Employee(String name, double salary, String position,
             String department, String email, int age) {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }
}

public class Pr04CompanyRoster {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        LinkedHashMap<String, List<Employee>> employeesByDepartment =
                new LinkedHashMap<>();

        int lines = Integer.parseInt(reader.readLine());
        for (int i = 0; i < lines; i++) {
            String[] parameters = reader.readLine().split("\\s+");

            String name = parameters[0];
            double salary = Double.parseDouble(parameters[1]);
            String position = parameters[2];
            String department = parameters[3];

            Employee employee = null;
            if (parameters.length == 4) {
                employee = new Employee(name, salary, position, department);
            } else if (parameters.length == 5) {
                try {
                    int age = Integer.parseInt(parameters[4]);
                    employee = new Employee(name, salary, position, department, age);
                } catch (NumberFormatException e) {
                    String email = parameters[4];
                    employee = new Employee(name, salary, position, department, email);
                }
            } else if (parameters.length == 6) {
                String email = parameters[4];
                int age = Integer.parseInt(parameters[5]);
                employee = new Employee(name, salary, position, department, email, age);
            }

            if (!employeesByDepartment.containsKey(department)) {
                employeesByDepartment.put(department, new ArrayList<>());
            }

            employeesByDepartment.get(department).add(employee);
        }

        double maxAverageSalary = 0d;
        String richestDepartment = "";
        for (Map.Entry<String, List<Employee>> department :
                employeesByDepartment.entrySet()) {
            double average = 0d;

            for (Employee employee : department.getValue()) {
                average += employee.salary;
            }
            average /= department.getValue().size();

            if (average > maxAverageSalary) {
                maxAverageSalary = average;
                richestDepartment = department.getKey();
            }
        }

        System.out.printf("Highest Average Salary: %s%n", richestDepartment);
        List<Employee> sortedEmployees = employeesByDepartment
                .get(richestDepartment)
                .stream()
                .sorted((e1, e2) -> Double.compare(e2.salary, e1.salary))
                .collect(Collectors.toList());
        for (Employee employee : sortedEmployees) {
            System.out.printf("%s %.2f %s %d%n",
                    employee.name,
                    employee.salary,
                    employee.email,
                    employee.age);
        }
    }
}

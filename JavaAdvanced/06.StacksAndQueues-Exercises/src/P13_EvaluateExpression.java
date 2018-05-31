import java.util.*;

public class P13_EvaluateExpression {

    private final static Set<String> operators = new HashSet<>();

    public static void main(String[] args) {
        Collections.addAll(operators, "+", "-", "*", "/");

        Scanner scanner = new Scanner(System.in);
        String infix = scanner.nextLine();
        String[] tokens = infix.split("\\s+");

        Deque<String> operatorStack = new ArrayDeque<>();
        Deque<String> outputQueue = new ArrayDeque<>();

        Deque<String> postfix = getPostfix(tokens, operatorStack, outputQueue);

        double result = evaluateExpression(postfix);
        System.out.printf("%.2f", result);
    }

    private static double evaluateExpression(Deque<String> postfix) {
        Deque<Double> stack = new ArrayDeque<>();

        for (String token : postfix) {
            if (isNumber(token)) {
                stack.push(Double.valueOf(token));
            }
            else if (operators.contains(token)) {
                Double second = stack.pop();
                Double first = stack.pop();
                Double result = 0d;
                switch (token) {
                    case "+":
                        result = first + second;
                        break;

                    case "-":
                        result = first - second;
                        break;

                    case "*":
                        result = first * second;
                        break;

                    case "/":
                        result = first / second;
                        break;
                }

                stack.push(result);
            }
        }

        return stack.pop();
    }

    private static Deque<String> getPostfix(String[] tokens, Deque<String> operatorStack, Deque<String> outputQueue) {

        for (String token : tokens) {
            if (isNumber(token)) {
                outputQueue.offer(token);
            }
            else if (operators.contains(token)) {
                int precedence = getPrecedence(token);
                while (!operatorStack.isEmpty() && getPrecedence(operatorStack.peek()) >= precedence) {
                    outputQueue.offer(operatorStack.pop());
                }

                operatorStack.push(token);
            }
            else if (token.equals("(")) {
                operatorStack.push(token);
            }
            else if (token.equals(")")) {
                while (!operatorStack.isEmpty() && !operatorStack.peek().equals("(")) {
                    outputQueue.offer(operatorStack.pop());
                }

                operatorStack.pop();
            }
        }

        while (!operatorStack.isEmpty()) {
            outputQueue.offer(operatorStack.pop());
        }

        return outputQueue;
    }

    private static int getPrecedence(String token) {
        switch (token) {
            case "+":
            case "-":
                return 1;
            case "*":
            case "/":
                return 2;
            case "(":
            case ")":
                return -1;
            default:
                return 1;
        }
    }

    private static boolean isNumber(String token) {
        return !operators.contains(token) && !(token.equals("(") || token.equals(")"));
    }
}

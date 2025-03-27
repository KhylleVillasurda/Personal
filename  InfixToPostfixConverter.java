import java.util.Stack;
import java.util.HashMap;

public class InfixToPostfixConverter {
    
    // Define operator precedence
    private static final HashMap<Character, Integer> PRECEDENCE = new HashMap<>();
    static {
        PRECEDENCE.put('^', 4);
        PRECEDENCE.put('*', 3);
        PRECEDENCE.put('/', 3);
        PRECEDENCE.put('+', 2);
        PRECEDENCE.put('-', 2);
    }
    
    public static String infixToPostfix(String infix) {
        StringBuilder postfix = new StringBuilder();
        Stack<Character> stack = new Stack<>();
        
        for (int i = 0; i < infix.length(); i++) {
            char c = infix.charAt(i);
            
            // Skip whitespace
            if (c == ' ') continue;
            
            // If operand, add to output
            if (Character.isLetterOrDigit(c)) {
                postfix.append(c);
            }
            // If '(', push to stack
            else if (c == '(') {
                stack.push(c);
            }
            // If ')', pop and output until '('
            else if (c == ')') {
                while (!stack.isEmpty() && stack.peek() != '(') {
                    postfix.append(stack.pop());
                }
                stack.pop(); // Remove '(' from stack
            }
            // If operator
            else {
                while (!stack.isEmpty() && stack.peek() != '(' && 
                       hasHigherPrecedence(stack.peek(), c)) {
                    postfix.append(stack.pop());
                }
                stack.push(c);
            }
        }
        
        // Pop all remaining operators
        while (!stack.isEmpty()) {
            postfix.append(stack.pop());
        }
        
        return postfix.toString();
    }
    
    private static boolean hasHigherPrecedence(char op1, char op2) {
        return (PRECEDENCE.containsKey(op1) && 
                PRECEDENCE.get(op1) >= PRECEDENCE.get(op2));
    }
    
    public static void main(String[] args) {
        String[] testExpressions = {
            "A+B*C",
            "(A+B)*C",
            "A*(B+C)",
            "A+B*C-D",
            "A^B*C-D+E/F/(G+H)",
            "K+L-M*N+(O^P)*W/U/V*T+Q"
        };
        
        for (String expr : testExpressions) {
            System.out.println("Infix: " + expr);
            System.out.println("Postfix: " + infixToPostfix(expr));
            System.out.println();
        }
    }
}
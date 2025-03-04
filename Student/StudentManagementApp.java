import java.util.Scanner;

public class StudentManagementApp {
    private Student[] students;
    private int count;

    public StudentManagementApp() {
        students = new Student[100];
        count = 0;
    }

    public void addStudent() {
        if (count < students.length) {
            Scanner scanner = new Scanner(System.in);
            System.out.print("Enter ID: ");
            String id = scanner.nextLine();
            System.out.print("Enter First Name: ");
            String firstName = scanner.nextLine();
            System.out.print("Enter Last Name: ");
            String lastName = scanner.nextLine();
            System.out.print("Enter Course: ");
            String course = scanner.nextLine();
            System.out.print("Enter Year Level: ");
            String yearLevel = scanner.nextLine();

            students[count] = new Student(id, firstName, lastName, course, yearLevel);
            count++;
            System.out.println("Student added successfully!");
        } else {
            System.out.println("Cannot add more students. Array is full.");
        }
    }

    public void displayAllStudents() {
        if (count == 0) {
            System.out.println("No student records to display.");
        } else {
            for (int i = 0; i < count; i++) {
                System.out.println(students[i]);
            }
        }
    }

    public void displayStudentsInReverse() {
        if (count == 0) {
            System.out.println("No student records to display.");
        } else {
            for (int i = count - 1; i >= 0; i--) {
                System.out.println(students[i]);
            }
        }
    }

    public void menu() {
        Scanner scanner = new Scanner(System.in);
        while (true) {
            System.out.println("\nChoose an option:");
            System.out.println("1. Add New Student");
            System.out.println("2. Display All Students");
            System.out.println("3. Display All Students in Reverse");
            System.out.println("0. Exit/Terminate Program");

            int choice = scanner.nextInt();
            scanner.nextLine(); 
            switch (choice) {
                case 1:
                    addStudent();
                    break;
                case 2:
                    displayAllStudents();
                    break;
                case 3:
                    displayStudentsInReverse();
                    break;
                case 0:
                    System.out.println("Exiting program.");
                    return;
                default:
                    System.out.println("Invalid option! Please try again.");
            }
        }
    }

    public static void main(String[] args) {
        StudentManagementApp app = new StudentManagementApp();
        app.menu();
    }
}
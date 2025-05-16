import java.util.Scanner;

public class OnlineAddressBook {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        AddressBookLinkedList addressBook = new AddressBookLinkedList();
        
        while (true) {
            printMenu();
            
            int choice = scanner.nextInt();
            scanner.nextLine(); 
            
            switch (choice) {
                case 1:
                    addNewEntry(scanner, addressBook);
                    break;
                case 2:
                    searchByLastName(scanner, addressBook);
                    break;
                case 3:
                    deleteByLastName(scanner, addressBook);
                    break;
                case 4:
                    printPersonDetails(scanner, addressBook);
                    break;
                case 5:
                    printBirthdaysInMonth(scanner, addressBook);
                    break;
                case 6:
                    printNamesBetweenLastNames(scanner, addressBook);
                    break;
                case 7:
                    addressBook.printAll();
                    break;
                case 8:
                    System.out.println("Exiting the program. Goodbye!");
                    scanner.close();
                    System.exit(0);
                    break;
                default:
                    System.out.println("Invalid choice. Please try again.");
            }
        }
    }

    private static void printMenu() {
        System.out.println("\nOnline Address Book Menu:");
        System.out.println("1. Add a new entry");
        System.out.println("2. Search by last name");
        System.out.println("3. Delete by last name");
        System.out.println("4. Print person's details");
        System.out.println("5. Print birthdays in a month between dates");
        System.out.println("6. Print names between two last names");
        System.out.println("7. Print all entries");
        System.out.println("8. Exit");
        System.out.print("Enter your choice: ");
    }

    private static void addNewEntry(Scanner scanner, AddressBookLinkedList addressBook) {
        System.out.print("Enter first name: ");
        String firstName = scanner.nextLine();
        System.out.print("Enter last name: ");
        String lastName = scanner.nextLine();
        
        System.out.print("Enter street address: ");
        String street = scanner.nextLine();
        System.out.print("Enter city: ");
        String city = scanner.nextLine();
        System.out.print("Enter state: ");
        String state = scanner.nextLine();
        System.out.print("Enter ZIP code: ");
        String zip = scanner.nextLine();
        
        System.out.print("Enter phone number: ");
        String phone = scanner.nextLine();
        
        System.out.print("Enter relationship (family/friend/business): ");
        String relationship = scanner.nextLine();
        
        System.out.print("Do you want to add date of birth? (y/n): ");
        String addDob = scanner.nextLine();
        Date dob = null;
        if (addDob.equalsIgnoreCase("y")) {
            System.out.print("Enter month (1-12): ");
            int month = scanner.nextInt();
            System.out.print("Enter day: ");
            int day = scanner.nextInt();
            System.out.print("Enter year: ");
            int year = scanner.nextInt();
            scanner.nextLine();
            dob = new Date(month, day, year);
        }
        
        Person person = new Person(firstName, lastName);
        Address address = new Address(street, city, state, zip);
        ExtPerson newEntry = new ExtPerson(person, address, dob, phone, relationship);
        
        if (addressBook.add(newEntry)) {
            System.out.println("Entry added successfully.");
        } else {
            System.out.println("Error: A person with this name already exists in the address book.");
        }
    }

    private static void searchByLastName(Scanner scanner, AddressBookLinkedList addressBook) {
        System.out.print("Enter last name to search: ");
        String searchLastName = scanner.nextLine();
        AddressBookLinkedList searchResults = addressBook.searchByLastName(searchLastName);
        
        if (searchResults.isEmpty()) {
            System.out.println("No entries found with that last name.");
        } else {
            System.out.println("Found " + searchResults.size() + " entries:");
            searchResults.printAll();
        }
    }

    private static void deleteByLastName(Scanner scanner, AddressBookLinkedList addressBook) {
        System.out.print("Enter last name to delete: ");
        String deleteLastName = scanner.nextLine();
        if (addressBook.deleteByLastName(deleteLastName)) {
            System.out.println("Entry deleted successfully.");
        } else {
            System.out.println("No entry found with that last name.");
        }
    }

    private static void printPersonDetails(Scanner scanner, AddressBookLinkedList addressBook) {
        System.out.print("Enter first name: ");
        String searchFirstName = scanner.nextLine();
        System.out.print("Enter last name: ");
        String searchLastName = scanner.nextLine();
        addressBook.printPersonDetails(searchFirstName, searchLastName);
    }

    private static void printBirthdaysInMonth(Scanner scanner, AddressBookLinkedList addressBook) {
        System.out.print("Enter month (1-12): ");
        int bMonth = scanner.nextInt();
        System.out.print("Enter start day: ");
        int startDay = scanner.nextInt();
        System.out.print("Enter end day: ");
        int endDay = scanner.nextInt();
        scanner.nextLine();
        addressBook.printBirthdaysInMonth(bMonth, startDay, endDay);
    }

    private static void printNamesBetweenLastNames(Scanner scanner, AddressBookLinkedList addressBook) {
        System.out.print("Enter starting last name: ");
        String startLastName = scanner.nextLine();
        System.out.print("Enter ending last name: ");
        String endLastName = scanner.nextLine();
        addressBook.printNamesBetweenLastNames(startLastName, endLastName);
    }
}

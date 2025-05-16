public class AddressBookLinkedList {
    private AddressBookNode head;
    private int size;

    public AddressBookLinkedList() {
        head = null;
        size = 0;
    }

    public boolean add(ExtPerson newPerson) {
        if (contains(newPerson.getPerson().getFirstName(), newPerson.getPerson().getLastName())) {
            return false;
        }

        AddressBookNode newNode = new AddressBookNode(newPerson);
        if (head == null) {
            head = newNode;
        } else {
            AddressBookNode current = head;
            while (current.next != null) {
                current = current.next;
            }
            current.next = newNode;
        }
        size++;
        return true;
    }

    private boolean contains(String firstName, String lastName) {
        AddressBookNode current = head;
        while (current != null) {
            if (current.data.getPerson().getFirstName().equalsIgnoreCase(firstName) &&
                current.data.getPerson().getLastName().equalsIgnoreCase(lastName)) {
                return true;
            }
            current = current.next;
        }
        return false;
    }

    public AddressBookLinkedList searchByLastName(String lastName) {
        AddressBookLinkedList results = new AddressBookLinkedList();
        AddressBookNode current = head;
        while (current != null) {
            if (current.data.getPerson().getLastName().equalsIgnoreCase(lastName)) {
                results.add(current.data);
            }
            current = current.next;
        }
        return results;
    }

    public boolean deleteByLastName(String lastName) {
        if (head == null) return false;

        if (head.data.getPerson().getLastName().equalsIgnoreCase(lastName)) {
            head = head.next;
            size--;
            return true;
        }

        AddressBookNode current = head;
        while (current.next != null) {
            if (current.next.data.getPerson().getLastName().equalsIgnoreCase(lastName)) {
                current.next = current.next.next;
                size--;
                return true;
            }
            current = current.next;
        }
        return false;
    }

    public void printPersonDetails(String firstName, String lastName) {
        AddressBookNode current = head;
        while (current != null) {
            if (current.data.getPerson().getFirstName().equalsIgnoreCase(firstName) &&
                current.data.getPerson().getLastName().equalsIgnoreCase(lastName)) {
                current.data.printInfo();
                return;
            }
            current = current.next;
        }
        System.out.println("Person not found in the address book.");
    }

    public void printBirthdaysInMonth(int month, int startDay, int endDay) {
        System.out.println("People with birthdays between " + startDay + " and " + endDay + " of month " + month + ":");
        boolean found = false;
        
        AddressBookNode current = head;
        while (current != null) {
            if (current.data.getDateOfBirth() != null) {
                Date dob = current.data.getDateOfBirth();
                if (dob.getMonth() == month && dob.getDay() >= startDay && dob.getDay() <= endDay) {
                    current.data.getPerson().printName();
                    found = true;
                }
            }
            current = current.next;
        }
        
        if (!found) {
            System.out.println("No birthdays found in the specified range.");
        }
    }

    public void printNamesBetweenLastNames(String startLastName, String endLastName) {
        System.out.println("People with last names between " + startLastName + " and " + endLastName + ":");
        boolean found = false;
        
        AddressBookNode current = head;
        while (current != null) {
            String currentLastName = current.data.getPerson().getLastName().toLowerCase();
            if (currentLastName.compareTo(startLastName.toLowerCase()) >= 0 && 
                currentLastName.compareTo(endLastName.toLowerCase()) <= 0) {
                current.data.getPerson().printName();
                found = true;
            }
            current = current.next;
        }
        
        if (!found) {
            System.out.println("No people found in the specified last name range.");
        }
    }

    public void printAll() {
        AddressBookNode current = head;
        while (current != null) {
            current.data.printInfo();
            System.out.println("-------------------");
            current = current.next;
        }
    }

    public boolean isEmpty() {
        return size == 0;
    }

    public int size() {
        return size;
    }
}
public class ExtPerson {
    private Person person;
    private Address address;
    private Date dateOfBirth;
    private String phoneNumber;
    private String relationship;

    public ExtPerson(Person person, Address address, Date dateOfBirth, String phoneNumber, String relationship) {
        this.person = person;
        this.address = address;
        this.dateOfBirth = dateOfBirth;
        this.phoneNumber = phoneNumber;
        this.relationship = relationship;
    }

    public void printInfo() {
        person.printName();
        address.printAddress();
        System.out.println("Phone: " + phoneNumber);
        if (dateOfBirth != null) {
            dateOfBirth.printDate();
        }
        System.out.println("Relationship: " + relationship);
    }

    public Person getPerson() { return person; }
    public Address getAddress() { return address; }
    public Date getDateOfBirth() { return dateOfBirth; }
    public String getPhoneNumber() { return phoneNumber; }
    public String getRelationship() { return relationship; }
}
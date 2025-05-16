public class AddressBookNode {
    ExtPerson data;
    AddressBookNode next;

    public AddressBookNode(ExtPerson data) {
        this.data = data;
        this.next = null;
    }
}
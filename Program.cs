using System;

namespace NewAddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Addressbook program!");
            AddressBookMain addressBook = new AddressBookMain();
            addressBook.Display();

        }
    }
}

using System;

namespace NewAddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Addressbook program!");
            AddressBookMain ab = new AddressBookMain();
            Person person = new Person();
            ab.Display();
           
        }
    }
}

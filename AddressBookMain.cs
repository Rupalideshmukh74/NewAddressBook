using System;
using System.Collections.Generic;
using System.Text;

namespace NewAddressBook
{
    public class AddressBookMain
    {
        public static List<Person> ContactList = new List<Person>();
        public void Display()
        {
            Person person = new Person();

            Console.WriteLine(" Welcome to Address Book Program \n");
            Console.Write("Enter First Name: ");
            person.Firstname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            person.Lastname = Console.ReadLine();

            Console.Write("Enter Address: ");
            person.Address = Console.ReadLine();

            Console.Write("Enter City: ");
            person.City = Console.ReadLine();

            Console.Write("Enter State: ");
            person.State = Console.ReadLine();

            Console.Write("Enter ZipCode: ");
            person.ZipCode = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Phone Number: ");
            person.PhoneNumber = Console.ReadLine();

            Console.Write("Enter EmailId: ");
            person.EmailId = Console.ReadLine();

            ContactList.Add(person);

        }
    }
}


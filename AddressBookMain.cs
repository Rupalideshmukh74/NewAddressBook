using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace NewAddressBook
{
    class AddressBookMain
    {
        //list for storing objects for person class
        public List<Person> ContactList;
        public static Dictionary<string, List<Person>> contactsDictionary = new Dictionary<string, List<Person>>();
        public static string adrBookName;

        public AddressBookMain()
        {
            this.ContactList = new List<Person>();
        }

        //starting application
        public void Book()
        {
            NewAdrBook();
        }


        //new address book / dictionary
        public static void NewAdrBook()
        {
            Console.Write("Creating a new AddressBook. " + "\nPlease Enter Name : ");
            adrBookName = Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------");

            if (contactsDictionary.ContainsKey(adrBookName))
            {
                Console.WriteLine(" This name already exists.. Please add new name..");
                NewAdrBook();
            }
            else
            {
                contactsDictionary[adrBookName] = new List<Person>();
                Console.WriteLine("List of Address Books : ");
                Console.WriteLine("------------------------");
                foreach (var ab in contactsDictionary)
                {
                    Console.Write("\t" + ab.Key);
                }
                AddPersonInfo(adrBookName);
            }

        }

        // add contact method
        public static void AddPersonInfo(string adrBookName)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("\nWorking on address book : " + adrBookName);
            Console.WriteLine("Add Person Details :: ");
            Console.WriteLine("-------------------------");
            Person persn = new Person();

            Console.Write("\nEnter First Name : ");
            persn.FirstName = Console.ReadLine();

            // UC7: search duplicate entry of first name
            DuplicateNameCheck(persn.FirstName);

            Console.Write("Enter Last Name : ");
            persn.LastName = Console.ReadLine();

            Console.Write("Enter Address/landmark : ");
            persn.Address = Console.ReadLine();

            Console.Write("Enter City : ");
            persn.City = Console.ReadLine();

            Console.Write("Enter State : ");
            persn.State = Console.ReadLine();

            Console.Write("Enter PinCode : ");
            persn.ZipCode = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Phone Number (+91) : ");
            persn.PhoneNumber = Console.ReadLine();

            Console.Write("Enter EmailId : ");
            persn.EmailId = Console.ReadLine();

            contactsDictionary[adrBookName].Add(persn);
            ContactManager.Operations();

        }

        static void DuplicateNameCheck(string searchName)
        {
            Console.Write(" --> Checking existing first names : ");
            bool isPresent = contactsDictionary.Values.SelectMany(contact => contact).Any(adrBookName => adrBookName.FirstName.ToUpper().Equals(searchName.ToUpper()));

            if (isPresent)
            {
                Console.Write(" This name already exists. Please add different one.\n");
                AddPersonInfo(adrBookName);
            }
            else
            {
                Console.WriteLine(" No duplicate Entry");
            }
        }

        //edit contact method
        public static void ModifyPersonInfo(string adrBookName, string findName)
        {
            Console.WriteLine("\n Working on address book : " + adrBookName);
            if (contactsDictionary[adrBookName].Count > 0)
            {
                foreach (Person per in contactsDictionary[adrBookName])
                {
                    if (findName.ToUpper().Equals(per.FirstName.ToUpper()))
                    {
                        Console.WriteLine("\n [ EDIT CONTACT ] Select Field to edit -\n 1.First_name\t2.Last_name\t3.Address\t4.City\t5.State\t6.Zipcode\t7.Phone_Number\t8.EmailId ");
                        Console.WriteLine(" Type 0 to Exit Edit operation. ");
                        Console.Write(" Please provide an option : ");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Write(" Modify FirstName : ");
                                per.FirstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write(" Modify LastName : ");
                                per.LastName = Console.ReadLine();
                                break;
                            case 3:
                                Console.Write(" Modify AddressLine : ");
                                per.Address = Console.ReadLine();
                                break;
                            case 4:
                                Console.Write(" Modify City : ");
                                per.City = Console.ReadLine();
                                break;
                            case 5:
                                Console.Write(" Modify State : ");
                                per.State = Console.ReadLine();
                                break;
                            case 6:
                                Console.Write(" Modify ZipCode : ");
                                per.ZipCode = int.Parse(Console.ReadLine());
                                break;
                            case 7:
                                Console.Write(" Modify PhoneNumber : ");
                                per.PhoneNumber = Console.ReadLine();
                                break;
                            case 8:
                                Console.Write(" Modify EmailId : ");
                                per.EmailId = Console.ReadLine();
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine(" Invalid value entered.");
                                break;
                        }
                    }
                }
            }

        }


        //delete selected contact
        public static void DeletePersonInfo(string adrBookName, string findName)
        {
            if (contactsDictionary.ContainsKey(adrBookName))
            {
                Console.WriteLine("\n Working on address book : " + adrBookName);
                int deleted = 0;

                if (contactsDictionary[adrBookName].Count > 0)
                {
                    foreach (Person contact in contactsDictionary[adrBookName])
                    {
                        if (findName.ToUpper() == contact.FirstName.ToUpper())
                        {
                            contactsDictionary[adrBookName].Remove(contact);
                            deleted = 1;
                            Console.WriteLine(" Contact of {0} removed.", findName);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" - - ");
                        }
                    }
                }
                if (deleted == 0)
                {
                    Console.WriteLine(" Contact not present. ");
                }
            }
            else
            {
                Console.WriteLine(" address book not found.");
            }
        }

        //display saved Contacts
        public static void DisplayContacts(string adrBookName)
        {

            if (contactsDictionary[adrBookName].Count > 0)
            {
                Console.WriteLine(" Displaying contacts in addresss book : " + adrBookName);
                foreach (Person person in contactsDictionary[adrBookName])
                {
                    Console.WriteLine(" First Name \t: {0} \n Last Name \t: {1} ", person.FirstName, person.LastName);
                    Console.WriteLine(" Address \t: {0} \n City \t\t: {1} ", person.Address, person.City);
                    Console.WriteLine(" State \t\t: {0} \n ZipCode \t: {1} ", person.State, person.ZipCode);
                    Console.WriteLine(" Phone Number \t: {0} \n EmailId \t: {1} \n", person.PhoneNumber, person.EmailId);
                }
            }
            else
            {
                Console.WriteLine(" No contacts Present. Please add new contact. \n");
            }
        }
        public static void SearchPerson()
        {
            Console.WriteLine(" Searching By City or state and displying person name  \n");
            Console.Write(" Enter city/state name : ");
            string cityState = Console.ReadLine();
            int dataNotFound = 1;
            Console.WriteLine(" Displaying person name and location details containing : " + cityState);

            foreach (var ab in contactsDictionary)
            {
                foreach (Person person in contactsDictionary[ab.Key])
                {
                    if (person.State.Equals(cityState) || person.City.Equals(cityState))
                    {
                        Console.WriteLine(" - - -  AddressBook : {0}  - - - ", ab.Key);
                        Console.WriteLine(" \tFirst Name : {0} \t Last Name : {1} ", person.FirstName, person.LastName);
                        Console.WriteLine(" \tCity \t: {0} \t State \t: {1} ", person.City, person.State);
                        dataNotFound = 0;
                    }
                }
            }
            if (dataNotFound == 1)
            {
                Console.WriteLine(" Your input does not match any of the contact in address book.");
            }

        }
        //View Person by City or state
        public static void DisplayByCityState()
        {
            //Declaring Dictionary
            Dictionary<string, List<Person>> personInCity = new Dictionary<string, List<Person>>();
            Dictionary<string, List<Person>> personInState = new Dictionary<string, List<Person>>();

            //Display Messages
            Console.WriteLine(" Displying person details By City or state \n");
            Console.Write(" Enter city name : ");

            //Read City Name
            string cityName = Console.ReadLine();
            personInCity[cityName] = new List<Person>();

            //read State Name
            Console.Write(" Enter State name : ");
            string stateName = Console.ReadLine();
            personInState[stateName] = new List<Person>();

            //Check person for display
            foreach (var ab in contactsDictionary)
            {
                foreach (Person person in contactsDictionary[ab.Key])
                {
                    if (person.City.ToUpper().Equals(cityName.ToUpper()))
                    {
                        personInCity[cityName].Add(person);
                    }

                    if (person.State.ToUpper().Equals(stateName.ToUpper()))
                    {
                        personInState[stateName].Add(person);
                    }
                }
            }

            //Display
            Console.WriteLine("\n - - -  City : {0}  - - - ", cityName);
            foreach (var data in personInCity[cityName])
            {
                Console.Write(" First Name : {0} \t Last Name : {1} ", data.FirstName, data.LastName);
                Console.Write(" \tCity \t: {0} \t State \t: {1} \n", data.City, data.State);
            }

            Console.WriteLine("\n\n - - -  State : {0}  - - - ", stateName);
            foreach (var data in personInState[stateName])
            {
                Console.Write(" First Name : {0} \t Last Name : {1} ", data.FirstName, data.LastName);
                Console.Write(" \tCity \t: {0} \t State \t: {1} \n", data.City, data.State);
            }
        }

    }
}

    

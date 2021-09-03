﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NewAddressBook
{
    class ContactFileOperation
    {
        public static void FileOps()
        {
            string path = @"C:\Users\DELL\source\repos\NewAddressBook\NewAddressBook\ContactFile.txt";
            WriteDataToFile(path);
            ReadDataFromFile(path);
        }

        static void WriteDataToFile(string path)
        {
            Console.WriteLine("\n - - - Writing contacts to file - - - ");
            if (File.Exists(path))
            {
                Console.WriteLine("File exists.");
                StreamWriter writer = new StreamWriter(path);

                writer.WriteLine("FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,EmailId");
                foreach (var ab in AddressBookMain.contactsDictionary)
                {
                    writer.WriteLine("Inside Address Book : " + ab.Key);
                    foreach (Person person in AddressBookMain.contactsDictionary[ab.Key])
                    {
                        string data =
                            person.FirstName + "," + person.LastName + "," + person.Address + "," + person.City + "," + person.State + "," + person.ZipCode + "," + person.PhoneNumber + "," + person.EmailId;

                        writer.WriteLine(data);
                    }
                }
                Console.WriteLine(" File Write success.");
                writer.Close();
            }
            else
            {
                Console.WriteLine(" Process Not completed.");
            }
        }

        static void ReadDataFromFile(string path)
        {
            Console.WriteLine("\n - - - Reading contacts from text file - - - ");
            StreamReader file = new StreamReader(path);
            using (file)
            {
                string data;
                while ((data = file.ReadLine()) != null)
                {
                    Console.WriteLine(data);
                }
            }
        }
    }
}
    

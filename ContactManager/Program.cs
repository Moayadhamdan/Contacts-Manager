using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager
{
    public class Program
    {
        private static List<Contact> contacts = new List<Contact>();

        static void Main(string[] args)
        {
            ContactsManager();
        }

        public static void ContactsManager()
        {
            //// Implementation of the console application functionality (test cases)
            //{
            //    bool exitRequested = false;

            //    while (!exitRequested)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine("Welcome to the Contact Manager");
            //        Console.WriteLine("1. Add a contact");
            //        Console.WriteLine("2. Remove a contact");
            //        Console.WriteLine("3. View all contacts");
            //        Console.WriteLine("4. Search for a contact");
            //        Console.WriteLine("5. Clear all contacts");
            //        Console.WriteLine("6. Exit");
            //        Console.Write("Enter your choice (1-6): ");

            //        string choice = Console.ReadLine();
            //        Console.WriteLine();

            //        switch (choice)
            //        {
            //            case "1":
            //                Console.Write("Enter contact name: ");
            //                string nameToAdd = Console.ReadLine();
            //                Console.Write("Enter contact category: ");
            //                string categoryToAdd = Console.ReadLine();

            //                try
            //                {
            //                    AddContact(nameToAdd, categoryToAdd);
            //                    Console.WriteLine("Contact added successfully.");
            //                }
            //                catch (InvalidOperationException ex)
            //                {
            //                    Console.WriteLine($"Error: {ex.Message}");
            //                }
            //                break;

            //            case "2":
            //                Console.Write("Enter contact name to remove: ");
            //                string nameToRemove = Console.ReadLine();

            //                try
            //                {
            //                    RemoveContact(nameToRemove);
            //                    Console.WriteLine("Contact removed successfully.");
            //                }
            //                catch (KeyNotFoundException ex)
            //                {
            //                    Console.WriteLine($"Error: {ex.Message}");
            //                }
            //                break;

            //            case "3":
            //                var allContacts = ViewAllContacts();
            //                Console.WriteLine("All contacts:");
            //                foreach (var contact in allContacts)
            //                {
            //                    Console.WriteLine(contact);
            //                }
            //                break;

            //            case "4":
            //                Console.Write("Enter contact name to search: ");
            //                string nameToSearch = Console.ReadLine();
            //                string searchResult = SearchContact(nameToSearch);
            //                Console.WriteLine(searchResult);
            //                break;

            //            case "5":
            //                ClearContacts();
            //                Console.WriteLine("All contacts cleared.");
            //                break;

            //            case "6":
            //                exitRequested = true;
            //                Console.WriteLine("Exiting the Contact Manager.");
            //                break;

            //            default:
            //                Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
            //                break;
            //        }
            //    }
            //}
        }

        public static List<Contact> AddContact(string name, string category)
        {
            if (contacts.Any(c => c.Name == name))
                throw new InvalidOperationException("Contact already exists.");

            var contact = new Contact(name, category);
            contacts.Add(contact);
            return new List<Contact>(contacts);
        }

        public static List<Contact> RemoveContact(string name)
        {
            var contact = contacts.FirstOrDefault(c => c.Name == name);
            if (contact == null)
                throw new KeyNotFoundException("Contact not found.");

            contacts.Remove(contact);
            return new List<Contact>(contacts); 
        }

        public static List<Contact> ViewAllContacts()
        {
            return new List<Contact>(contacts); 
        }

        public static string SearchContact(string name)
        {
            var contact = contacts.FirstOrDefault(c => c.Name == name);
            return contact != null ? contact.ToString() : "Contact not found.";
        }

        public static void ClearContacts()
        {
            contacts.Clear();
        }
    }
}

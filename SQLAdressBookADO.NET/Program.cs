﻿using SQLAdressBookADO.NET;

public class Program
{
    static void Main(string[] args)
    {
        Operations Method = new Operations();

        while (true)
        {
            Console.WriteLine("Address Book :");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit/Update Contact");
            Console.WriteLine("3. Display Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Add Contact by Stored Procedure");
            Console.WriteLine("6. exit");

            Console.Write("Enter Choices: ");
            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Phone_Nmber: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("State: ");
                    string state = Console.ReadLine();
                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("Zipcode: ");
                    string zipCode = Console.ReadLine();

                    Contact newContact = new Contact(name, phoneNumber, email, state, city, zipCode);

                    Method.AddContact(newContact);

                    break;
            }
        }
    }
}
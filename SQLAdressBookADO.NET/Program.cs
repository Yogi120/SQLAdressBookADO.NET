using SQLAdressBookADO.NET;

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
            Console.WriteLine("6. Displaying all contacts");
            Console.WriteLine("7. exit");

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

                case 2:

                    Console.Write("Enter id: ");
                    int Upid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Contact Name: ");
                    string Updatecontact = Console.ReadLine();
                    Console.Write("Enter email: ");
                    string Updateemail = Console.ReadLine();
                    Method.UpdateContact(Updatecontact, Updateemail, Upid);
                    break;

                case 3:

                    Console.WriteLine("Displaying Contact");
                    Method.Display();
                    break;

                case 4:

                    Console.Write("Enter id: ");
                    int id = int.Parse(Console.ReadLine());
                    Method.DeleteContact(id);
                    break;

                case 5:

                    Console.Write("Name: ");
                    string spname = Console.ReadLine();
                    Console.Write("Phone_Nmber: ");
                    string spphoneNumber = Console.ReadLine();
                    Console.Write("Email: ");
                    string spemail = Console.ReadLine();
                    Console.Write("State: ");
                    string spstate = Console.ReadLine();
                    Console.Write("City: ");
                    string spcity = Console.ReadLine();
                    Console.Write("Zipcode: ");
                    string spzipCode = Console.ReadLine();

                    Contact spContact = new Contact(spname, spphoneNumber, spemail, spstate, spcity, spzipCode);
                    Method.SPadddContact(spContact);

                    break;

                case 6:

                    Console.WriteLine("Displaying All contact !!!");
                    Method.SpDisplayContacts();

                    break;

                case 7:

                    Console.WriteLine("Exiting...");
                    return;

                default:

                    Console.WriteLine("Enter Valid input!!");
                    break;
            }
        }
    }
}
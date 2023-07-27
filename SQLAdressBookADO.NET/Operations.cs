using System.Data.SqlClient;

namespace SQLAdressBookADO.NET
{
    public class Operations
    {
        string connection = $"Data Source = (localdb)\\MSSQLLocalDB; Database = AddressBook_DB ;Integrated Security=True";

        //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

        SqlConnection sqlConnection;

        public Operations()
        {
            sqlConnection = new SqlConnection(connection);
        }

        public void AddContact(Contact contact)
        {

            try
            {
                sqlConnection.Open();

                string query = $"INSERT INTO Contact VALUES('{contact.Name}', '{contact.Email}', '{contact.PhoneNumber}', '{contact.State}', '{contact.City}', '{contact.ZipCode}')";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Contact added successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to add contact!");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                sqlConnection.Close();
            }
        }
        public void UpdateContact(string Updatecontact, string Updateemail, int id)
        {
            try
            {
                sqlConnection.Open();

                string updatequery = $"UPDATE Contact SET Email = '{Updateemail}', CName = '{Updatecontact}' WHERE id = '{id}'";
                SqlCommand updatecommand = new SqlCommand(updatequery, sqlConnection);

                int result = updatecommand.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Contact updated sucessfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void Display()
        {
            try
            {
                List<Contact> contactList = new List<Contact>();

                sqlConnection.Open();

                string query = "SELECT * FROM Contact";
                SqlCommand ViewContact = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = ViewContact.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = new Contact()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["CName"],
                        PhoneNumber = (string)reader["Phone_Number"],
                        Email = (string)reader["Email"],
                        State = (string)reader["CState"],
                        City = (string)reader["City"],
                        ZipCode = (String)reader["ZipCode"]
                    };

                    contactList.Add(contact);
                }
                foreach (Contact contact in contactList)
                {
                    Console.WriteLine($"Id: {contact.Id}\t CName: {contact.Name}\t Phone_Number: {contact.PhoneNumber}\t Email: {contact.PhoneNumber}\t CState: {contact.State}\t City: {contact.City}\t ZipCode: {contact.ZipCode}");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                sqlConnection.Close();
            }
        }

        public void DeleteContact(int Id)
        {
            try
            {
                sqlConnection.Open();

                string deletequery = $"DELETE FROM Contact WHERE Id = {Id}";
                SqlCommand deletecommand = new SqlCommand(deletequery, sqlConnection);

                int result = deletecommand.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Contact Deleted sucessfully!!");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                sqlConnection.Close();
            }
        }

    }

}

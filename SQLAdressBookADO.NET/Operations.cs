using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Xml.Linq;

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


        public void SPadddContact(Contact contact)
        {
            sqlConnection.Open();

            string query = "SPAddcontact";
            //SqlTransaction sqlTransaction = sqlConnection.BeginTransacton();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            SqlCommand sqlcmd = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@CName", contact.Name);
            sqlcmd.Parameters.AddWithValue("@Phone_Number", contact.PhoneNumber);
            sqlcmd.Parameters.AddWithValue("@Email", contact.Email);
            sqlcmd.Parameters.AddWithValue("@CState", contact.State);
            sqlcmd.Parameters.AddWithValue("@City", contact.City);
            sqlcmd.Parameters.AddWithValue("@Zipcode", contact.ZipCode);

            try
            {
                int result = sqlcmd.ExecuteNonQuery();
                //sqlTransaction.Commit();
                if (result > 0)
                {
                    Console.WriteLine("Contact added sucessfully !!!");
                }

                else
                {
                    Console.WriteLine("FAILED to add contact !!");
                    sqlConnection.Close();
                }
            }
            catch (Exception)
            {
                sqlcmd.Transaction.Rollback();
                Console.WriteLine("Rollback !!!");
            }

            sqlConnection.Close();
        }

        public void SpDisplayContacts()
        {
            try 
            {
                List<Contact> contacts = new List<Contact>();

                sqlConnection.Open();

                string query = "SpDisplayingContacts";

                SqlCommand displaycontact = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = displaycontact.ExecuteReader();

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
                        ZipCode = (string)reader["ZipCode"],
                    };

                    contacts.Add(contact);
                }

                foreach(Contact contact in contacts)
                {
                    Console.WriteLine($"id: {contact.Id}\t CName: {contact.Name}\t Phone_Number: {contact.PhoneNumber}\t Email: {contact.Email}\t CState: {contact.State}\t City: {contact.City}\t ZipCode: {contact.ZipCode}");
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

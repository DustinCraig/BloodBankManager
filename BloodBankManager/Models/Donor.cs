using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManager.Models
{
    class Donor
    {
        public string Name { get; set; }
        public string BloodGroup { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Rh { get; set; }
        
        //TODO: Find a better way of handling this
        public string Error { get; set; }

        /// <summary>
        /// This function will attempt to save the new donor model to the Donors table in the DB
        /// </summary>
        public void Save()
        {
            StringBuilder errorMessages = new StringBuilder();

            string connString = BloodBankManager.Utilities.GetConnectionString();
            SqlConnection connection = new SqlConnection(connString);
            try
                {
                    connection.Open();
                    string command = @"
                    EXEC dbo.uspAddDonor
                    @pID=@id,
                    @pName=@name,
                    @pBloodGroup=@bloodgroup,
                    @pAge=@age,
                    @pSex=@sex,
                    @pStreetAddress=@streetAddress,
                    @pCity=@city,
                    @pState=@state,
                    @pDate=@date,
                    @pPhoneNumber=@phoneNumber,
                    @pEmail=@email,
                    @pRh=@rh,
                    @responseMessage=@message
                    ";
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.Parameters.AddWithValue("@id", Guid.NewGuid());
                    sqlCommand.Parameters.AddWithValue("@name", Name);
                    sqlCommand.Parameters.AddWithValue("@bloodgroup", BloodGroup);
                    sqlCommand.Parameters.AddWithValue("@age", Age);
                    sqlCommand.Parameters.AddWithValue("@sex", Sex);
                    sqlCommand.Parameters.AddWithValue("@streetAddress", StreetAddress);
                    sqlCommand.Parameters.AddWithValue("@city", City);
                    sqlCommand.Parameters.AddWithValue("@state", State);
                    sqlCommand.Parameters.AddWithValue("@date", Date);
                    sqlCommand.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@email", Email);
                    sqlCommand.Parameters.AddWithValue("@rh", Rh);
                    sqlCommand.Parameters.AddWithValue("@message", Error);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    Console.WriteLine(errorMessages.ToString());
                }
            finally
            {
                connection.Close();
            }
        }
    }
}

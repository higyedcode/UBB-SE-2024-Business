using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Database;

using Microsoft.Data.SqlClient;

namespace Iss.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private IDatabaseConnection databaseConnection;
        private ISqlDataAdapterWrapper adapter;

        public PaymentRepository()
        {
            databaseConnection = new DatabaseConnection();
            adapter = new SqlDataAdapterWrapper();
        }

        public PaymentRepository(IDatabaseConnection databaseConnection, ISqlDataAdapterWrapper adapter)
        {
            this.databaseConnection = databaseConnection;
            this.adapter = adapter;
        }

        public void AddOneAd()
        {
            // add to the database one ad payment
            databaseConnection.OpenConnection();
            string query = "INSERT INTO AdPayment(AdAccountID) values (@adAccountId)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.GetInstance().Id);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void AddOneAdSet()
        {
            // add to the database one ad set payment
            databaseConnection.OpenConnection();
            string query = "INSERT INTO AdSetPayment(AdAccountID) values (@adAccountId)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.GetInstance().Id);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void AddOneCampaign()
        {
            // add to the database one campaign payment
            databaseConnection.OpenConnection();
            string query = "INSERT INTO CampaignPayment(AdAccountID) values (@adAccountId)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.GetInstance().Id);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void RemoveOneAd()
        {
            // remove from the database one ad payment
            databaseConnection.OpenConnection();
            // delete only one add payment
            string query = "DELETE FROM AdPayment WHERE AdAccountID = @adAccountId AND ID = (SELECT TOP 1 ID FROM AdPayment WHERE AdAccountID = @adAccountId)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.GetInstance().Id);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void RemoveOneCampaign()
        {
            databaseConnection.OpenConnection();
            // delete only one campaign payment
            string query = "DELETE FROM CampaignPayment WHERE AdAccountID = @adAccountId AND ID = (SELECT TOP 1 ID FROM CampaignPayment WHERE AdAccountID = @adAccountId)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.GetInstance().Id);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void RemoveOneAdSet()
        {
            databaseConnection.OpenConnection();
            // delete only one ad set payment
            string query = "DELETE FROM AdSetPayment WHERE AdAccountID = @adAccountId AND ID = (SELECT TOP 1 ID FROM AdSetPayment WHERE AdAccountID = @adAccountId)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.GetInstance().Id);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void AddSubscription(string name)
        {
            databaseConnection.OpenConnection();
            // add to the database a subscription
            int number_of_campaigns = Constants.NUMBER_OF_CAMPAIGNS_FOR_SUBSCRIPTION[name];
            string query = "INSERT INTO Subscription Values (@name, @number_of_campaigns, @adAccountId)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@number_of_campaigns", number_of_campaigns);
            command.Parameters.AddWithValue("@adAccountId", User.User.GetInstance().Id);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }
    }
}

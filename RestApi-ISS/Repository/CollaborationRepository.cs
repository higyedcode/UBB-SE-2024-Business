using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Database;
using Iss.Entity;

using Microsoft.Data.SqlClient;

namespace Iss.Repository
{
    internal class CollaborationRepository : IColaborationRepository
    {
        private IDatabaseConnection databaseConnection;
        private ISqlDataAdapterWrapper adapter;
        private DatabaseContext databaseContext;

        public CollaborationRepository()
        {
            databaseConnection = new DatabaseConnection();
            adapter = new SqlDataAdapterWrapper();
        }
        public CollaborationRepository(IDatabaseConnection databaseConnection, ISqlDataAdapterWrapper adapter)
        {
            this.databaseConnection = databaseConnection;
            this.adapter = adapter;
        }

        public void CreateCollaboration(Collaboration collaboration)
        {
            databaseConnection.OpenConnection();

            Influencer requiredInfluencer = databaseContext.Influencer.Where(influencer => influencer.InfluencerName == "Selly").FirstOrDefault();

            collaboration.AdAccountId = User.User.GetInstance().Id;
            collaboration.InfluencerId = requiredInfluencer.InfluencerId;

            databaseContext.Collaboration.Add(collaboration);
            databaseContext.SaveChanges();

            return;

            // Execute the query to get the influencer ID
            // int influencerId = Convert.ToInt32(influencerCommand.ExecuteScalar());
            string query = @"INSERT INTO Collaboration (AdAccountID, InfluencerID, Status, AdOverview, CollaborationTitle, ContentRequirements, CollaborationFee,  StartDate, EndDate) 
                                VALUES (@AdAccountID, @InfluencerID, @Status, @AdOverview, @CollaborationTitle, @ContentRequirements, @CollaborationFee, @StartDate, @EndDate)";

            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@AdAccountID", User.User.GetInstance().Id);
            // command.Parameters.AddWithValue("@InfluencerID", influencerId);
            command.Parameters.AddWithValue("@Status", collaboration.Status);
            command.Parameters.AddWithValue("@AdOverview", collaboration.AdOverview);
            command.Parameters.AddWithValue("@ContentRequirements", collaboration.ContentRequirement);
            command.Parameters.AddWithValue("@CollaborationTitle", collaboration.CollaborationTitle);
            command.Parameters.AddWithValue("@CollaborationFee", collaboration.CollaborationFee);
            command.Parameters.AddWithValue("@StartDate", collaboration.StartDate);
            command.Parameters.AddWithValue("@EndDate", collaboration.EndDate);

            adapter.InsertCommand(command);
            adapter.ExecuteNonQuery(command);
            databaseConnection.CloseConnection();
        }

        public List<Collaboration> GetCollaborationsForAdAccount()
        {
            List<Collaboration> collaborations = new List<Collaboration>();

            collaborations = databaseContext.Collaboration.Where(c => c.AdAccountId == User.User.GetInstance().Id).ToList();
            return collaborations;

            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();

            string query = "SELECT * FROM Collaboration WHERE AdAccountID = @AdAccountID";

            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            System.Diagnostics.Debug.WriteLine(User.User.GetInstance().Id);
            command.Parameters.AddWithValue("@AdAccountID", User.User.GetInstance().Id);

            // Set the SelectCommand property of the SqlDataAdapter
            adapter.SelectCommand(command);
            adapter.ExecuteNonQuery(command);

            // Remove unnecessary code that sets InsertCommand and calls ExecuteNonQuery
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                collaborations.Add(new Collaboration(Convert.ToInt32(dataRow["CollaborationID"]),
                    Convert.ToDateTime(dataRow["StartDate"]), Convert.ToBoolean(dataRow["Status"]),
                    dataRow["ContentRequirements"].ToString(), dataRow["AdOverview"].ToString(),
                    dataRow["CollaborationFee"].ToString(), Convert.ToDateTime(dataRow["EndDate"]).Day - Convert.ToDateTime(dataRow["StartDate"]).Day,
                    dataRow["CollaborationTitle"].ToString()));
            }

            databaseConnection.CloseConnection();
            return collaborations;
        }

        public List<Collaboration> GetCollaborationsForInfluencer()
        {
            List<Collaboration> collaborations = new List<Collaboration>();
            collaborations = databaseContext.Collaboration.Where(c => c.InfluencerId == User.User.GetInstance().Id).ToList();

            return collaborations;

            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();

            string query = "SELECT * FROM Collaboration WHERE InfluencerID = @InfluencerID";

            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);

            System.Diagnostics.Debug.WriteLine(User.User.GetInstance().Id);
            command.Parameters.AddWithValue("@InfluencerID", 1);

            // Set the SelectCommand property of the SqlDataAdapter
            adapter.SelectCommand(command);
            adapter.ExecuteNonQuery(command);

            // Remove unnecessary code that sets InsertCommand and calls ExecuteNonQuery
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                collaborations.Add(new Collaboration(Convert.ToInt32(dataRow["CollaborationID"]),
                Convert.ToDateTime(dataRow["StartDate"]), Convert.ToBoolean(dataRow["Status"]),
                dataRow["ContentRequirements"].ToString(), dataRow["AdOverview"].ToString(),
                dataRow["CollaborationFee"].ToString(), Convert.ToDateTime(dataRow["EndDate"]).Day - Convert.ToDateTime(dataRow["StartDate"]).Day,
                dataRow["CollaborationTitle"].ToString()));
            }

            databaseConnection.CloseConnection();
            return collaborations;
        }
    }
}

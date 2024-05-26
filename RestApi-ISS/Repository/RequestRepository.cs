using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using Iss.Database;
using Iss.Entity;

using Microsoft.Data.SqlClient;

namespace Iss.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private string influencerId;
        private List<Request> requests = new List<Request>();
        private DatabaseContext databaseContext = new DatabaseContext();

        public RequestRepository()
        {
            this.influencerId = GetInfluencerId();
        }

        public string GetInfluencerId()
        {
            Influencer requiredInfluencer = this.databaseContext.Influencer.Where(influencer => influencer.InfluencerName == "Selly").FirstOrDefault();

            return requiredInfluencer.InfluencerId;

            // DatabaseConnection databaseConnection = new DatabaseConnection();
            // SqlDataAdapter adapter = new SqlDataAdapter();
            // databaseConnection.OpenConnection();
            // string influencerQuery = "SELECT ID FROM Influencer WHERE Name='Selly'";
            // SqlCommand influencerCommand = new SqlCommand(influencerQuery, databaseConnection.SqlConnection);
            // int influencerId = Convert.ToInt32(influencerCommand.ExecuteScalar());
            // databaseConnection.CloseConnection();
            // return influencerId;
        }

        public void AddRequest(Request requestToAdd)
        {
            requestToAdd.InfluencerId = this.influencerId;
            requestToAdd.AdAccountId = User.User.GetInstance().Id;

            databaseContext.Request.Add(requestToAdd);
            databaseContext.SaveChanges();

            return;

            // Add the requestToAdd to the database
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();

            databaseConnection.OpenConnection();

            string influencerQuery = "SELECT ID FROM Influencer WHERE Name='Selly'";

            SqlCommand influencerCommand = new SqlCommand(influencerQuery, databaseConnection.SqlConnection);
            // Execute the query to get the influencer ID
            int influencerId = Convert.ToInt32(influencerCommand.ExecuteScalar());

            string query = "INSERT INTO Request(AdAccountID, InfluencerID, CollaborationTitle, AdOverview, ContentRequirements, CompensationPackage, InfluencerAccept, AdAccountAccept, StartDate, EndDate) VALUES (@AdAccountID, @InfluencerID, @collaborationTitle, @AdOverview, @contentRequirements, @compensation, @influencerAccept, @adAccountAccept, @startDate, @endDate)";

            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@AdAccountID", User.User.GetInstance().Id);
            command.Parameters.AddWithValue("@InfluencerID", influencerId);
            command.Parameters.AddWithValue("@collaborationTitle", requestToAdd.CollaborationTitle);
            command.Parameters.AddWithValue("@AdOverview", requestToAdd.AdOverview);
            command.Parameters.AddWithValue("@contentRequirements", requestToAdd.ContentRequirements);
            command.Parameters.AddWithValue("@compensation", requestToAdd.Compensation);
            command.Parameters.AddWithValue("@influencerAccept", requestToAdd.InfluencerAccept);
            command.Parameters.AddWithValue("@adAccountAccept", requestToAdd.AdAccountAccept);
            command.Parameters.AddWithValue("@startDate", requestToAdd.StartDate);
            command.Parameters.AddWithValue("@endDate", requestToAdd.EndDate);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public List<Request> GetRequestsForInfluencer()
        {
            this.requests = this.databaseContext.Request.Where(request => request.InfluencerId == this.influencerId && request.InfluencerAccept == false).ToList();
            return this.requests;

            DatabaseConnection databaseConnection = new DatabaseConnection();
            string query = "SELECT * FROM Request WHERE InfluencerID=@influencerId AND InfluencerAccept=@influenceraccept";

            try
            {
                using (SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection))
                {
                    command.Parameters.AddWithValue("@influencerId", this.influencerId);
                    command.Parameters.AddWithValue("@influenceraccept", 0);
                    databaseConnection.OpenConnection();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Request request = new Request(
                                    reader.GetString(reader.GetOrdinal("CollaborationTitle")),
                                    reader.GetString(reader.GetOrdinal("AdOverview")),
                                    reader.GetString(reader.GetOrdinal("ContentRequirements")),
                                    reader.GetString(reader.GetOrdinal("CompensationPackage")),
                                    reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                    reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                    reader.GetBoolean(reader.GetOrdinal("InfluencerAccept")),
                                    reader.GetBoolean(reader.GetOrdinal("AdAccountAccept")));
                                requests.Add(request);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                databaseConnection.CloseConnection();
            }

            return requests;
        }

        public void DeleteRequest(Request requestToDelete)
        {
            databaseContext.ChangeTracker.Clear();
            databaseContext.Request.Remove(requestToDelete);
            databaseContext.SaveChanges();

            return;

            // Delete the requestToAdd from the database
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            databaseConnection.OpenConnection();
            string query = "DELETE FROM Request WHERE CollaborationTitle=@collaborationTitle";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@collaborationTitle", requestToDelete.CollaborationTitle);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public List<Request> GetRequestsList()
        {
            return this.requests;
        }

        public List<Request> GetRequestsForAdAccount()
        {
            requests = this.databaseContext.Request.Where(request => request.AdAccountId == User.User.GetInstance().Id && request.AdAccountAccept == false).ToList();
            return requests;

            DatabaseConnection databaseConnection = new DatabaseConnection();
            string query = "SELECT * FROM Request WHERE AdAccountID=@adAccountId AND AdAccountAccept=@adAccountAccept";

            try
            {
                using (SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection))
                {
                    command.Parameters.AddWithValue("@adAccountId", User.User.GetInstance().Id);
                    command.Parameters.AddWithValue("@adAccountAccept", 0);
                    databaseConnection.OpenConnection();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Request request = new Request(
                                    reader.GetString(reader.GetOrdinal("CollaborationTitle")),
                                    reader.GetString(reader.GetOrdinal("AdOverview")),
                                    reader.GetString(reader.GetOrdinal("ContentRequirements")),
                                    reader.GetString(reader.GetOrdinal("CompensationPackage")),
                                    reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                    reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                    reader.GetBoolean(reader.GetOrdinal("InfluencerAccept")),
                                    reader.GetBoolean(reader.GetOrdinal("AdAccountAccept")));
                                requests.Add(request);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                databaseConnection.CloseConnection();
            }

            return requests;
        }

        public void UpdateRequest(Request requestToUpdate)
        {
            Request requiredRequest = this.databaseContext.Request.Where(request => request.CollaborationTitle == requestToUpdate.CollaborationTitle).FirstOrDefault();
            requiredRequest.Compensation = requestToUpdate.Compensation;
            requiredRequest.ContentRequirements = requestToUpdate.ContentRequirements;
            requiredRequest.InfluencerAccept = requestToUpdate.InfluencerAccept;
            requiredRequest.AdAccountAccept = requestToUpdate.AdAccountAccept;

            this.databaseContext.Update(requiredRequest);
            this.databaseContext.SaveChanges();

            return;

            // update only compensation, content requirements and acceptance status
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            databaseConnection.OpenConnection();
            // update the requestToAdd in the database with the new compensation, content requirements and acceptance status
            string query = "UPDATE Request SET CompensationPackage=@compensation, ContentRequirements=@contentRequirements, InfluencerAccept=@influencerAccept, AdAccountAccept=@adAccountAccept WHERE CollaborationTitle=@collaborationTitle";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@compensation", requestToUpdate.Compensation);
            command.Parameters.AddWithValue("@contentRequirements", requestToUpdate.ContentRequirements);
            command.Parameters.AddWithValue("@influencerAccept", requestToUpdate.InfluencerAccept);
            command.Parameters.AddWithValue("@adAccountAccept", requestToUpdate.AdAccountAccept);
            command.Parameters.AddWithValue("@collaborationTitle", requestToUpdate.CollaborationTitle);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }
    }
}

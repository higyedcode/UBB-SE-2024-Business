using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Database;
using Iss.Entity;
using Microsoft.EntityFrameworkCore;

using Microsoft.Data.SqlClient;

namespace Iss.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private DatabaseContext databaseContext = new DatabaseContext();

        public void AddCampaign(Campaign campaignToAdd)
        {
            campaignToAdd.AdAccountId = User.User.GetInstance().Id;

            foreach (var adSet in campaignToAdd.AdSets)
            {
                databaseContext.Entry(adSet).State = EntityState.Modified;
            }

            databaseContext.Campaign.Add(campaignToAdd);
            databaseContext.SaveChanges();
        }

        public Campaign GetCampaignByName(Campaign campaignToGetByName)
        {
            return databaseContext.Campaign.Where(c => c.CampaignName == campaignToGetByName.CampaignName).FirstOrDefault();

            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM Campaign WHERE Name = @campaignName";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@campaignName", campaignToGetByName.CampaignName);
            dataAdapter.SelectCommand = command;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                string id = dataRow["ID"].ToString();
                campaignToGetByName.CampaignId = id;
            }

            databaseConnection.CloseConnection();
            return campaignToGetByName;
        }

        public void AddAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet)
        {
            AdSet requiredAdSet = databaseContext.AdSet.Where(a => a.AdSetId == adSet.AdSetId).FirstOrDefault();
            requiredAdSet.CampaignId = campaignToAddAdSet.CampaignId;

            databaseContext.ChangeTracker.Clear();

            databaseContext.AdSet.Update(requiredAdSet);
            databaseContext.SaveChanges();

            // databaseConnection.OpenConnection();
            // string query = "UPDATE AdSet SET CampaignID = @campaignID WHERE ID = @adSetID";
            // SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            // command.Parameters.AddWithValue("@campaignID", campaignToAddAdSet.CampaignId);
            // command.Parameters.AddWithValue("@adSetID", adSet.AdSetId);
            // dataAdapter.UpdateCommand = command;
            // dataAdapter.UpdateCommand.ExecuteNonQuery();
            // databaseConnection.CloseConnection();
        }

        public void DeleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet)
        {
            AdSet requiredAdSet = databaseContext.AdSet.Where(a => a.AdSetId == adSet.AdSetId).FirstOrDefault();
            requiredAdSet.CampaignId = null;

            databaseContext.ChangeTracker.Clear();

            databaseContext.AdSet.Update(requiredAdSet);
            databaseContext.SaveChanges();

            // databaseConnection.OpenConnection();
            // string query = "UPDATE AdSet SET CampaignID = NULL WHERE ID = @adSetID";
            // SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            // command.Parameters.AddWithValue("@campaignID", campaignToDeleteAdSet.CampaignId);
            // command.Parameters.AddWithValue("@adSetID", adSet.AdSetId);
            // dataAdapter.UpdateCommand = command;
            // dataAdapter.UpdateCommand.ExecuteNonQuery();
            // databaseConnection.CloseConnection();
        }

        public void DeleteCampaign(Campaign campaignToDelete)
        {
            campaignToDelete = this.GetCampaignByName(campaignToDelete);
            databaseContext.ChangeTracker.Clear();

            databaseContext.Campaign.Remove(campaignToDelete);
            databaseContext.SaveChanges();
            // databaseConnection.OpenConnection();
            // string query = "DELETE FROM Campaign WHERE ID = @adAccountId";
            // SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            // command.Parameters.AddWithValue("@adAccountId", campaignToDelete.CampaignId);
            // dataAdapter.DeleteCommand = command;
            // dataAdapter.DeleteCommand.ExecuteNonQuery();
            // databaseConnection.CloseConnection();
        }

        public void UpdateCampaign(Campaign campaignToUpdate)
        {
            Campaign requiredCampain = databaseContext.Campaign.Where(c => c.CampaignId == campaignToUpdate.CampaignId).FirstOrDefault();
            requiredCampain.CampaignName = campaignToUpdate.CampaignName;
            requiredCampain.StartDate = campaignToUpdate.StartDate;
            requiredCampain.Duration = campaignToUpdate.Duration;

            databaseContext.ChangeTracker.Clear();

            databaseContext.Campaign.Update(requiredCampain);
            databaseContext.SaveChanges();

            // databaseConnection.OpenConnection();
            // string query = "UPDATE Campaign SET Name=@name, StartDate=@date, Duration=@duration WHERE ID = @adAccountId";
            // SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            // command.Parameters.AddWithValue("@adAccountId", campaignToUpdate.CampaignId);
            // command.Parameters.AddWithValue("@name", campaignToUpdate.CampaignName);
            // command.Parameters.AddWithValue("@date", campaignToUpdate.StartDate);
            // command.Parameters.AddWithValue("@duration", campaignToUpdate.Duration);
            // dataAdapter.UpdateCommand = command;
            // dataAdapter.UpdateCommand.ExecuteNonQuery();
            // databaseConnection.CloseConnection();
        }
    }
}

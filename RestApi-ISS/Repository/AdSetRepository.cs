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
    public class AdSetRepository : IAdSetRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private DatabaseContext databaseContext = new DatabaseContext();

        public void AddAdSet(AdSet adSet)
        {
            adSet.AdAccountId = User.User.GetInstance().Id;

            foreach (var ad in adSet.Ads)
            {
                databaseContext.Entry(ad).State = EntityState.Modified;
            }

            databaseContext.AdSet.Add(adSet);
            databaseContext.SaveChanges();
        }

        public void DeleteAdSet(AdSet adSet)
        {
            databaseContext.ChangeTracker.Clear();

            databaseContext.AdSet.Remove(adSet);
            databaseContext.SaveChanges();
        }

        public void UpdateAdSet(AdSet adSet)
        {
            databaseContext.ChangeTracker.Clear();

            adSet.AdAccountId = User.User.GetInstance().Id;
            databaseContext.AdSet.Update(adSet);
            databaseContext.SaveChanges();
        }

        public AdSet GetAdSetByName(AdSet adSet)
        {
            AdSet requiredAdSet = databaseContext.AdSet.Where(a => a.Name == adSet.Name).FirstOrDefault();

            return requiredAdSet;
        }

        public void AddAdToAdSet(AdSet adSet, Ad ad)
        {
            ad.AdSetId = adSet.AdSetId;

            databaseContext.ChangeTracker.Clear();

            databaseContext.Ad.Update(ad);
            databaseContext.SaveChanges();

            // databaseConnection.OpenConnection();
            // string query = "UPDATE Ad SET AdSetID = @adSetID WHERE ID = @adID";
            // SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            // command.Parameters.AddWithValue("@adSetID", adSet.AdSetId);
            // command.Parameters.AddWithValue("@adID", ad.AdId);
            // dataAdapter.UpdateCommand = command;
            // dataAdapter.UpdateCommand.ExecuteNonQuery();
            // databaseConnection.CloseConnection();
        }

        public void RemoveAdFromAdSet(AdSet adSet, Ad ad)
        {
            ad.AdSetId = null;

            databaseContext.ChangeTracker.Clear();

            databaseContext.Ad.Update(ad);
            databaseContext.SaveChanges();

            // databaseConnection.OpenConnection();
            // string query = "UPDATE Ad SET AdSetID = NULL WHERE ID = @adID";
            // SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            // command.Parameters.AddWithValue("@adSetID", adSet.AdSetId);
            // command.Parameters.AddWithValue("@adID", ad.AdId);
            // dataAdapter.UpdateCommand = command;
            // dataAdapter.UpdateCommand.ExecuteNonQuery();
            // databaseConnection.CloseConnection();
        }

        public List<AdSet> GetAdSetsThatAreNotInCampaign()
        {
            List<AdSet> adSets = new List<AdSet>();

            adSets = databaseContext.AdSet.Where(a => a.CampaignId == null && a.AdAccountId == User.User.GetInstance().Id).ToList();

            // DataSet dataSet = new DataSet();
            // databaseConnection.OpenConnection();
            // string query = "SELECT * FROM AdSet WHERE CampaignID IS NULL AND AdAccountID=@id";
            // SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            // command.Parameters.AddWithValue("@id", User.User.GetInstance().Id);
            // dataAdapter.SelectCommand = command;
            // dataAdapter.SelectCommand.ExecuteNonQuery();
            // dataAdapter.Fill(dataSet);
            // foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            // {
            //     string id = dataRow["ID"].ToString();
            //     string name = dataRow["Name"].ToString();
            //     string targetAudience = dataRow["TargetAudience"].ToString();
            //     AdSet adSet = new AdSet(id, name, targetAudience);
            //     adSets.Add(adSet);
            // }
            // databaseConnection.CloseConnection();
            return adSets;
        }

        public List<AdSet> GetAdSetsInCampaign(string id)
        {
            List<AdSet> adSets = new List<AdSet>();

            adSets = databaseContext.AdSet.Where(a => a.CampaignId == id).ToList();

            // DataSet dataSet = new DataSet();
            // databaseConnection.OpenConnection();
            // string query = "SELECT * FROM AdSet WHERE CampaignID=@id";
            // SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            // command.Parameters.AddWithValue("@id", id);
            // dataAdapter.SelectCommand = command;
            // dataAdapter.SelectCommand.ExecuteNonQuery();
            // dataAdapter.Fill(dataSet);
            // foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            // {
            //     string adSetId = dataRow["ID"].ToString();
            //     string name = dataRow["Name"].ToString();
            //     string targetAudience = dataRow["TargetAudience"].ToString();
            //     AdSet adSet = new AdSet(adSetId, name, targetAudience);
            //     adSets.Add(adSet);
            // }
            // databaseConnection.CloseConnection();
            return adSets;
        }
    }
}

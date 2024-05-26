using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Database;
using Iss.Entity;
using Iss.Repository;

using Microsoft.Data.SqlClient;

namespace Iss.Repository
{
    /// <summary>
    /// Represents a repository for managing influencers in a database.
    /// </summary>
    public class InfluencerRepository : IInfluencerRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter databaseDataAdapter = new SqlDataAdapter();
        private DatabaseContext databaseContext = new DatabaseContext();

        /// <summary>
        /// Retrieves a list of influencers from the database.
        /// </summary>
        /// <returns>A list of <see cref="Influencer"/> objects representing influencers.</returns>
        public List<Influencer> GetInfluencers()
        {
            List<Influencer> influencers = new List<Influencer>();

            influencers = this.databaseContext.Influencer.ToList();

            return influencers;

            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM Influencer";
            SqlCommand command = new SqlCommand(query, this.databaseConnection.SqlConnection);
            this.databaseConnection.OpenConnection();
            this.databaseDataAdapter.SelectCommand = command;
            this.databaseDataAdapter.SelectCommand.ExecuteNonQuery();
            this.databaseDataAdapter.Fill(dataSet);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string id = row["ID"].ToString();
                string name = row["Name"].ToString();
                int followers = Convert.ToInt32(row["FollowerCount"]);
                int price = Convert.ToInt32(row["CollaborationPrice"]);
                Influencer influencer = new Influencer(id, name, followers, price);
                influencers.Add(influencer);
            }

            return influencers;
        }
    }
}

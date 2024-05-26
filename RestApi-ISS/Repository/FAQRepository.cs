// <copyright file="FAQRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Models;
using Iss.Repository;
using Microsoft.Data.SqlClient;
using Iss.Database;
using RestApi_ISS.Entity;
using RestApi_ISS.Repository;

namespace RestApi_ISS.Repository
{
    public class FAQRepository : IFAQRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private readonly SqlDataAdapter adapter = new SqlDataAdapter();
        private DatabaseContext databaseContext = new DatabaseContext();

        public List<FAQ> GetFAQList()
        {
            return this.databaseContext.FAQ.ToList();
        }

        public void AddFAQ(FAQ newQuestion)
        {
            databaseContext.FAQ.Add(newQuestion);
            databaseContext.SaveChanges();
        }

        public void DeleteFAQ(FAQ updatedQuestion)
        {
            var questionToDelete = databaseContext.FAQ.Find(updatedQuestion.Id);
            if (questionToDelete != null)
            {
                databaseContext.FAQ.Remove(questionToDelete);
                databaseContext.SaveChanges();
            }
        }
    }
}

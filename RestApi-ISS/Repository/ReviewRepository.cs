namespace Backend.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Xml;
    using System.Xml.Serialization;
    using Backend.Models;
    using Iss.Database;
    using Iss.Entity;
    using Iss.Repository;
    using Iss.User;
    using Microsoft.Data.SqlClient;
    using RestApi_ISS.Controllers;

    public class ReviewRepository : INterfaceReview<ReviewClass>
    {
        // private readonly string xmlFilePath;
        private List<ReviewClass> reviewList;
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DatabaseContext databaseContext = new DatabaseContext();

        public ReviewRepository()
        {
            this.reviewList = new List<ReviewClass>();
            /*string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;

            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath[..index];
            string pathToReviewsXML = $"\\XMLFiles\\REVIEWitems.xml";
            this.xmlFilePath = pathUntilBin + pathToReviewsXML;
            this.LoadFromXml();*/
        }

        public List<ReviewClass> GetReviewList()
        {
            return this.reviewList;
        }

        public void AddReview(ReviewClass newR)
        {
            databaseContext.Review.Add(newR);
            databaseContext.SaveChanges();
            /*this.reviewList.Add(newR);
            this.SaveToXml();*/
        }

        public void DeleteReview(ReviewClass reviewToDelete)
        {
            databaseContext.ChangeTracker.Clear();

            databaseContext.Review.Remove(reviewToDelete);
            databaseContext.SaveChanges();
        }

        public void UpdateReview(ReviewClass reviewToUpdate)
        {
            databaseContext.ChangeTracker.Clear();

            reviewToUpdate.User = User.GetInstance().Name;
            databaseContext.Update(reviewToUpdate);
            databaseContext.SaveChanges();
        }

        public ReviewClass GetReviewByName(string adName)
        {
            ReviewClass ad = databaseContext.Review.Where(a => a.User == adName).FirstOrDefault();

            return ad;
        }
        /*private void LoadFromXml()
        {
            try
            {
                if (File.Exists(this.xmlFilePath))
                {
                    XmlSerializer serializer = new(typeof(ReviewClass), new XmlRootAttribute("ReviewClass"));

                    this.reviewList = new List<ReviewClass>();
                    using FileStream fileStream = new(this.xmlFilePath, FileMode.Open);
                    using XmlReader reader = XmlReader.Create(fileStream);
                    while (reader.ReadToFollowing("ReviewClass"))
                    {
                        ReviewClass review = (ReviewClass)serializer.Deserialize(reader);
                        this.reviewList.Add(review);
                    }
                }
                else
                {
                    this.reviewList = new List<ReviewClass>();
                }
            }
            catch
            {
            }
        }*/

        /*private void SaveToXml()
        {
            XmlSerializer serializer = new(typeof(List<ReviewClass>), new XmlRootAttribute("Reviews"));

            using FileStream fileStream = new(this.xmlFilePath, FileMode.Create);
            serializer.Serialize(fileStream, this.reviewList);
        }*/
    }
}

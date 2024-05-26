using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Iss.User;

using Xunit;
using Iss.Database;
using Iss.Entity;
using Iss.Repository;
using Moq;

namespace Iss.Tests.Repository
{
    /*
    public class CollaborationRepositoryTests
    {

     [Fact]
        public void CreateCollaboration_WhenCalled_InsertsCollaborationIntoDatabase()
        {
            // Arrange
            var mockDatabaseConnection = new Mock<IDatabaseConnection>();
            var mockDataAdapterWrapper = new Mock<ISqlDataAdapterWrapper>();
            var collaborationRepository = new CollaborationRepository(mockDatabaseConnection.Object, mockDataAdapterWrapper.Object);

            var collaboration = new Collaboration(
            CollaborationId: 1,
            startDate: DateTime.Now,
            status: true,
            contentRequirement: "Content requirement",
            adOverview: "Ad overview",
            collaborationFee: "100",
            days: 7,
            collaborationTitle: "Collaboration Title"
        );
            var fakeSqlConnection = new SqlConnection("Data Source = DESKTOP-R01UH5Q\\SQLEXPRESS; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;");
            fakeSqlConnection.Open();

            mockDatabaseConnection.Setup(x => x.OpenConnection());
            mockDatabaseConnection.SetupGet(x => x.sqlConnection).Returns(fakeSqlConnection);
            mockDataAdapterWrapper.Setup(x => x.InsertCommand(It.IsAny<SqlCommand>()));
            mockDataAdapterWrapper.Setup(x => x.ExecuteNonQuery(It.IsAny<SqlCommand>()));
            mockDatabaseConnection.Setup(x => x.sqlConnection.CreateCommand()).Returns(() =>
            {
                var sqlCommandMock = new Mock<SqlCommand>();
                var sqlCommand = sqlCommandMock.Object;

                // Set up behavior for opening the connection when the command is executed
                sqlCommandMock.SetupGet(c => c.Connection).Returns(mockDatabaseConnection.Object.sqlConnection);
                sqlCommandMock.Setup(c => c.ExecuteNonQuery()).Callback(() =>
                {
                    // Open the connection when ExecuteNonQuery is called
                    mockDatabaseConnection.Object.OpenConnection();
                });

                return sqlCommand;
            });

            // Act
            collaborationRepository.createCollaboration(collaboration);

            // Assert
            mockDatabaseConnection.Verify(x => x.OpenConnection(), Times.Once);
            mockDataAdapterWrapper.Verify(x => x.InsertCommand(It.IsAny<SqlCommand>()), Times.Once);
            mockDataAdapterWrapper.Setup(x => x.ExecuteNonQuery(It.IsAny<SqlCommand>()));
            mockDatabaseConnection.Verify(x => x.CloseConnection(), Times.Once);
        }

        [Fact]
        public void GetCollaborationsForAdAccount_WhenCalled_ReturnsListOfCollaborations()
        {
            // Arrange
            // Arrange
            var mockDatabaseConnection = new Mock<IDatabaseConnection>();
            var mockDataAdapterWrapper = new Mock<ISqlDataAdapterWrapper>();
            var collaborationRepository = new CollaborationRepository(mockDatabaseConnection.Object, mockDataAdapterWrapper.Object);


            var dataSet = new DataSet();
            var dataTable = new DataTable();
            dataTable.Columns.Add("CollaborationID", typeof(int));
            dataSet.Tables.Add(dataTable);

            // Set up expectations for mocked objects
            mockDatabaseConnection.Setup(x => x.OpenConnection());
            mockDatabaseConnection.SetupGet(x => x.sqlConnection).Returns(new SqlConnection());
            mockDataAdapterWrapper.Setup(x => x.SelectCommand(It.IsAny<SqlCommand>()));
            mockDataAdapterWrapper.Setup(x => x.Fill(dataSet));


            // Act
            var result = collaborationRepository.GetCollaborationsForAdAccount();

            // Assert
            mockDatabaseConnection.Verify(x => x.OpenConnection(), Times.Once);
            mockDataAdapterWrapper.Verify(x => x.SelectCommand(It.IsAny<SqlCommand>()), Times.Once);
            mockDataAdapterWrapper.Verify(x => x.Fill(dataSet), Times.Once);
            Assert.NotNull(result);
            Assert.IsType<List<Collaboration>>(result);
            // Add more assertions as needed
        }




    }
    */

    public class CollaborationRepositoryTests
    {
        [Fact]
        public void CreateCollaboration_InsertsCollaborationIntoDatabase()
        {
            // Arrange
            var repository = new CollaborationRepository(new DatabaseConnection(), new SqlDataAdapterWrapper());

            var collaboration = new Collaboration(
           collaborationId: 1,
           startDate: DateTime.Now,
           status: true,
           contentRequirement: "Content requirement",
           adOverview: "Ad overview",
           collaborationFee: "100",
           days: 7,
           collaborationTitle: "Collaboration Title");

            // Act
            repository.CreateCollaboration(collaboration);

            // Assert
            // Add assertions to verify that the collaboration was inserted into the database
            // You can query the database to check if the collaboration exists
            var collaborations = repository.GetCollaborationsForAdAccount();
            var createdCollaboration = collaborations.FirstOrDefault(c => c.CollaborationId == collaboration.CollaborationId);
            Assert.NotNull(createdCollaboration); // Assert that the collaboration was inserted
        }

        [Fact]
        public void GetCollaborationsForAdAccount_ReturnsListOfCollaborations()
        {
            // Arrange
            var repository = new CollaborationRepository(new DatabaseConnection(), new SqlDataAdapterWrapper());

            // Act
            var collaborations = repository.GetCollaborationsForAdAccount();

            // Assert
            // Add assertions to verify the returned list of collaborations
            Assert.NotNull(collaborations);
        }

        [Fact]
        public void GetCollaborationsForInfluencer_ReturnsListOfCollaborations()
        {
            // Arrange
            var repository = new CollaborationRepository(new DatabaseConnection(), new SqlDataAdapterWrapper());

            // Act
            var collaborations = repository.GetCollaborationsForInfluencer();

            // Assert
            // Add assertions to verify the returned list of collaborations
            Assert.NotNull(collaborations);
        }
    }
}

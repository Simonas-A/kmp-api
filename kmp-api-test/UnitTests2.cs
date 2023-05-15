using kmp_api;
using kmp_api.Connections;
using kmp_api.Controllers;
using Microsoft.Data.SqlClient;
using Moq;
using System.Data;
using System.Data.Common;

namespace kmp_api_test
{
    public class TestsExceptions
    {
        [SetUp]
        public void Setup()
        {
            exception = MakeSqlException();
        }

        private SqlException exception;

        private SqlException MakeSqlException()
        {
            SqlException exception = null;
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=.;Database=GUARANTEED_TO_FAIL;Connection Timeout=1");
                conn.Open();
            }
            catch (SqlException ex)
            {
                exception = ex;
            }
            return (exception);
        }

        [Test]
        public void GetCarsReturnsCarListException()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            readerMock.Setup(reader => reader.GetGuid(0)).Throws(exception);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listings = db.GetCars();

            Assert.AreEqual(listings, null);
        }

        [Test]
        public void GetListingsException()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            readerMock.Setup(reader => reader.GetGuid(0)).Throws(exception);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listings = db.GetListings();

            Assert.AreEqual(new List<Listing>(), listings);
        }

        [Test]
        public void GetCarListingsException()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            
            readerMock.Setup(reader => reader.GetGuid(0)).Throws(exception);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listings = db.GetCarListings();

            Assert.AreEqual(new List<CarListing>(), listings);
        }

        [Test]
        public void AddListingException()
        {
            var readerMock = new Mock<IDataReader>();

            Guid id = Guid.NewGuid();

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteNonQuery()).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Throws(exception);


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var guid = db.AddListing(10, Guid.NewGuid());

            Assert.AreEqual(Guid.Empty, guid);
        }

        [Test]
        public void AddCarException()
        {
            var readerMock = new Mock<IDataReader>();

            Guid id = Guid.NewGuid();

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteNonQuery()).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Throws(exception);


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var guid = db.AddCar(10, 15, "Brand", "Model", 20, "Owner", "Phone");

            Assert.AreEqual(Guid.Empty, guid);
        }

        [Test]
        public void AddCarAsCarObjectException()
        {
            var readerMock = new Mock<IDataReader>();

            Guid id = Guid.NewGuid();

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteNonQuery()).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Throws(exception);


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var guid = db.AddCar(new Car(Guid.NewGuid(), "Brand", "Model", 10, 15, 20, "Owner", "Phone", new string[] { }));

            Assert.AreEqual(Guid.Empty, guid);
        }

        [Test]
        public void GetCarException()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            readerMock.Setup(reader => reader.GetGuid(0)).Throws(exception);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listings = db.GetCar(Guid.NewGuid());

            Assert.AreEqual(null, listings);
        }

        [Test]
        public void GetListingException()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            
            readerMock.Setup(reader => reader.GetGuid(0)).Throws(exception);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listing = db.GetListing(Guid.NewGuid());

            Assert.AreEqual(null, listing);
        }

        [Test]
        public void GetCarListingException()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            readerMock.Setup(reader => reader.GetGuid(0)).Throws(exception);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listing = db.GetCarListing(Guid.NewGuid());

            Assert.AreEqual(null, listing);
        }

        [Test]
        public void DeleteCarException()
        {
            var readerMock = new Mock<IDataReader>();

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteNonQuery()).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(m => m.Open()).Throws(exception);

            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            db.DeleteCar(Guid.NewGuid());
        }
    }
}
using kmp_api;
using kmp_api.Connections;
using kmp_api.Controllers;
using Microsoft.Data.SqlClient;
using Moq;
using System.Data;

namespace kmp_api_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCarsReturnsCarList()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            readerMock.Setup(reader => reader.GetGuid(0)).Returns(id);
            readerMock.Setup(reader => reader.GetString(1)).Returns("Brand");
            readerMock.Setup(reader => reader.GetString(2)).Returns("Model");
            readerMock.Setup(reader => reader.GetInt32(3)).Returns(10);
            readerMock.Setup(reader => reader.GetInt32(4)).Returns(15);
            readerMock.Setup(reader => reader.IsDBNull(5)).Returns(false);
            readerMock.Setup(reader => reader.IsDBNull(6)).Returns(false);
            readerMock.Setup(reader => reader.IsDBNull(7)).Returns(false);
            readerMock.Setup(reader => reader.GetDecimal(5)).Returns(10.5m);
            readerMock.Setup(reader => reader.GetString(6)).Returns("Owner");
            readerMock.Setup(reader => reader.GetString(7)).Returns("Phone");
            readerMock.Setup(reader => reader.GetString(8)).Returns("ImageLink");

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listings = db.GetCars();

            Assert.NotNull(listings);
            Assert.AreEqual(1, listings.Count());
            Assert.AreEqual(listings.First().Id, id);
            Assert.AreEqual(listings.First().Brand, "Brand");
            Assert.AreEqual(listings.First().Model, "Model");
            Assert.AreEqual(listings.First().Year, 10);
            Assert.AreEqual(listings.First().Mileage, 15);
            Assert.AreEqual(listings.First().Price, 10.5m);
            Assert.AreEqual(listings.First().Owner, "Owner");
            Assert.AreEqual(listings.First().PhoneNumber, "Phone");
            Assert.AreEqual(listings.First().Images[0], "ImageLink");
        }

        [Test]
        public void GetListings()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            readerMock.Setup(reader => reader.GetGuid(0)).Returns(id);
            readerMock.Setup(reader => reader.GetGuid(1)).Returns(id2);
            readerMock.Setup(reader => reader.GetDecimal(2)).Returns(10.5m);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listings = db.GetListings();

            Assert.NotNull(listings);
            Assert.AreEqual(1, listings.Count());
            Assert.AreEqual(listings.First().Id, id);
            Assert.AreEqual(listings.First().CarId, id2);
            Assert.AreEqual(listings.First().Price, 10.5m);
        }

        [Test]
        public void GetCarListings()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            
            readerMock.Setup(reader => reader.GetGuid(0)).Returns(id);
            readerMock.Setup(reader => reader.GetGuid(1)).Returns(id2);
            readerMock.Setup(reader => reader.GetString(2)).Returns("Brand");
            readerMock.Setup(reader => reader.GetString(3)).Returns("Model");
            readerMock.Setup(reader => reader.GetInt32(4)).Returns(15);
            readerMock.Setup(reader => reader.GetInt32(5)).Returns(20);
            readerMock.Setup(reader => reader.GetDecimal(6)).Returns(10.5m);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listings = db.GetCarListings();

            Assert.NotNull(listings);
            Assert.AreEqual(1, listings.Count());
            Assert.AreEqual(listings.First().Id, id);
            Assert.AreEqual(listings.First().CarId, id2);
            Assert.AreEqual(listings.First().Brand, "Brand");
            Assert.AreEqual(listings.First().Model, "Model");
            Assert.AreEqual(listings.First().Year, 15);
            Assert.AreEqual(listings.First().Mileage, 20);
            Assert.AreEqual(listings.First().Price, 10.5m);
        }

        [Test]
        public void AddListing()
        {
            var readerMock = new Mock<IDataReader>();

            Guid id = Guid.NewGuid();

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteNonQuery()).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var guid = db.AddListing(10, Guid.NewGuid());

            Assert.NotNull(guid);
        }

        [Test]
        public void AddCar()
        {
            var readerMock = new Mock<IDataReader>();

            Guid id = Guid.NewGuid();

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteNonQuery()).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var guid = db.AddCar(10, 15, "Brand", "Model", 20, "Owner", "Phone");

            Assert.NotNull(guid);
        }

        [Test]
        public void AddCarAsCarObject()
        {
            var readerMock = new Mock<IDataReader>();

            Guid id = Guid.NewGuid();

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteNonQuery()).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var guid = db.AddCar(new Car(Guid.NewGuid(), "Brand", "Model", 10, 15, 20, "Owner", "Phone", new string[] { }));

            Assert.NotNull(guid);
        }

        [Test]
        public void GetCar()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            readerMock.Setup(reader => reader.GetGuid(0)).Returns(id);
            readerMock.Setup(reader => reader.GetString(1)).Returns("Brand");
            readerMock.Setup(reader => reader.GetString(2)).Returns("Model");
            readerMock.Setup(reader => reader.GetInt32(3)).Returns(10);
            readerMock.Setup(reader => reader.GetInt32(4)).Returns(15);
            readerMock.Setup(reader => reader.IsDBNull(5)).Returns(false);
            readerMock.Setup(reader => reader.IsDBNull(6)).Returns(false);
            readerMock.Setup(reader => reader.IsDBNull(7)).Returns(false);
            readerMock.Setup(reader => reader.GetDecimal(5)).Returns(10.5m);
            readerMock.Setup(reader => reader.GetString(6)).Returns("Owner");
            readerMock.Setup(reader => reader.GetString(7)).Returns("Phone");

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listings = db.GetCar(Guid.NewGuid());

            Assert.NotNull(listings);
            Assert.AreEqual(listings.Id, id);
            Assert.AreEqual(listings.Brand, "Brand");
            Assert.AreEqual(listings.Model, "Model");
            Assert.AreEqual(listings.Year, 10);
            Assert.AreEqual(listings.Mileage, 15);
            Assert.AreEqual(listings.Price, 10.5m);
            Assert.AreEqual(listings.Owner, "Owner");
            Assert.AreEqual(listings.PhoneNumber, "Phone");
            Assert.AreEqual(listings.Images, new string[] { });
        }

        [Test]
        public void GetListing()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            
            readerMock.Setup(reader => reader.GetGuid(0)).Returns(id);
            readerMock.Setup(reader => reader.GetGuid(1)).Returns(id2);
            readerMock.Setup(reader => reader.GetDecimal(2)).Returns(10.5m);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listing = db.GetListing(Guid.NewGuid());

            Assert.NotNull(listing);
            Assert.AreEqual(listing.Id, id);
            Assert.AreEqual(listing.CarId, id2);
            Assert.AreEqual(listing.Price, 10.5m);
        }

        [Test]
        public void GetCarListing()
        {
            var readerMock = new Mock<IDataReader>();

            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            readerMock.Setup(reader => reader.GetGuid(0)).Returns(id);
            readerMock.Setup(reader => reader.GetGuid(1)).Returns(id2);
            readerMock.Setup(reader => reader.GetString(2)).Returns("Brand");
            readerMock.Setup(reader => reader.GetString(3)).Returns("Model");
            readerMock.Setup(reader => reader.GetInt32(4)).Returns(15);
            readerMock.Setup(reader => reader.GetInt32(5)).Returns(20);
            readerMock.Setup(reader => reader.GetDecimal(6)).Returns(10.5m);

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            //connectionMock.Setup(q => new SqlConnection(It.IsAny<string>())).Returns(connectionMock.Object);
            connectionMock.Setup(m => m.Open()).Verifiable();


            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            var listing = db.GetCarListing(Guid.NewGuid());

            Assert.NotNull(listing);
            Assert.AreEqual(listing.Id, id);
            Assert.AreEqual(listing.CarId, id2);
            Assert.AreEqual(listing.Brand, "Brand");
            Assert.AreEqual(listing.Model, "Model");
            Assert.AreEqual(listing.Year, 15);
            Assert.AreEqual(listing.Mileage, 20);
            Assert.AreEqual(listing.Price, 10.5m);
        }

        [Test]
        public void DeleteCar()
        {
            var readerMock = new Mock<IDataReader>();

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteNonQuery()).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(m => m.Open()).Verifiable();

            DatabaseConnect db = new DatabaseConnect(null, commandMock.Object, connectionMock.Object);
            db.DeleteCar(Guid.NewGuid());
            Assert.AreEqual(commandMock.Invocations.Count, 2);
        }
    }
}
namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
        }

        [Test]
        public void CountShouldWorkProperlyWhenAdd()
        {
            db.Add(new Person(123, "Dari"));
            db.Add(new Person(456, "Mimi"));

            Assert.AreEqual(2, db.Count);
        }

        [Test]
        public void CountShouldWorkProperlyWhenRemove()
        {
            db.Add(new Person(123, "Dari"));
            db.Add(new Person(456, "Mimi"));
            db.Remove();

            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void RemoveUserFromEmptyDatabaseShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void AddUserToFullDatabaseShouldThrowException()
        {
            string user = "user";

            for (int i = 1; i <= 16; i++)
            {
                db.Add(new Person(i, user + i));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(17, "user17"));
            });
        }

        [Test]
        public void DatabaseParamsMoreThan16ShouldThrowException()
        {
            Person[] persons = new Person[17];

            Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(persons);

            }, "Provided data length should be in range [0..16]!");

        }

        [Test]
        public void DatabaseZeroParamsShouldBeValid()
        {
            Person[] persons = new Person[0];

            Database database = new Database(persons);

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void AddUserIfSameUsernameExistShouldThrowException()
        {
            db.Add(new Person(123456789, "user123"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(987654321, "user123"));
            }, "There is already user with this username!");
        }

        [Test]
        public void AddUserIfSameIdExistShouldThrowException()
        {
            db.Add(new Person(123456789, "user123"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(123456789, "user321"));
            }, "There is already user with this Id!");
        }

        [Test]
        public void RemoveUserIfIsNullShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void FindByUsernameIfThereIsNoUserWithThisUsernameShouldThrowException()
        {
            db.Add(new Person(123456789, "user123"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("user");
            }, "No user is present by this username!");
        }

        [Test]
        public void FindByUsernameShouldReturnCorrectPerson()
        {
            db.Add(new Person(123, "Koko"));
            db.Add(new Person(456, "Maya"));

            var user = db.FindByUsername("Koko");

            Assert.AreEqual(123, user.Id);
            Assert.AreEqual("Koko", user.UserName);
        }

        [Test]
        public void FindByIdShouldReturnCorrectPerson()
        {
            db.Add(new Person(123, "Koko"));
            db.Add(new Person(456, "Maya"));

            var user = db.FindById(123);

            Assert.AreEqual(123, user.Id);
            Assert.AreEqual("Koko", user.UserName);
        }

        [Test]
        public void FindByUsernameIfTheUsernameParamIsNullShouldThrowException()
        {
            db.Add(new Person(123456789, "user123"));

            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername("");
            }, "Username parameter is null!");
        }

        [Test]
        public void FindByUsernameCaseSensitiveShouldThrowException()
        {
            db.Add(new Person(123456789, "User123"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("user123");
            });
        }

        [Test]
        public void FindByIdIfThereIsNoUserWithSameIdShouldThrowException()
        {
            db.Add(new Person(123456789, "user123"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(123);
            }, "No user is present by this ID!");
        }

        [Test]
        public void FindByIdIfTheIdParamIsNegativeShouldThrowException()
        {
            db.Add(new Person(123456789, "user123"));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-123);
            }, "Id should be a positive number!");
        }
    }
}
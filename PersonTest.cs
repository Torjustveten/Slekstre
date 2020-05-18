using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using Slekstre;

namespace UnitTesting
{
    public class Tests
    {
        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann [17] Født: 2000 Død: 3000 Far: Per [23] Mor: Lise [29]";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestNoFields()
        {

            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "[1]";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void MyTest()
        {
            var p = new Person
            {
                Id = 14,
                FirstName = "Johnny",
                LastName = "Bravo",
                BirthYear = 1997,
                Mother = new Person() {Id = 15, FirstName = "Bunny"}
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Johnny Bravo [14] Født: 1997 Mor: Bunny [15]";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}
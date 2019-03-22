using DigitizedApi.Models;
using System;
using Xunit;

namespace DigitizedApiTest.Models {
    public class VisitorTest {
        private readonly string name = "Mout Pessemier";
        private readonly string email = "moutpessemier@hotmail.com";
        private readonly string phone = "+32479114479";
        private readonly string country = "Belgium";

        [Fact]
        public void TestConstructor() {
            Visitor v = new Visitor(name, email, phone, country);
            Assert.Equal(name, v.Name);
            Assert.Equal(email, v.Email);
            Assert.Equal(phone, v.Telephone);
            Assert.Equal(country, v.Country);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("\t \t")]
        [InlineData("           ")]
        public void WrongConstructorName(string name) {
            Assert.Throws<ArgumentException>(() => new Visitor(name, email,phone,country));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("\t \t")]
        [InlineData("           ")]
        [InlineData("moutpessemierhotmail.com")]
        [InlineData("moutpessemier@hotmailcom")]
        [InlineData("moutpessemier@hotmail@com")]
        [InlineData("bla")]
        [InlineData("bla@")]
        [InlineData("@bla")]
        [InlineData("test@test")]
        [InlineData("test.com")]
        [InlineData("test@.com")]
        [InlineData("@test.com")]
        [InlineData("-test@test.com")]
        [InlineData("_test@test.com")]
        [InlineData("*test@test.com")]
        [InlineData(".test@test.com")]
        [InlineData("$test@test.com")]
        [InlineData("@test@test.com")]
        [InlineData("!test@test.com")]
        [InlineData("test&@test.com")]
        [InlineData("test@test&.com")]
        public void WrongConstructorEmail(string email) {
            Assert.Throws<ArgumentException>(() => new Visitor(name, email, phone, country));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("\t \t")]
        [InlineData("           ")]
        [InlineData("0479114478")]
        [InlineData("03253710420")]
        public void WrongConstructorPhoneNumber(string phoneNumber) {
            Assert.Throws<ArgumentException>(() => new Visitor(name, email, phoneNumber, country));
        }
    }
}

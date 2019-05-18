//using DigitizedApi.Models;
//using System;
//using Xunit;

//namespace DigitizedApiTest.Models {
//    public class VisitorTest {
//        private readonly string firstName = "Mout";
//        private readonly string lastName = "Pessemier";
//        private readonly string email = "moutpessemier@hotmail.com";
//        private readonly string phone = "32479114479";
//        private readonly string country = "Belgium";

//        [Fact]
//        public void TestConstructor() {
//            Visitor v = new Visitor(firstName,lastName, email, phone, country);
//            Assert.Equal(firstName, v.FirstName);
//            Assert.Equal(lastName, v.LastName);
//            Assert.Equal(email, v.Email);
//            Assert.Equal(phone, v.Telephone);
//            Assert.Equal(country, v.Country);
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData("")]
//        [InlineData("\t \t")]
//        [InlineData("           ")]
//        public void WrongConstructorFirstName(string firstName) {
//            Assert.Throws<ArgumentException>(() => new Visitor(firstName, lastName, email, phone, country));
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData("")]
//        [InlineData("\t \t")]
//        [InlineData("           ")]
//        public void WrongConstructorLastName(string lastName) {
//            Assert.Throws<ArgumentException>(() => new Visitor(firstName, lastName, email, phone, country));
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData("")]
//        [InlineData("\t \t")]
//        [InlineData("           ")]
//        [InlineData("moutpessemierhotmail.com")]
//        [InlineData("moutpessemier@hotmailcom")]
//        [InlineData("moutpessemier@hotmail@com")]
//        [InlineData("bla")]
//        [InlineData("bla@")]
//        [InlineData("@bla")]
//        [InlineData("test@test")]
//        [InlineData("test.com")]
//        [InlineData("test@.com")]
//        [InlineData("@test.com")]
//        [InlineData("-test@test.com")]
//        [InlineData("_test@test.com")]
//        [InlineData("*test@test.com")]
//        [InlineData(".test@test.com")]
//        [InlineData("$test@test.com")]
//        [InlineData("@test@test.com")]
//        [InlineData("!test@test.com")]
//        [InlineData("test&@test.com")]
//        [InlineData("test@test&.com")]
//        public void WrongConstructorEmail(string email) {
//            Assert.Throws<ArgumentException>(() => new Visitor(firstName, lastName, email, phone, country));
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData("")]
//        [InlineData("\t \t")]
//        [InlineData("           ")]
//        [InlineData("000479114478")]
//        [InlineData("0032537104")]
//        public void WrongConstructorPhoneNumber(string phoneNumber) {
//            Assert.Throws<ArgumentException>(() => new Visitor(firstName, lastName, email, phoneNumber, country));
//        }
//    }
//}

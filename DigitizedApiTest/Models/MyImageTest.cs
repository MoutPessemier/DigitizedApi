//using DigitizedApi.Models;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Text;
//using Xunit;

//namespace DigitizedApiTest.Models {
//    public class MyImageTest {

//        private readonly string name = "HeaderPicture";
//        private readonly string iso = "ISO-600";
//        private readonly string shutterspeed = "1/2 sec";
//        private readonly string aperture = "f/2.8";
//        private readonly string country = "France";
//        private readonly Image image = Image.FromFile("D:/School/Webapplicaties IV/DigitizedApi/DigitizedApi/DigitizedApi/Images/DSC_2544c2.jpg");

//        [Fact]
//        public void TestConstructor() {
//            MyImage myImage = new MyImage(name, iso, shutterspeed,aperture,country, image);
//            Assert.Equal(name, myImage.Name);
//            Assert.Equal(iso, myImage.ISO);
//            Assert.Equal(shutterspeed, myImage.ShutterSpeed);
//            Assert.Equal(aperture, myImage.Aperture);
//            Assert.Equal(country, myImage.Country);
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData("")]
//        [InlineData("              ")]
//        [InlineData("\t\t\r\n")]
//        public void VerkeerdeNaamTest(string naam) {
//            Assert.Throws<ArgumentException>(() => new MyImage(naam, iso, shutterspeed, aperture, country, image));
//        }

//        //[Theory]
//        //[InlineData(0,1)]
//        //[InlineData(1,1.4)]
//        //[InlineData(2,2)]
//        //[InlineData(3,2.8)]
//        //[InlineData(4,4)]
//        //[InlineData(5,5.6)]
//        //[InlineData(6,8)]
//        //[InlineData(7,11)]
//        //[InlineData(8,16)]
//        //[InlineData(9,22)]
//        //[InlineData(10,32)]
//        //public void TestConvertApexAperture(double a, double b) {
//        //    MyImage image = new MyImage("a", 1, 1, 1, "b");
//        //    Assert.Equal(b, image.ConvertApexAperture(a));
//        //}
//    }
//}

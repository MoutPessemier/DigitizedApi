using DigitizedApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DigitizedApiTest.Models {
    public class MyImageTest {

        private readonly string name = "HeaderPicture";
        private readonly int iso = 600;
        private readonly double shutterspeed = 1 / 2;
        private readonly double aperture = 2.8;
        private readonly string country = "France";

        [Fact]
        public void TestConstructor() {
            //MyImage image = new MyImage(name,country,null);
            //Assert.Equal(name, image.Name);
            //Assert.Equal(iso, image.ISO);
            //Assert.Equal(shutterspeed, image.ShutterSpeed);
            //Assert.Equal(aperture, image.Aperture);
            //Assert.Equal(country, image.Country);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("              ")]
        [InlineData("\t\t\r\n")]
        public void VerkeerdeNaamTest(string naam) {
            Assert.Throws<ArgumentException>(() => new MyImage(naam,country,null));
        }

        //[Theory]
        //[InlineData(0,1)]
        //[InlineData(1,1.4)]
        //[InlineData(2,2)]
        //[InlineData(3,2.8)]
        //[InlineData(4,4)]
        //[InlineData(5,5.6)]
        //[InlineData(6,8)]
        //[InlineData(7,11)]
        //[InlineData(8,16)]
        //[InlineData(9,22)]
        //[InlineData(10,32)]
        //public void TestConvertApexAperture(double a, double b) {
        //    MyImage image = new MyImage("a", 1, 1, 1, "b");
        //    Assert.Equal(b, image.ConvertApexAperture(a));
        //}
    }
}

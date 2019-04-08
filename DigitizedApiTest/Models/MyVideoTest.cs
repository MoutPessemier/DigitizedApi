using DigitizedApi.Models;
using System;
using Xunit;

namespace DigitizedApiTest.Models {
    public class MyVideoTest {
        [Fact]
        public void TestConstructor() {
            MyVideo vid = new MyVideo("https://www.youtube.com/watch?v=i_Lj8VwH_DY");
            Assert.Equal("https://www.youtube.com/embed/i_Lj8VwH_DY", vid.URL);
        }

        [Theory]
        [InlineData("bla")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("\t \r \n")]
        [InlineData("                     ")]
        [InlineData("www.youtubebe/abc")]
        [InlineData("www.youtube.be/abc")]
        [InlineData("wwwyoutube.be/abc")]
        [InlineData("www.youtube.com/watch?v=")]
        public void TestConstructorBadValues(string url) {
            Assert.Throws<ArgumentException>(() => new MyVideo(url));
        }

        [Theory]
        [InlineData("https://www.youtube.com/watch?v=r01AyFR8rzI", "https://www.youtube.com/embed/r01AyFR8rzI")]
        public void TestURLConvertor(string url, string expected) {
            MyVideo video = new MyVideo();
            Assert.Equal(expected, video.makeEmbedded(url));
        }
    }
}

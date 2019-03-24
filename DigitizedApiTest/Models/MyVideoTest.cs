using DigitizedApi.Models;
using Xunit;

namespace DigitizedApiTest.Models {
    public class MyVideoTest {
        [Fact]
        public void TestConstructor() {
            MyVideo vid = new MyVideo("https://www.youtube.com/watch?v=i_Lj8VwH_DY");
            Assert.Equal("https://www.youtube.com/embed/i_Lj8VwH_DY", vid.URL);
        }
    }
}

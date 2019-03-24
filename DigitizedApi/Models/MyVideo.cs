using System;
using System.Linq;
using System.Web;

namespace DigitizedApi.Models {
    public class MyVideo {
        #region Properties
        public int Id { get; set; }
        public string URL { get; set; }
        #endregion

        #region Constructor
        public MyVideo(string url) {
            URL = makeEmbedded(url);
        }

        public MyVideo() {

        }
        #endregion

        #region Methods
        private string makeEmbedded(string url) {
            var uri = new Uri(url);

            var query = HttpUtility.ParseQueryString(uri.Query);

            var videoId = string.Empty;

            if (query.AllKeys.Contains("v")) {
                videoId = query["v"];
            } else {
                videoId = uri.Segments.Last();
            }

            return "https://www.youtube.com/embed/" + videoId;
        }
        #endregion
    }
}

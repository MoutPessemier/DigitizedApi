using System;
using System.Collections.Specialized;
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
        public string makeEmbedded(string url) {
            if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url)) {
                throw new ArgumentException("URL cannot be empty");
            }
            Uri uri;
            try {
                uri = new Uri(url);
            } catch (UriFormatException ex) {
                throw new ArgumentException(ex.Message);
            } catch (ArgumentNullException ex) {
                throw new ArgumentException(ex.Message);
            }

            NameValueCollection query;

            try {
                query = HttpUtility.ParseQueryString(uri.Query);
            } catch (UriFormatException ex) {
                throw new ArgumentException(ex.Message);
            } catch (ArgumentNullException ex) {
                throw new ArgumentException(ex.Message);
            }


            var videoId = string.Empty;

            if (query.AllKeys.Contains("v")) {
                videoId = query["v"];
            } else {
                videoId = uri.Segments.Last();
            }

            return "https://" + uri.Host + "/embed/" + videoId;
        }
        #endregion
    }
}

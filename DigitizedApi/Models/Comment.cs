using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizedApi.Models {
    public class Comment {

        #region Properties
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int MyImageId { get; set; }
        #endregion

        #region Constructors
        public Comment() {

        }

        public Comment(string author, string content) {
            Author = author;
            Content = content;
            Date = new DateTime();
        }
        #endregion
    }
}

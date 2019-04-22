using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizedApi.Models {
    public class ContactMessage {
        #region Properties
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        #endregion

        #region Constructors
        public ContactMessage() {

        }

        public ContactMessage(string topic, string content, string author) {
            Topic = topic;
            Content = content;
            Date = new DateTime();
            Author = author;
        }
        #endregion
    }
}

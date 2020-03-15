using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;

namespace DigitizedApi.Models
{
    public class MyImage {

        #region Fields
        private string _name;
        #endregion

        #region Properties
        public int Id { get; set; }
        [Required]
        public string Name {
            get {
                return _name;
            }

            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Name cannot be empty.");
                }
                _name = value;
            }
        }
        public string ISO { get; set; }
        public string ShutterSpeed { get; set; }
        public string Aperture { get; set; }
        public string Country { get; set; }
        public string Path { get; set; }
        public int Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        #endregion

        #region Constructor
        public MyImage() {

        }

        public MyImage(string name, string iso, string shutter, string fnumber, string country, string path) {
            Name = name;
            ISO = iso;
            ShutterSpeed = shutter;
            Aperture = fnumber;
            Country = country;
            Path = path;
            Likes = 0;
            Comments = new List<Comment>();
        }
        #endregion

        #region Methods
        private string ConvertImage(Image imageToConvert) {
            byte[] Ret;
            try {
                using (MemoryStream ms = new MemoryStream()) {
                    imageToConvert.Save(ms, imageToConvert.RawFormat);
                    Ret = ms.ToArray();
                }
            } catch (Exception ex) {
                throw;
            }
            return Convert.ToBase64String(Ret);
        }

        public void AddComment(Comment comment) => Comments.Add(comment);
        public Comment GetComment(int id) => Comments.FirstOrDefault(c => c.Id == id);
        #endregion
    }
}

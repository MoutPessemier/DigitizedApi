using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitizedApi.Models {
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
        //public string ExposureTime { get; set; }
        public string ISO { get; set; }
        public string ShutterSpeed { get; set; }
        public string Aperture { get; set; }
        public string Country { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        #endregion

        #region Constructor
        //public MyImage(string name, int iso, double shutterspeed, double aperture, string country, string content) {
        //    Name = name;
        //    ISO = iso;
        //    ShutterSpeed = shutterspeed;
        //    Aperture = aperture;
        //    Country = country;
        //    Content = content;

        //}

        public MyImage() {

        }

        //public MyImage(string name, string country, Image image) {
        //    Name = name;
        //    //ExposureTime = Convert.ToInt64(Encoding.UTF8.GetString(image.GetPropertyItem(0x829A).Value));
        //    //ISO = Convert.ToInt64(Encoding.UTF8.GetString(image.GetPropertyItem(0x8827).Value));
        //    //ShutterSpeed = Convert.ToInt64(Encoding.UTF8.GetString(image.GetPropertyItem(0x9201).Value));
        //    //Aperture = Convert.ToInt64(Encoding.UTF8.GetString(image.GetPropertyItem(0x829D).Value));

        //    //ExposureTime = Encoding.UTF8.GetString(image.GetPropertyItem(0x829A).Value);
        //    //ISO = Encoding.UTF8.GetString(image.GetPropertyItem(0x8827).Value);
        //    //ShutterSpeed = Encoding.UTF8.GetString(image.GetPropertyItem(0x9201).Value);
        //    //Aperture = Encoding.UTF8.GetString(image.GetPropertyItem(0x829D).Value);
        //    Country = country;
        //    Content = ConvertImage(image);
        //}

        public MyImage(string name, string iso, string shutter, string fnumber, string country, Image image) {
            Name = name;
            ISO = iso;
            ShutterSpeed = shutter;
            Aperture = fnumber;
            Country = country;
            Content = ConvertImage(image);
            Likes = 0;
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

        private double CalcFNumber(double apex) {
            //return Math.Round(Math.Pow(2, apex / 2), 1);
            return Math.Pow(2, apex / 2);
        }
        #endregion
    }
}

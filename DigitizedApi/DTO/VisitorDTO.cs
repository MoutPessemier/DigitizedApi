using DigitizedApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizedApi.DTO {
    public class VisitorDTO {
        //probeer eerst zonder als het nog altijd niet werkt, gebruik dto
        #region Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public IEnumerable<MyImage> Images { get; set; }
        #endregion
        #region constructors
        public VisitorDTO(Visitor visitor) {
            Name = visitor.Name;
            Email = visitor.Email;
            Telephone = visitor.Telephone;
            Country = visitor.Country;
            Images = visitor.LikedImages;
        }
        #endregion
    }
}

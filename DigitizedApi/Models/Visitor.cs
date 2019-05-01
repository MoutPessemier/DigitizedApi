using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DigitizedApi.Models {
    public class Visitor {

        #region Fields
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _telephone;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string FirstName {
            get {
                return _firstName;
            }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Name can't be empty.");
                }
                _firstName = value;
            }
        }

        public string LastName {
            get {
                return _lastName;
            }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Name can't be empty.");
                }
                _lastName = value;
            }
        }

        public string Email {
            get {
                return _email;
            }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Email can't be empty.");
                }
                Regex regex = new Regex(@"^([a-zA-Z0-9éèà]+[a-zA-Z0-9.-éèàïëöüäîôûêâù]*)@([a-zA-Z]+)[.]([a-z]+)([.][a-z]+)*$");
                Match match = regex.Match(value);
                if (!match.Success) {
                    throw new ArgumentException("Email doesn't have a correct format.");
                }
                _email = value;
            }
        }

        public string Telephone {
            get {
                return _telephone;
            }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Telephone number can't be empty.");
                }
                Regex regex = new Regex(@"^0{0,2}(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{7,14}$");
                Match match = regex.Match(value);
                if (!match.Success) {
                    throw new ArgumentException("Telephone number doesn't have a correct format. " +
                        "Please make sure you use an international phone number (+44791112345)");
                }
                _telephone = value;
            }
        }

        public string Country { get; set; }

        public ICollection<LikedImage> Liked { get; private set; }
        public IEnumerable<MyImage> LikedImages => Liked.Select(i => i.Image);
        public IEnumerable<Comment> Comments { get; set; }
        #endregion

        #region Constructor
        public Visitor(string firstName, string lastName, string email, string telephone, string country = null) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
            Country = country;
        }
        #endregion
    }
}

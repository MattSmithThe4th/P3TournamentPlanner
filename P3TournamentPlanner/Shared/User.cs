using System.Collections.Generic;
using System;

namespace P3TournamentPlanner.Shared {
    public class User {
        public User() {
        }

        public User(string ID, string email, List<string> roles) {
            this.ID = ID;
            this.email = email;
            this.roles = roles;
        }

        private string _id;
        public string ID {
            get {
                return _id;
            } set {
                if((value == "")||(value == null)) {
                    throw new ArgumentException("ID cannot be an empty string or NULL");
                } else {
                    _id = value;
                }
            }
        }
        private string _email;
        public string email {
            get {
                return _email;
            }
            set {
                if((value == "") || (value == null)) {
                    throw new ArgumentException("Email cannot be an empty string or NULL");
                } else {
                    _email = value;
                }
            }
        }
        public List<string> roles { get; set; }
    }
}

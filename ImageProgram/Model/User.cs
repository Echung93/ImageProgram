using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    class User
    {

        private string userId;
        private string userPassword;
        private string userName;
        private string userAddress;
        private string userPhoneNumber;
        private string userRegistrationNumber;
        private string userEmail;

        public User()
        {

        }
        public User(string userId, string userName, string userPassword,  string userAddress, string userPhoneNumber, string userRegistrationNumber, string userEmail)
        {
            this.userId = userId;
            this.userName = userName;
            this.userPassword = userPassword;                     
            this.userAddress = userAddress;
            this.userPhoneNumber = userPhoneNumber;
            this.userRegistrationNumber = userRegistrationNumber;
            this.userEmail = userEmail;

        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        public string UserRegistrationNumber
        {
            get { return userRegistrationNumber; }
            set { userRegistrationNumber = value; }
        }

        public string UserPhoneNumber
        {
            get { return userPhoneNumber; }
            set { userPhoneNumber = value; }
        }

        public string UserAddress
        {
            get { return userAddress; }
            set { userAddress = value; }
        }
       
        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class UserProfile
    {
        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _middleName;

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set {
                if (value == "-1")
                {
                    throw new Exception("Title is required ");
                    
                } _title = value;
            }
        }
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set {
                if (value == null)
                {
                    throw new Exception("Name is required ");
                    
                } _fullName = value;
            }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set {
                if (value == null)
                {
                    throw new Exception("Email is required ");
                    
                } _email = value;
            }
        }
        private string _userIdentifierID;

        public string UserIdentifierID
        {
            get { return _userIdentifierID; }
            set {
                if (value == null)
                {
                    throw new Exception("User ID is required ");
                    
                } _userIdentifierID = value;
            }
        }
        private string _entryUserName;

        public string EntryUserName
        {
            get { return _entryUserName; }
            set { _entryUserName = value; }
        }
        private Nullable<int> _passwordFormat;

        public Nullable<int> PasswordFormat
        {
            get { return _passwordFormat; }
            set { _passwordFormat = value; }
        }
        private string _passwordSalt;

        public string PasswordSalt
        {
            get { return _passwordSalt; }
            set { _passwordSalt = value; }
        }
        private string _mobilePIN;

        public string MobilePIN
        {
            get { return _mobilePIN; }
            set { _mobilePIN = value; }
        }
        private string _loweredEmail;

        public string LoweredEmail
        {
            get { return _loweredEmail; }
            set { _loweredEmail = value; }
        }
        private Nullable<DateTime> _dateOfBirth;

        public Nullable<DateTime> DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        private string _passwordQuestion;

        public string PasswordQuestion
        {
            get { return _passwordQuestion; }
            set { _passwordQuestion = value; }
        }
        private string _passwordAnswer;

        public string PasswordAnswer
        {
            get { return _passwordAnswer; }
            set { _passwordAnswer = value; }
        }
        private int _isApproved;

        public int IsApproved
        {
            get { return _isApproved; }
            set { _isApproved = value; }
        }




        private int _isLockedOut;

        public int IsLockedOut
        {
            get { return _isLockedOut; }
            set { _isLockedOut = value; }
        }

        

        
        private Nullable<DateTime> _createDate;

        public Nullable<DateTime> CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        private string _Comment;

        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }
        private string _userProfileTypeID;

        public string UserProfileTypeID
        {
            get { return _userProfileTypeID; }
            set {
                if (value == "-1")
                {
                    throw new Exception("User profile type is required ");
                    
                } _userProfileTypeID = value;
            }
        }
        private string _userProfileID;

        public string UserProfileID
        {
            get { return _userProfileID; }
            set { _userProfileID = value; }
        }
        
    }
}
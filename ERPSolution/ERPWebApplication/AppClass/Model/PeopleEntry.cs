using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class PeopleEntry : CompanySetup
    {
        private string _peopleName;

        public string PeopleName
        {
            get { return _peopleName; }
            set { _peopleName = value; }
        }
        private DateTime? _birthDate;

        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        private string _peopleEmail;

        public string PeopleEmail
        {
            get { return _peopleEmail; }
            set { _peopleEmail = value; }
        }
        private DataTable _dtPeople;

        public DataTable DtPeople
        {
            get { return _dtPeople; }
            set { _dtPeople = value; }
        }
        private string _searchOption1;

        public string SearchOption1
        {
            get { return _searchOption1; }
            set { _searchOption1 = value; }
        }
        private string _searchOption2;

        public string SearchOption2
        {
            get { return _searchOption2; }
            set { _searchOption2 = value; }
        }
        private string _searchOption3;

        public string SearchOption3
        {
            get { return _searchOption3; }
            set { _searchOption3 = value; }
        }
        private string _searchOption4;

        public string SearchOption4
        {
            get { return _searchOption4; }
            set { _searchOption4 = value; }
        }
    }
}
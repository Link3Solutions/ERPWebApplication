using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class PackageSetup : CompanySetup
    {
        private int _packageID;

        public int PackageID
        {
            get { return _packageID; }
            set { _packageID = value; }
        }
        private string _packageName;

        public string PackageName
        {
            get { return _packageName; }
            set {
                if (value == null)
                {
                    throw new Exception(" Package name is required");
                } _packageName = value;
            }
        }
        private string _packageDescription;

        public string PackageDescription
        {
            get { return _packageDescription; }
            set { _packageDescription = value; }
        }
        private DataTable _dtPackages;

        public DataTable DtPackages
        {
            get { return _dtPackages; }
            set { _dtPackages = value; }
        }
    }
}
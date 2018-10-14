using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class RelatedUserRole
    {
        private string _relatedRoleText;

        public string RelatedRoleText
        {
            get { return _relatedRoleText; }
            set {
                if (value == null)
                {
                    throw new Exception(" Related user role is required ");
                } _relatedRoleText = value;
            }
        }
        private int _relatedRoleID;

        public int RelatedRoleID
        {
            get { return _relatedRoleID; }
            set { _relatedRoleID = value; }
        }
        private DataTable _dtRelatedRole;

        public DataTable DtRelatedRole
        {
            get { return _dtRelatedRole; }
            set { _dtRelatedRole = value; }
        }

    }
}
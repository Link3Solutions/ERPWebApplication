﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class BranchSetup
    {
        private int _branchID;

        public int BranchID
        {
            get { return _branchID; }
            set { _branchID = value; }
        }
    }
}
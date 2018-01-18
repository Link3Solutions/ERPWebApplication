using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class ProcessDetails : BranchSetup
    {
        private string _processId;

        public string ProcessId
        {
            get { return _processId; }
            set { _processId = value; }
        }
        private string _processDescription;

        public string ProcessDescription
        {
            get { return _processDescription; }
            set { _processDescription = value; }
        }
        private string _processStatus;

        public string ProcessStatus
        {
            get { return _processStatus; }
            set { _processStatus = value; }
        }
    }
}
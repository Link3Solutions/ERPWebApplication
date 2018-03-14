using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class ProcessFlow : BranchSetup  
    {
        private string _applicantID;

        public string ApplicantID
        {
            get { return _applicantID; }
            set { _applicantID = value; }
        }
        private string _remarksProcess;

        public string RemarksProcess
        {
            get { return _remarksProcess; }
            set { _remarksProcess = value; }
        }
        private string _transactionNo;

        public string TransactionNo
        {
            get { return _transactionNo; }
            set { _transactionNo = value; }
        }
        private int _lineNo;

        public int LineNo
        {
            get { return _lineNo; }
            set { _lineNo = value; }
        }
        private string _responsiblePersonID;

        public string ResponsiblePersonID
        {
            get { return _responsiblePersonID; }
            set { _responsiblePersonID = value; }
        }
        private string _processId;

        public string ProcessId
        {
            get { return _processId; }
            set { _processId = value; }
        }
        private int? _flowId;

        public int? FlowId
        {
            get { return _flowId; }
            set { _flowId = value; }
        }
        private int _levelId;

        public int LevelId
        {
            get { return _levelId; }
            set { _levelId = value; }
        }
        private int _actionTypeId;

        public int ActionTypeId
        {
            get { return _actionTypeId; }
            set { _actionTypeId = value; }
        }
    }
}
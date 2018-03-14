using System;
using System.Collections.Generic;
using System.Data;
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
            set
            {
                if (value == null)
                {
                    throw new Exception(" Process Description is required ");
                } _processDescription = value;
            }
        }
        private string _processStatus;

        public string ProcessStatus
        {
            get { return _processStatus; }
            set { _processStatus = value; }
        }
        private DataTable _dtProcessDescription;

        public DataTable DtProcessDescription
        {
            get { return _dtProcessDescription; }
            set { _dtProcessDescription = value; }
        }
        private int _categoryId;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }
        private string _flowDescription;

        public string FlowDescription
        {
            get { return _flowDescription; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Flow Description is required ");
                } _flowDescription = value;
            }
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
        private string _levelDescription;

        public string LevelDescription
        {
            get { return _levelDescription; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Level Description is required ");
                } _levelDescription = value;
            }
        }
        private int _actionTypeId;

        public int ActionTypeId
        {
            get { return _actionTypeId; }
            set { _actionTypeId = value; }
        }
        private string _actionType;

        public string ActionType
        {
            get { return _actionType; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Action Type is required ");
                } _actionType = value;
            }
        }
        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }
        private string _accessId;

        public string AccessId
        {
            get { return _accessId; }
            set { _accessId = value; }
        }
        private string _subAccessId;

        public string SubAccessId
        {
            get { return _subAccessId; }
            set { _subAccessId = value; }
        }
        private string _accessPermissionTypeId;

        public string AccessPermissionTypeId
        {
            get { return _accessPermissionTypeId; }
            set { _accessPermissionTypeId = value; }
        }
        private string _subAccessPermissionTypeId;

        public string SubAccessPermissionTypeId
        {
            get { return _subAccessPermissionTypeId; }
            set { _subAccessPermissionTypeId = value; }
        }
        private string _applicantId;

        public string ApplicantId
        {
            get { return _applicantId; }
            set { _applicantId = value; }
        }
        private DataTable _dtConfigurationData;

        public DataTable DtConfigurationData
        {
            get { return _dtConfigurationData; }
            set { _dtConfigurationData = value; }
        }
        private string _referenceNo;

        public string ReferenceNo
        {
            get { return _referenceNo; }
            set { _referenceNo = value; }
        }
        private DataTable _dtReferenceNo;

        public DataTable DtReferenceNo
        {
            get { return _dtReferenceNo; }
            set { _dtReferenceNo = value; }
        }
        private Nullable<DateTime> _effectiveDate;

        public Nullable<DateTime> EffectiveDate
        {
            get { return _effectiveDate; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Effective Date is required ");
                } _effectiveDate = value;
            }
        }
        private int _lineNo;

        public int LineNo
        {
            get { return _lineNo; }
            set { _lineNo = value; }
        }
        private string _accessPermissionTypeText;

        public string AccessPermissionTypeText
        {
            get { return _accessPermissionTypeText; }
            set { _accessPermissionTypeText = value; }
        }
        private string _subAccessPermissionTypeText;

        public string SubAccessPermissionTypeText
        {
            get { return _subAccessPermissionTypeText; }
            set { _subAccessPermissionTypeText = value; }
        }
        private DataTable _dtProcessFlow;

        public DataTable DtProcessFlow
        {
            get { return _dtProcessFlow; }
            set { _dtProcessFlow = value; }
        }
        private DataTable _dtProcessLevel;

        public DataTable DtProcessLevel
        {
            get { return _dtProcessLevel; }
            set { _dtProcessLevel = value; }
        }
        private DataTable _dtProcessAction;

        public DataTable DtProcessAction
        {
            get { return _dtProcessAction; }
            set { _dtProcessAction = value; }
        }
        
    }
}
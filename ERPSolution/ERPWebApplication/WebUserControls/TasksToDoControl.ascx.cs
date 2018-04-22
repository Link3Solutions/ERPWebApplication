using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.WebUserControls
{
    public partial class TasksToDoControl : System.Web.UI.UserControl
    {
        private ProcessDetails _objProcessDetails;
        private ProcessFlowController _objProcessFlowController;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPendingTask();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        bool controlToDoLabel = false;
        private void LoadPendingTask()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetails.CompanyID = LoginUserInformation.CompanyID;
                _objProcessDetails.BranchID = LoginUserInformation.BranchID;
                _objProcessDetails.AccessId = LoginUserInformation.EmployeeCode == null ? "" : LoginUserInformation.EmployeeCode;
                _objProcessDetails.ProcessId = "";
                _objProcessFlowController = new ProcessFlowController();

                _objProcessDetails.DtPendingProcessCount = _objProcessFlowController.GetPendingApplicationCount(_objProcessDetails);
                _objProcessDetails.DttblInboxData = _objProcessFlowController.GettblInboxData();

                int i = 1;
                int tcount = 0;
                

                foreach (DataRow dr in _objProcessDetails.DttblInboxData.Rows)
                {

                    if (i == 1)
                    {
                        tcount = GetTaskCount(dr["ProcessID"].ToString(), _objProcessDetails.DtPendingProcessCount);
                        lnkLeaveApplication.Text = dr["TaskName"].ToString() + "(" + tcount.ToString() + ")";
                        lnkLeaveApplication.PostBackUrl = dr["URL"].ToString();

                        if (tcount > 0)
                            lnkLeaveApplication.Visible = true;
                        else
                            lnkLeaveApplication.Visible = false;
                    }

                    #region controlToDoLabelPart1
                    if (controlToDoLabel == true)
                    {
                        lblTaskstodo.Visible = true;
                    }
                    else
                    {
                        lblTaskstodo.Visible = false;
                    }
                    #endregion controlToDoLabelPart1

                    i++;

                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int GetTaskCount(string processid, DataTable dtpending)
        {
            int TP = 0;
            foreach (DataRow drr in dtpending.Rows)
            {
                if (drr["ProcessId"].ToString() == processid)
                {
                    TP = Convert.ToInt32(drr["nooftask"].ToString());
                }
            }

            #region controlToDoLabelPart2
            if (TP > 0)
            {
                controlToDoLabel = true;
            }
            #endregion controlToDoLabelPart2

            return TP;
        }
    }
}
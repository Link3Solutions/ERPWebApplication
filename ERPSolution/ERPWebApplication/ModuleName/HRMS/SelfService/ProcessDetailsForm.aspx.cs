using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.ModuleName.HRMS.SelfService
{
    public partial class ProcessDetailsForm : System.Web.UI.Page
    {
        private ProcessDetails _objProcessDetails;
        private ProcessDetailsController _objProcessDetailsController;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddProcessValues();
            }
            catch (Exception msgException)
            {
                clsTopMostMessageBox.Show(msgException.Message);
                
            }
        }

        private void AddProcessValues()
        {
            try
            {
                _objProcessDetails = new ProcessDetails();
                _objProcessDetailsController = new ProcessDetailsController();
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}
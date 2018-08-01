using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication
{
    public partial class ServiceRequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblNameoftheModule.Text = Session["moduleName"].ToString();
                ControlPanelVisibility(PanelSubModuleLogo, PanelModuleDescription, PanelUserAccount, PanelCreateAccount, PanelUserLogin);
            }

        }

        private void ControlPanelVisibility(Panel panelTarget1, Panel panelTarget2, Panel PanelOptional1, Panel PanelOptional2, Panel PanelOptional3)
        {
            try
            {
                panelTarget1.Visible = true;
                panelTarget2.Visible = true;
                PanelOptional1.Visible = false;
                PanelOptional2.Visible = false;
                PanelOptional3.Visible = false;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ControlPanelVisibility(Panel targetPanel, Panel panelOptional1, Panel panelOptional2, Panel panelOptional3)
        {
            try
            {
                targetPanel.Visible = true;
                panelOptional1.Visible = false;
                panelOptional2.Visible = false;
                panelOptional3.Visible = false;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibilityPlaceOrder(PanelUserAccount, PanelSubModuleLogo, PanelModuleDescription, PanelCreateAccount, PanelUserLogin);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ControlPanelVisibilityPlaceOrder(Panel panelTarget1, Panel PanelOptional1, Panel PanelOptional2, Panel PanelOptional3, Panel PanelOptional4)
        {
            try
            {
                panelTarget1.Visible = true;
                PanelOptional1.Visible = false;
                PanelOptional2.Visible = false;
                PanelOptional3.Visible = false;
                PanelOptional4.Visible = false;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibility(PanelCreateAccount, PanelUserAccount, PanelUserLogin);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ControlPanelVisibility(Panel panelTarget1, Panel PanelOptional1, Panel PanelOptional2)
        {
            try
            {
                panelTarget1.Visible = true;
                PanelOptional1.Visible = false;
                PanelOptional2.Visible = false;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSigninPanel_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibility(PanelUserLogin, PanelCreateAccount, PanelUserAccount);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void lnkbtnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibility(PanelUserLogin, PanelCreateAccount, PanelUserAccount);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void lnkbtnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                ControlPanelVisibility(PanelCreateAccount, PanelUserAccount, PanelUserLogin);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.DataAccess;
using System.Data;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.CommonClass
{
    public class CGlobalMethod : DataAccessBase
    {
        public decimal GetMaxColumnValue(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    dt.DefaultView.Sort = "SlNo DESC";
                    return Decimal.Parse(dt.DefaultView[0]["SlNo"].ToString());

                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public void ControlButtonVisibility(Button targetButton1, Button targetButton2, Button optionalButton1, Button optionalButton2)
        {
            try
            {
                targetButton1.Visible = true;
                targetButton2.Visible = true;
                optionalButton1.Visible = false;
                optionalButton2.Visible = false;
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}
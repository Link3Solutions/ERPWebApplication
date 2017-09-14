using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.DataAccess;
using System.Data;

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
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class RelatedUserRoleController : DataAccessBase
    {
        internal void SaveRelatedRole(CompanySetup objCompanySetup, RelatedUserRole objRelatedUserRole)
        {
            try
            {
                int countTableData = CheckRelatedRole(objRelatedUserRole);
                if (countTableData != 0)
                {
                    throw new Exception("Related User Role : " + objRelatedUserRole.RelatedRoleText + " " + clsMessages.GExist);
                }

                objRelatedUserRole.RelatedRoleID = GetRelatedRoleID();
                var storedProcedureComandText = @"INSERT INTO [sysRelatedUserRoleSetup]
                   ([RelatedToID]
                   ,[RelatedToText]
                   ,[DataUsed]
                   ,[EntryUserID]
                   ,[EntryDate])
                    VALUES
                   (" + objRelatedUserRole.RelatedRoleID + ""
                      + ",'" + objRelatedUserRole.RelatedRoleText + "'"
                      + ",'" + "A" + "'"
                      + ",'" + objCompanySetup.EntryUserName + "'"
                      + "," + "CAST(GETDATE() AS DateTime)" + ""
                      + ");";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int CheckRelatedRole(RelatedUserRole objRelatedUserRole)
        {
            try
            {
                string sql = "SELECT COUNT(A.RelatedToID) AS RelatedToID FROM sysRelatedUserRoleSetup A WHERE A.DataUsed='A' AND A.RelatedToText = '" + objRelatedUserRole.RelatedRoleText + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                int tableDataCount;
                return tableDataCount = objclsDataManipulation.GetSingleValue(this.ConnectionString, sql);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int GetRelatedRoleID()
        {
            try
            {
                int roleID = 0;
                var storedProcedureComandText = "SELECT ISNULL( MAX( RelatedToID),0)+1 as RelatedToID FROM sysRelatedUserRoleSetup";
                roleID = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return roleID;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetRelatedUserRole()
        {
            try
            {
                DataTable dtPackages = null;
                var storedProcedureComandText = @"SELECT A.RelatedToID,A.RelatedToText FROM sysRelatedUserRoleSetup A WHERE A.DataUsed='A' ORDER BY A.RelatedToText";
                dtPackages = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtPackages;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void DeleteRelatedUserRole(RelatedUserRole objRelatedUserRole)
        {
            try
            {
                var storedProcedureComandText = "UPDATE [sysRelatedUserRoleSetup] SET DataUsed	= 'I' WHERE RelatedToID = " + objRelatedUserRole.RelatedRoleID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void UpdateRelatedUserRole(CompanySetup objCompanySetup, RelatedUserRole objRelatedUserRole)
        {
            try
            {
                bool tableData = true;
                tableData = CheckRelatedUserRoleUpdate(objRelatedUserRole);
                if (tableData == false)
                {
                    throw new Exception("Related User Role : " + objRelatedUserRole.RelatedRoleText + " " + clsMessages.GExist);
                }

                var storedProcedureComandText = "UPDATE [sysRelatedUserRoleSetup] " +
                                           " SET [RelatedToText] = ISNULL('" + objRelatedUserRole.RelatedRoleText + "',[RelatedToText]) " +
                                              " ,[LastUpdateDate] = CAST(GETDATE() AS DateTime) " +
                                              " ,[LastUpdateUserID] = '" + objCompanySetup.EntryUserName + "' " +
                                          " WHERE [RelatedToID] = " + objRelatedUserRole.RelatedRoleID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private bool CheckRelatedUserRoleUpdate(RelatedUserRole objRelatedUserRole)
        {
            try
            {
                bool checkData = true;
                string sql = "SELECT A.RelatedToID FROM sysRelatedUserRoleSetup A WHERE A.DataUsed='A' AND A.RelatedToText = '" + objRelatedUserRole.RelatedRoleText + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                string tableDataValue;
                tableDataValue = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
                if (tableDataValue != null && tableDataValue != objRelatedUserRole.RelatedRoleID.ToString())
                {
                    checkData = false;
                }

                return checkData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}
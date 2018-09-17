using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class PackageSetupController : DataAccessBase
    {
        internal void SavePackage(PackageSetup objPackageSetup)
        {
            try
            {
                //bool serviceName = true;
                //serviceName = CheckServiceName(objServiceManagement);
                //if (serviceName == false)
                //{
                //    throw new Exception("Service Name : " + objServiceManagement.ServiceName + " " + clsMessages.GExist);
                //}

                objPackageSetup.PackageID = GetPackageID();
                var storedProcedureComandText = @"
                INSERT INTO [sysPackageSetup]
               ([PackageID]               
               ,[PackageName]
               ,[PackageDescription]               
               ,[DataUsed]
               ,[EntryUserID]
               ,[EntryDate])
                VALUES
               (" + objPackageSetup.PackageID + ""

                 + ",'" + objPackageSetup.PackageName + "'"
                 + ",'" + objPackageSetup.PackageDescription + "'"
                 + ",'" + "A" + "'"
                 + ",'" + objPackageSetup.EntryUserName + "'"
                  + "," + "CAST(GETDATE() AS DateTime)" + ""
                + ");";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetPackageID()
        {
            try
            {
                int PackageNo = 0;
                var storedProcedureComandText = "SELECT ISNULL( COUNT( PackageID),0)+1 as PackageID FROM [sysPackageSetup]";
                PackageNo = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return PackageNo;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetPackages()
        {
            try
            {
                DataTable dtPackages = null;
                var storedProcedureComandText = @"SELECT A.PackageID,A.PackageName,A.PackageDescription
                FROM [sysPackageSetup] A WHERE A.[DataUsed] = 'A' ORDER BY A.PackageName ";
                dtPackages = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtPackages;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void DeletePackage(PackageSetup objPackageSetup)
        {
            try
            {
                var storedProcedureComandText = "UPDATE [sysPackageSetup] SET DataUsed	= 'I' WHERE PackageID = " + objPackageSetup.PackageID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void UpdatePackage(PackageSetup objPackageSetup)
        {
            try
            {
                var storedProcedureComandText = "UPDATE [sysPackageSetup] " +
                                           " SET [PackageName] = ISNULL('" + objPackageSetup.PackageName + "',[PackageName]) " +
                                              " ,[PackageDescription] = ISNULL('" + objPackageSetup.PackageDescription + "',[PackageDescription]) " +
                                              " ,[LastUpdateDate] = CAST(GETDATE() AS DateTime) " +
                                              " ,[LastUpdateUserID] = '" + objPackageSetup.EntryUserName + "' " +
                                          " WHERE [PackageID] = " + objPackageSetup.PackageID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetPackageDescription(PackageSetup objPackageSetup)
        {
            try
            {
                DataTable dtPackages = null;
                var storedProcedureComandText = @"SELECT PackageDescription FROM sysPackageSetup WHERE DataUsed = 'A' AND PackageID = " + objPackageSetup.PackageID + "";
                dtPackages = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtPackages;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}
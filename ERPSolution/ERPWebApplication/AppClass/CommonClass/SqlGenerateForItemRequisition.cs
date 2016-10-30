﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPWebApplication.Model;
using System.Configuration;



namespace ERPWebApplication.CommonClass
{

    public class SqlGenerateForItemRequisition
    {

        public SqlGenerateForItemRequisition()
        {

        }

        public static string SqlInsert(clsRequisitionHeader hdr)
        {
            string sql = "INSERT INTO [ItemRequisitionHeader] ([CompanyID], [BranchID], [ItemRequisitionNo],[RequisitionBy],[RequisitionDate],[RequiredDate],[RequestedDepartmentID],[UserType],[UserID],[LocationOfUse],[LocationAddress],[PriorityID],[PurposeID],[ReferenceTypeID],[ReferenceNumber],[ProjectID],[RequisitionCurrentStatus],[RequisitionComments],[CompletionStatus],[EntryDate],[EntryUserID],[ModifiedDate],[ModifiedUserID]) VALUES (" + hdr.CompanyID + ", " + hdr.BranchID + ", '" + hdr.ItemRequisitionNo + "','" + hdr.RequisitionBy + "',convert(datetime,'" + hdr.RequisitionDate + "',103),convert(datetime,'" + hdr.RequiredDate + "',103),'" + hdr.RequestedDepartment + "'," + hdr.UserType + ",'" + hdr.UserID + "'," + hdr.LocationOfUse + ",'" + hdr.LocationAddress + "'," + hdr.PriorityID + "," + hdr.PurposeID + "," + hdr.ReferenceTypeID + ",'" + hdr.ReferenceNumber + "','" + hdr.ProjectID + "'," + hdr.RequisitionCurrentStatus + ",'" + hdr.RequisitionComments + "'," + hdr.CompletionStatus + ",convert(datetime,'" + hdr.EntryDate + "',103),'" + hdr.EntryUserID + "',convert(datetime,'" + Convert.ToDateTime(hdr.ModifiedDate) + "',103),'" + hdr.ModifiedUserID + "')";
            return sql;
        }

        public static bool SqlInsertDet(SqlCommand cmd, ClsRequisitionDetail det, List<ClsRequisitionDetail> itemdet)
        {
            string sql = "";
            bool retflag = true;

            foreach (ClsRequisitionDetail itm in itemdet)
            {
                sql = "INSERT INTO [ItemRequisitionDetail] ([ItemRequisitionNo],[InventoryItemID],[RequiredItemName],[RequestedQuantity],[FinalQuantity],[UnitID],[PossibleRate],[FinalRate],[CountryOfOrigin],[Specification],[Brand]) VALUES ('" + itm.ItemRequisitionNo + "'," + itm.InventoryItemID + ",'" + itm.RequiredItemName + "'," + itm.RequestedQuantity + "," + itm.FinalQuantity + "," + itm.UnitID + "," + itm.PossibleRate + "," + itm.FinalRate + ",'" + itm.CountryOfOrigin + "','" + itm.Specification + "','" + itm.Brand + "')";

                if (!DataProcess.ExecuteSqlCommand(cmd, sql))
                {
                    retflag = false;
                    goto errorhand;
                }
            }

        errorhand:
            return retflag;

        }

        public static string SqlInsertFileHdr(ClsFileUploadHeader filehdr)
        {
            string sql = "INSERT INTO [FileUploadHeader] ([CompanyID], [BranchID], [ReferenceNo],[FileCategoryID],[UploadedScreenName]) VALUES (" + filehdr.CompanyID + ", " + filehdr.BranchID + ", '" + filehdr.ReferenceNo + "'," + filehdr.FileCategoryID + ",'" + filehdr.UploadedScreenName + "')";
            return sql;
        }




        public static bool SqlInsertFileDet(SqlCommand cmd, ClsFileUploadDetail filedett, List<ClsFileUploadDetail> lstfileDet)
        {
            string sql = "";
            bool retflag = true;

            foreach (ClsFileUploadDetail file in lstfileDet)
            {
                sql = "INSERT INTO [FileUploadDetail] ([CompanyID],[BranchID],[FileID],[ReferenceNo],[FileType],[UserDefinedFileName],[OriginalFileName],[UploadedFilename],[FileLength],[UploadBy],[UploadDatetime],[RelativePath],[AbsolutePath],[DownloadLink]) VALUES (" + file.CompanyID + "," + file.BranchID + ",'" + file.FileID + "','" + file.ReferenceNo + "','" + file.FileType + "','" + file.UserDefinedFileName + "','" + file.OriginalFileName + "','" + file.UploadedFilename + "'," + file.FileLength + ",'" + file.UploadBy + "',convert(datetime,'" + file.UploadDateTime + "',103),'" + file.RelativePath + "','" + file.AbsolutePath + "','" + file.DownloadLink + "')";

                if (!DataProcess.ExecuteSqlCommand(cmd, sql))
                {
                    retflag = false;
                    goto errorhand;
                }
            }

        errorhand:
            return retflag;

        }

        public static bool DeleteRequisitionDetByRequisitionNo(SqlCommand cmd, ClsRequisitionDetail det)
        {
            string sql = "";
            bool retflag = true;


            sql = "Delete from  [ItemRequisitionDetail] where ItemRequisitionNo= '" + det.ItemRequisitionNo + "'";

            if (!DataProcess.ExecuteSqlCommand(cmd, sql))
            {
                retflag = false;
                goto errorhand;
            }


        errorhand:
            return retflag;

        }






        public static string SqlInsertDet(ClsRequisitionDetail det)
        {
            string sql;
            return sql = "INSERT INTO [ItemRequisitionDetail] ([ItemRequisitionNo],[InventoryItemID],[RequiredItemName],[RequestedQuantity],[FinalQuantity],[UnitID],[PossibleRate],[FinalRate],[CountryOfOrigin],[Specification],[Brand]) VALUES ('" + det.ItemRequisitionNo + "'," + det.InventoryItemID + ",'" + det.RequiredItemName + "'," + det.RequestedQuantity + "," + det.FinalQuantity + "," + det.UnitID + "," + det.PossibleRate + "," + det.FinalRate + ",'" + det.CountryOfOrigin + "','" + det.Specification + "','" + det.Brand + "')";

        }











        public static string GetDataFileDet(string requisitionNo)
        {
            return "SELECT * FROM  FileUploadDetail where ReferenceNo='" + requisitionNo + "'";
        }

        public static string GetDataRequisitionHdr(string requisitionNo)
        {
            return "SELECT * FROM  ItemRequisitionHeader where ItemRequisitionNo='" + requisitionNo + "'";
        }

        public static string GetDataRequisitionDet(string requisitionNo)
        {
            string sql = "   SELECT  det.InventoryItemID, det.RequiredItemName, det.RequestedQuantity, det.FinalQuantity, det.UnitID,"
             + " det.PossibleRate, det.FinalRate, det.CountryOfOrigin, det.Specification, det.Brand,  un.Unit FROM  ItemRequisitionDetail det"
             + " INNER JOIN  matUnitSetup un ON det.UnitID = un.UnitID where ItemRequisitionNo='" + requisitionNo + "'";

            return sql;
        }


        public static string GetDataByItemDet(int itemId)
        {
            return "  SELECT * FROM ItemRequisitionDetail where  InventoryItemID  =" + itemId + "";
        }

        public static string GetDataRequisitionAdvancedSearch(clsRequisitionHeader hdr, DateTime frmdate, DateTime todate, int item)
        {

            string sql = "";

            //   sql = "  select * from ItemRequisitionHeader hdr where hdr.BranchID=1 and hdr.CompanyID=1";



            sql = " SELECT ItemRequisitionHeader.ItemRequisitionNo,ItemRequisitionHeader.PriorityID,ItemRequisitionHeader.PurposeID,"
                    + " ItemRequisitionHeader.RequestedDepartmentID, ItemRequisitionHeader.CompanyID, ItemRequisitionHeader.BranchID,"
                    + " ItemRequisitionHeader.RequisitionBy as RequisitionID, ItemRequisitionHeader.RequisitionDate, ItemRequisitionHeader.RequiredDate,"
                    + " hrEmployeeSetup.FullName as RequisitionBy,oDepartmentSetup.DepartmentName,PrioritySetupActivityWise.PriorityName   FROM  ItemRequisitionHeader "

                    + " inner join hrEmployeeSetup on ItemRequisitionHeader.RequisitionBy =hrEmployeeSetup.EmployeeID "
                    + " inner join oDepartmentSetup on oDepartmentSetup.DepartmentID=ItemRequisitionHeader.RequestedDepartmentID "
                    + " inner join PrioritySetupActivityWise on PrioritySetupActivityWise.PriorityID=ItemRequisitionHeader.PriorityID where ItemRequisitionHeader.CompanyID=1 and ItemRequisitionHeader.BranchID=1";


            if (hdr.PriorityID != 0)
            {
                sql += " and ItemRequisitionHeader.PriorityID=" + hdr.PriorityID;

            }

            if (hdr.RequestedDepartment != "")
            {
                sql += " and ItemRequisitionHeader.RequestedDepartmentID='" + hdr.RequestedDepartment + "'";

            }


            if (hdr.PurposeID != 0)
            {

                sql += " and ItemRequisitionHeader.PurposeID=" + hdr.PurposeID;

            }

            if (hdr.RequisitionBy != "")
            {

                sql += " and ItemRequisitionHeader.RequisitionBy='" + hdr.RequisitionBy + "'";

            }

            if (item != 0)
            {

                string sss = System.Configuration.ConfigurationManager.ConnectionStrings["ItemRequisitionConString"].ToString();
                DataTable dt = new DataTable();
                dt = DataProcess.GetData(sss, SqlGenerateForItemRequisition.GetDataByItemDet(item));

                string aaaa = "";

                foreach (DataRow dr in dt.Rows)
                {

                    if (aaaa == "")
                    {

                        aaaa = "'" + dr["ItemRequisitionNo"].ToString() + "'";

                    }

                    else
                    {
                        aaaa += ",'" + dr["ItemRequisitionNo"].ToString() + "'";

                    }

                }

                sql += " and ItemRequisitionNo in (" + aaaa + ")";

            }


            if (frmdate != null)
            {

                sql += " and RequisitionDate between convert(datetime,'" + frmdate + "',103)";

            }

            if (todate != null)
            {

                sql += " and convert(datetime,'" + todate + "',103)";

            }

            else
            {

                return sql;


            }
            return sql;
        }





        public static string GetRequisitionList()
        {
            return "SELECT ItemRequisitionNo, RequisitionDate, RequisitionBy FROM  ItemRequisitionHeader";
        }


        public static string GetRequisitionListSearch(string keybal)
        {
            return "SELECT ItemRequisitionNo, RequisitionDate, RequisitionBy FROM  ItemRequisitionHeader where (ItemRequisitionNo Like '" + keybal + "')";
        }


        public static string GetDataMaxRequisitionIDByDate(DateTime requisitionDate)
        {
            return "select isnull( max(ItemRequisitionNo),0)  as ItemRequisitionMaxNo from ItemRequisitionHeader WHERE  RequisitionDate =convert(datetime,'" + requisitionDate + "',103) and CompanyID = 1 AND BranchID = 1";
        }





        //==================================================================================================



        public static string SqlFileAttachmentHdr(clsRequisitionHeader hdr)
        {
            string sql = "INSERT INTO [ItemRequisitionHeader] ([CompanyID], [BranchID], [ItemRequisitionNo],[RequisitionBy],[RequisitionDate],[RequiredDate],[RequestedDepartment],[UserType],[UserID],[LocationOfUse],[LocationAddress],[PriorityID],[PurposeID],[ReferenceTypeID],[ReferenceNumber],[ProjectID],[RequisitionCurrentStatus],[EntryDate],[EntryUserID],[ModifiedDate],[ModifiedUserID]) VALUES (" + hdr.CompanyID + ", " + hdr.BranchID + ", '" + hdr.ItemRequisitionNo + "','" + hdr.RequisitionBy + "',convert(datetime,'" + hdr.RequisitionDate + "',103),convert(datetime,'" + hdr.RequiredDate + "',103),'" + hdr.RequestedDepartment + "'," + hdr.UserType + ",'" + hdr.UserID + "'," + hdr.LocationOfUse + ",'" + hdr.LocationAddress + "'," + hdr.PriorityID + "," + hdr.PurposeID + "," + hdr.ReferenceTypeID + ",'" + hdr.ReferenceNumber + "','" + hdr.ProjectID + "'," + hdr.RequisitionCurrentStatus + ",convert(datetime,'" + hdr.EntryDate + "',103),'" + hdr.EntryUserID + "',convert(datetime,'" + Convert.ToDateTime(hdr.ModifiedDate) + "',103),'" + hdr.ModifiedUserID + "')";
            return sql;
        }

        public static bool SqlFileAttachmentDet(SqlCommand cmd, ClsRequisitionDetail det, List<ClsRequisitionDetail> itemdet)
        {
            string sql = "";
            bool retflag = true;

            foreach (ClsRequisitionDetail itm in itemdet)
            {
                sql = "INSERT INTO [ItemRequisitionDetail] ([ItemRequisitionNo],[InventoryItemID],[RequiredItemName],[RequestedQuantity],[FinalQuantity],[PossibleRate],[FinalRate],[CountryOfOrigin],[Specification],[Brand]) VALUES ('" + itm.ItemRequisitionNo + "'," + itm.InventoryItemID + ",'" + itm.RequiredItemName + "'," + itm.RequestedQuantity + "," + itm.FinalQuantity + "," + itm.PossibleRate + "," + itm.FinalRate + ",'" + itm.CountryOfOrigin + "','" + itm.Specification + "','" + itm.Brand + "')";

                if (!DataProcess.ExecuteSqlCommand(cmd, sql))
                {
                    retflag = false;
                    goto errorhand;
                }
            }

        errorhand:
            return retflag;

        }

        public static string SqlUpdateCompleteStatus(string requisitionID)
        {
            string sql = "UPDATE  ItemRequisitionHeader"
                    + " SET CompletionStatus =1, ModifiedDate = convert(datetime,'" + System.DateTime.Now.ToShortDateString() + "',103), ModifiedUserID ='a514f06e-0827-4a82-a39c-2b5336f293b8'"
                    + " WHERE (CompanyID =1) AND (BranchID =1) AND (ItemRequisitionNo ='" + requisitionID + "')";
            return sql;
        }
    }
}
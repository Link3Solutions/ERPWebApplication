using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class PeopleEntryController : DataAccessBase
    {
        internal void SavePeopleData(PeopleEntry objPeopleEntry)
        {
            try
            {
                var storedProcedureComandText = SqlSavePeopleHeader(objPeopleEntry);
                storedProcedureComandText += SqlSavePeopleAcademicDetails(objPeopleEntry);                
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlSavePeopleAcademicDetails(PeopleEntry objPeopleEntry)
        {
            try
            {
                string storedProcedureComandTextDetails = null;
                //if (objPeopleEntry != null)
                //{
                //    foreach (DataRow rowNo in objPeopleEntry)
                //    {
                        

                //        var storedProcedureComandTextDetailsTemp = @"INSERT INTO ;";
                //        storedProcedureComandTextDetails += storedProcedureComandTextDetailsTemp;

                //    }
                //}

                return storedProcedureComandTextDetails;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlSavePeopleHeader(PeopleEntry objPeopleEntry)
        {
            try
            {
                var storedProcedureComandText = @"INSERT INTO ;";
                return storedProcedureComandText;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetPeopleRecord()
        {
            throw new NotImplementedException();
        }

        internal void DeletePeopleRecord(PeopleEntry _objPeopleEntry)
        {
            throw new NotImplementedException();
        }

        internal DataTable GetPeopleRecord(PeopleEntry objPeopleEntry)
        {
            try
            {
                bool searchOption = true;
                searchOption = CheckSearchOption(objPeopleEntry);
                if ( searchOption == false)
                {
                    throw new Exception("Please select search option. ");
                }

                DataTable dtEmployee = null;
                var storedProcedureComandText = @"SELECT ...";

                if (objPeopleEntry.SearchOption1 != "-1")
                {
                    storedProcedureComandText += " AND .....";
                }

                if (objPeopleEntry.SearchOption2 != "-1")
                {
                    storedProcedureComandText += " AND .....";
                }

                if (objPeopleEntry.SearchOption3 != "-1")
                {
                    storedProcedureComandText += " AND .....";
                }

                if (objPeopleEntry.SearchOption4 != "-1")
                {
                    storedProcedureComandText += " AND .....";
                }

                storedProcedureComandText += " ORDER BY .....";

                dtEmployee = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtEmployee;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private bool CheckSearchOption(PeopleEntry objPeopleEntry)
        {
            try
            {
                bool tempSearchOption = true;
                if (objPeopleEntry.SearchOption1 == "-1")
                {
                    tempSearchOption = false;
                }
                else
                {
                    return tempSearchOption = true;
                }

                if (objPeopleEntry.SearchOption2 == "-1")
                {
                    tempSearchOption = false;
                }
                else
                {
                    return tempSearchOption = true;
                }

                if (objPeopleEntry.SearchOption3 == "-1")
                {
                    tempSearchOption = false;
                }
                else
                {
                    return tempSearchOption = true;
                }

                if (objPeopleEntry.SearchOption4 == "-1")
                {
                    tempSearchOption = false;
                }
                else
                {
                    return tempSearchOption = true;
                }

                return tempSearchOption;
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}
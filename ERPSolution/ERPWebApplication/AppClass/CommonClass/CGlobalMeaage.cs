﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.CommonClass
{
    public static class clsMessages
    {
        public static string GProcessSuccess = "Data processed successfully";
        public static string GConfirmMessage = "Are you sure ?";
        public static string GImageSize = "Image size should not be greater than 150X150 !";
        public static string GImageSizeBytes = "Image size not more than 500 kb!";
        public static string GLoginFail = "Your login attempt was not successful. Please try again.";
        public static string GWelcome = "Welcome, ";
        public static string GFullStop = ". ";
        public static string GYouAreAt = GFullStop+ "You are at ";
        public static string GNoDataFound = "No data found";
        public static string GNoNewDataFound = "No new data found";
        public static string GExist = "Already exist";
        public static string GDataFound = " data found";
        public static string GRecordFound = " record found";
        public static string GRecordsFound = " records found";
        public static string GYouareAddingData = "You are adding new record";
        public static string GYouareSearchingData = "You are searching.";
        public static string GYouDidnotSelectYet = "You didn't select any option.";
        public static string GYouareEditingRecord = "You are editing record";
        
    }
}
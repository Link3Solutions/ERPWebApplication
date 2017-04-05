using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class MailServiceSetup
    {
        private string _mailtypeID;

        public string MailtypeID
        {
            get { return _mailtypeID; }
            set { _mailtypeID = value; }
        }
        private string _mailTypeTitle;

        public string MailTypeTitle
        {
            get { return _mailTypeTitle; }
            set { _mailTypeTitle = value; }
        }
        private string _mailSubject;

        public string MailSubject
        {
            get { return _mailSubject; }
            set { _mailSubject = value; }
        }
        private string _mailBody;

        public string MailBody
        {
            get { return _mailBody; }
            set { _mailBody = value; }
        }
    }
}
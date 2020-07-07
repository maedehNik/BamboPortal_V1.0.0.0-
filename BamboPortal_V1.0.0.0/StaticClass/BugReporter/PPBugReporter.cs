using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BamboPortal_V1._0._0._0.BamboPortalSecurity.EncDec;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using MD.PersianDateTime;

namespace BamboPortal_V1._0._0._0.StaticClass.BugReporter
{
    public class PPBugReporter
    {
        public Exception EXOBJ { get; set; }
        private string excep { get; set; }
        public string CodeGenerated { get; set; }

        public string GetError
        {
            get { return excep; }
        }
        public PPBugReporter(BugTypeFrom TypeFrom, string ER = "")
        {
            if (string.IsNullOrEmpty(ER))
            {

                string excep = $"Exception.ToString() : {EXOBJ.ToString()}\n" +
                               $"InnerException.Message Type : {EXOBJ.InnerException.Message}";
            }
            else
            {
                excep = $"Exception.ToString() : {ER}";
                if(EXOBJ != null)
                {
                    excep += $"\nExceptionOBJ.ToString() : {EXOBJ.ToString()}\n" +
                               $"InnerException.Message Type : {EXOBJ.InnerException.Message}";
                }
            }
            string FolderName = Enum.GetName(typeof(BugTypeFrom), TypeFrom);
            string FromWhere = $"BugIN-{FolderName}";
            CodeGenerated = "ERX-" + DateTime.Now.Ticks.ToString();


            if (TypeFrom == BugTypeFrom.SQL)
            {
                EncDec endc = new EncDec();
                PDBC db = new PDBC();
                excep += $"\nConnectionString : {endc.EncryptText(db.CNGet)}";

            }





            try
            {
                if (Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/ErrorLogs")))
                {
                    if (Directory.Exists(System.Web.HttpContext.Current.Server.MapPath($"~/ErrorLogs/{FolderName}")))
                    {

                        File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath($"~/ErrorLogs/{FolderName}/ErrorOn({CodeGenerated}--{FromWhere})-{PersianDateTime.Now.Year}-{PersianDateTime.Now.Month}-{PersianDateTime.Now.Day}-{PersianDateTime.Now.Hour} {PersianDateTime.Now.Minute} {PersianDateTime.Now.Second}.Panda"), excep);

                    }
                    else
                    {
                        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath($"~/ErrorLogs/{FolderName}"));

                        File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath($"~/ErrorLogs/{FolderName}/ErrorOn({CodeGenerated}--{FromWhere})-{PersianDateTime.Now.Year}-{PersianDateTime.Now.Month}-{PersianDateTime.Now.Day}-{PersianDateTime.Now.Hour} {PersianDateTime.Now.Minute} {PersianDateTime.Now.Second}.Panda"), excep);
                    }
                }
                else
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/ErrorLogs"));
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath($"~/ErrorLogs/{FolderName}"));

                    File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath($"~/ErrorLogs/{FolderName}/ErrorOn({CodeGenerated}--{FromWhere})-{PersianDateTime.Now.Year}-{PersianDateTime.Now.Month}-{PersianDateTime.Now.Day}-{PersianDateTime.Now.Hour} {PersianDateTime.Now.Minute} {PersianDateTime.Now.Second}.Panda"), excep);
                }
            }
            catch { }
        }
    }

}
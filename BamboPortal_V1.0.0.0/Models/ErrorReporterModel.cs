using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Models
{
    public class ErrorReporterModel
    {
        public string  Errormessage { get; set; }
        public string ErrorID { get; set; }
        public string Errortype { get; set; }
        public List<ModelErrorReporter> AllErrors { set; get; }
        public string ImportantValsReturn { get; set; }
    }
    public class ModelErrorReporter
    {
        public string IdOfProperty { get; set; }
        public string ErrorMessage { get; set; }
    }

}
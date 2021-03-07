using System;
using System.Collections.Generic;
using System.Text;

namespace ERodMobileApp.Models
{
    public class UserSignature
    {
        public string SalesOrderID { get; set; }
        public string UserName { get; set; }
        public string SignaturePath { get; set; }
        public string SignatureByteArray { get; set; }
    }
}

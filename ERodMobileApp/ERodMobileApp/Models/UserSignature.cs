using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ERodMobileApp.Models
{
    public class UserSignature
    {
        [PrimaryKey]
        public string SalesOrderID { get; set; }
        public string ImageLivePath{ get; set; }
        public string ImageString { get; set; }
        public string Name { get; set; }
        //public string SignaturePath { get; set; }
        //public byte[] SignatureByteArray { get; set; }
    }
}

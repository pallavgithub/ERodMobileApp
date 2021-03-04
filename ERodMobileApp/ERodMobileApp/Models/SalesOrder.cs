using SQLite;
using System.Collections.Generic;

namespace ERodMobileApp.Models
{
    public class SalesOrder
    {
        public List<CustomDataField> CustomFields { get; set; }
        public string Id { get; set; }
        public string BillToAddress { get; set; }
        public string BillToCity { get; set; }
        public string BillToCountryId { get; set; }
        public string BillToName { get; set; }
        public string BillToStateId { get; set; }
        public string BillToZip { get; set; }
        public string CarrierId { get; set; }
        public string CarrierServiceId { get; set; }
        public string Cost { get; set; }
        public string CurrencyId { get; set; }
        public string CurrencyRate { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerId { get; set; }
        public string CustomerPO { get; set; }
        public string DateCompleted { get; set; }
        public string DateCreated { get; set; }
        public string DateExpired { get; set; }
        public string DateFirstShip { get; set; }
        public string DateIssued { get; set; }
        public string DateLastModified { get; set; }
        public string DateRevision { get; set; }
        public string Email { get; set; }
        public string EstimatedTax { get; set; }
        public string FobPointId { get; set; }
        public string LocationGroupId { get; set; }
        public string McTotalTax { get; set; }
        public string Note { get; set; }
        [PrimaryKey]
        public string Num { get; set; }
        public string PaymentTermsId { get; set; }
        public string Phone { get; set; }
        public string PriorityId { get; set; }
        public string QbClassId { get; set; }
        public string RegisterId { get; set; }
        public string ResidentialFlag { get; set; }
        public string RevisionNum { get; set; }
        public string Salesman { get; set; }
        public string SalesmanId { get; set; }
        public string SalesmanInitials { get; set; }
        public string ShipTermsId { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToCountryId { get; set; }
        public string ShipToName { get; set; }
        public string ShipToStateId { get; set; }
        public string ShipToZip { get; set; }
        public string StatusId { get; set; }
        public string TaxRate { get; set; }
        public string TaxRateId { get; set; }
        public string TaxRateName { get; set; }
        public string ToBeEmailed { get; set; }
        public string ToBePrinted { get; set; }
        public string TotalIncludesTax { get; set; }
        public string TotalTax { get; set; }
        public string SubTotal { get; set; }
        public string TotalPrice { get; set; }
        public string TypeId { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string VendorPO { get; set; }

        public SalesOrder()
        {
            CustomFields = new List<CustomDataField>();
        }
    }

    public class CustomDataField
    {
        //for foreign key
        public string  SalesOrderNum { get; set; }
        public string RecordId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

    }
}

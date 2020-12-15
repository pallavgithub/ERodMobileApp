using System.Collections.Generic;

namespace ERodMobileApp.Models
{
    public class SalesOrder
    {
        public List<Order> Orders { get; set; }
    }
    public class Order
    {
        public string Id { get; set; }
        public string Note { get; set; }
        public string TotalPrice { get; set; }
        public string TotalTax { get; set; }
        public string EstimatedTax { get; set; }
        public string ItemTotal { get; set; }
        public string Salesman { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string Carrier { get; set; }
        public string FirstShipDate { get; set; }
        public string CreatedDate { get; set; }
        public string IssuedDate { get; set; }
        public string TaxRateName { get; set; }
        public string ShippingTerms { get; set; }
        public string PaymentTerms { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string Fob { get; set; }
        public string QuickBooksClassName { get; set; }
        public string LocationGroup { get; set; }
        public string PoNum { get; set; }
        public string PriorityId { get; set; }
        public bool PriceIsHomeCurrency { get; set; }
        public BillTo BillTo { get; set; }
        public BillTo Ship { get; set; }
        public string VendorPo { get; set; }
        public string CustomerPo { get; set; }
        public string TypeId { get; set; }
        public string Url { get; set; }
        public string Cost { get; set; }
        public string DateCompleted { get; set; }
        public string DateLastModified { get; set; }
        public string SalesmanInitials { get; set; }
        public CustomField[] CustomFields { get; set; }
        public Items Items { get; set; }
    }
    public class BillTo
    {
        public string Name { get; set; }
        public string AddressField { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
    public class Ship
    {
        public string Name { get; set; }
        public string AddressField { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
    public class CustomField
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
    }
    public class Items
    {
        public SalesOrderItem SalesOrderItem { get; set; }
    }
    public class SalesOrderItem
    {
        public string Id { get; set; }
        public string ProductNumber { get; set; }
        public string Soid { get; set; }
        public string Description { get; set; }
        public string CustomerPartNum { get; set; }
        public bool Taxable { get; set; }
        public string Quantity { get; set; }
        public string ProductPrice { get; set; }
        public string TotalPrice { get; set; }
        public string UomCode { get; set; }
        public string ItemType { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string QuickBooksClassName { get; set; }
        public bool NewItemFlag { get; set; }
        public string LineNumber { get; set; }
        public bool ShowItemFlag { get; set; }
        public string AdjustmentAmount { get; set; }
        public string AdjustPercentage { get; set; }
        public string DateLastFulfillment { get; set; }
        public string DateLastModified { get; set; }
        public string DateScheduledFulfillment { get; set; }
        public string QtyFulfilled { get; set; }
        public string QtyPicked { get; set; }
        public string RevisionLevel { get; set; }
        public string TotalCost { get; set; }
    }
}

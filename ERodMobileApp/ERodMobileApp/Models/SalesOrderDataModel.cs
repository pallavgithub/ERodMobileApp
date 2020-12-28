using System.Collections.Generic;

namespace ERodMobileApp.Models
{
    public class SalesOrderDataModel
    {
        public string OrderID { get; set; }
        public string SOId { get; set; }
        public string Status { get; set; }
        public string OrderTime { get; set; }
        public string WellName { get; set; }
        public string Customer { get; set; }
        public string Phone { get; set; }
        public string Engineer { get; set; }
        public string GlCode { get; set; }

        public string ShippingName { get; set; }
        public string AddressField { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string DeliveryTime { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
    public class OrderItem
    {
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
    }
    public class Shipping
    {
       
    }
}

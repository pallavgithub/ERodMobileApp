using System.Collections.Generic;

namespace ERodMobileApp.Models
{
    public class SalesOrderModel
    {
        public string SalesOrderId { get; set; }
        public string WellName { get; set; }
        public string CreatedDateAndTime { get; set; }
        public string Status { get; set; }
        public string StatusInDetail { get; set; }
        //ShippingInfo
        public string DeliveryDateAndTime { get; set; }
        public string TruckingCo { get; set; }
        public string DriverPhone { get; set; }
        public string DriverName { get; set; }
        //OrderInfo
        public string OrderId { get; set; }
        public string Customer { get; set; }
        public string Consultant { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Engineer { get; set; }
        public string AFE { get; set; }
        public string GlCode { get; set; }
        public string Note { get; set; }
        public List<CustomDataField> CustomFields { get; set; }
        public List<SalesOrderItemModel> SOItems { get; set; }
    }
}

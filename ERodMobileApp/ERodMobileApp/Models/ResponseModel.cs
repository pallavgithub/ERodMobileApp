namespace ERodMobileApp.Models
{
    public class ResponseModel<T>
    {
        public T data { get; set; }
        public string status { get; set; } // 1 ok, 0 failure
        public string message { get; set; }
    }
}

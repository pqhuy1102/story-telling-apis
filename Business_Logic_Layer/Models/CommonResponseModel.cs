namespace Business_Logic_Layer.Models
{
    public class CommonResponseModel<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public T? Data { get; set; }
    }
}

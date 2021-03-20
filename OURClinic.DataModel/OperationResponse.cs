namespace OurCart.DataModel
{
    public class OperationResponse<T>
    {
        public bool HasErrors { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

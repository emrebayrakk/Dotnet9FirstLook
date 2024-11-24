namespace FirstLook.Response
{
    public class ResponseData<T>
    {
        public int Code { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ResponseData(
            bool status,
            int code,
            string message,
            T data)
        {
            Code = code;
            Status = status;
            Message = message;
            Data = data;
        }
    }
}

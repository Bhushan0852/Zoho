namespace Zoho.Comman
{
    public class ApiResponse<T> : Response where T : class
    {
        public T Data { get; set; }
    }

    public class ApiResponse : Response
    {
        public dynamic Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(string Message, bool status = false)
        {
            IsSuccessful = status;
            Errors.Add(Message);
        }
        public ApiResponse(List<string> Messages, bool status = false)
        {
            IsSuccessful = status;
            Errors.AddRange(Messages);
        }
    }
}
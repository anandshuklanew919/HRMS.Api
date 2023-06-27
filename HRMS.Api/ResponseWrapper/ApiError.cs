namespace HRMS.Api.ResponseWrapper
{
    public class ApiError : ApiResponse
    {
        public string Details { get; set; }
        public ApiError(int statusCode, string message = null, string deatails = null) : base(statusCode,message)
        {
            Details = Details;
        }
    }
}

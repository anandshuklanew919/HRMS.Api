using System.Net;

namespace HRMS.Api.ResponseWrapper
{
    public class HrmsApiResponse
    {
        public static ApiValidationErrorResponse ValidationResponse(IEnumerable<string> errors)
        {
            ApiValidationErrorResponse apiValidationErrorResponse = new ApiValidationErrorResponse();
            apiValidationErrorResponse.Errors = errors;
            return apiValidationErrorResponse;
        }


        public static ApiValidationErrorResponse ValidationResponse(string errors)
        {
            ApiValidationErrorResponse apiValidationErrorResponse = new ApiValidationErrorResponse();
            apiValidationErrorResponse.Errors = new List<string> { errors };
            return apiValidationErrorResponse;
        }


        public static ApiError ErrorResponse( HttpStatusCode httpStatusCode, string message, string deatails = null)
        {
            ApiError apiError = new ApiError((int)httpStatusCode, message, deatails);
            return apiError;
        }

    }
}

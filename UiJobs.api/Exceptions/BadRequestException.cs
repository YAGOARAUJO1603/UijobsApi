using System.Net;
using UIJobsAPI.Exceptions;

namespace UijobsApi.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) :
            base
            (
                "UIJOBS:002",
                message,
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                DateTimeOffset.UtcNow,
                null
            )
        { }

        public BadRequestException(string message, Exception ex) :
            base
            (
                "UIJOBS:002",
                message,
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                DateTimeOffset.UtcNow,
                ex
            )
        { }
    }
}

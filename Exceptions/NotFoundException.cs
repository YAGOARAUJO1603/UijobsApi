using System.Net;

namespace UIJobsAPI.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string resource) :
            base
            (
                "UIJOBS:001",
                $"{resource} not found",
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                DateTimeOffset.UtcNow,
                null
            )
        { }

        public NotFoundException(string message, Exception ex) :
            base
            (
                "UIJOBS:001",
                message,
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                DateTimeOffset.UtcNow,
                ex
            )
        { }
    }
}

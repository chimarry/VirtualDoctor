namespace AmbulanceDatabase.ErrorCodeHandling
{
    public class ErrorHandlerFactory
    {
        public static IErrorHandling CreateErrorHandler()
        {
            return new ErrorCodeHandling.ErrorCodeHandler();
        }
    }
}

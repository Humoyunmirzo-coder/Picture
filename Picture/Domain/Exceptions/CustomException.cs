namespace Domain.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string Messeg { get; set; }
        public CustomException(int statuscode, string messeg)
        {
            StatusCode = statuscode;
            Messeg = messeg;

        }
    }
}

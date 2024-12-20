using System.Globalization;

namespace exp.Template.Models.Helpers
{
 
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
    public class InvalidTenantException : Exception
    {
        public InvalidTenantException() : base() { }

        public InvalidTenantException(string message) : base(message) { }

        public InvalidTenantException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
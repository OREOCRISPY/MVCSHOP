using System;
namespace ApplicationCore.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(String message):base(message)
        {
        }
    }
}

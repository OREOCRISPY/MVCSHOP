using System;
namespace ApplicationCore.Exceptions
{
    public class ConflictException:Exception
    {
        public ConflictException(String message):base(message)
        {
        }
    }
}

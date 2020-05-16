using System;
namespace ecommercecase.Domain.Exceptions
{
    public class CommandException: Exception
    {
        public string FriendlyMessage { get; set; }
        public CommandException(int errCode,string exMessage): base (exMessage)
        {
            FriendlyMessage = $"{errCode}: {exMessage}";
        }
    }
}

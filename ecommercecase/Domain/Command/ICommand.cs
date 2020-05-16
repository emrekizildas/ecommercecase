using System;
namespace ecommercecase.Domain.Command
{
    public interface ICommand: IEntity
    {
        string Run();
    }
}

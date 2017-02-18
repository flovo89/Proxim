namespace Proxim.Phone.Core.Interfaces.ServiceInterfaces
{
    public interface IDialogService : IService
    {
        void Alert (string message, string btnText);
    }
}

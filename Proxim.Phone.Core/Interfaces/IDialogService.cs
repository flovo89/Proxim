namespace Proxim.Phone.Core.Interfaces
{
    public interface IDialogService : IService
    {
        void Alert (string message, string btnText);
    }
}

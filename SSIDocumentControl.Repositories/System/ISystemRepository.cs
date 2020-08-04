using System.Threading.Tasks;

namespace SSIDocumentControl.Repositories.System
{
    public interface ISystemRepository
    {
        Task LogSignIn(string url, int userId);
    }
}
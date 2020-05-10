using System.Threading.Tasks;

namespace ZrakPizza.Services
{
    public interface IAuthService
    {
        Task<string> GenerateToken(string username, string password);
    }
}

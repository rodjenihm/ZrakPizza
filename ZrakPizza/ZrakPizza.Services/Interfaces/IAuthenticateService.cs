using System.Threading.Tasks;

namespace ZrakPizza.Services
{
    public interface IAuthenticateService
    {
        Task<string> GenerateToken(string username, string password);
    }
}

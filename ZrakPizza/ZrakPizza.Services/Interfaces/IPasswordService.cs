namespace ZrakPizza.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(string providedPassword, string hashedPassword);
    }
}

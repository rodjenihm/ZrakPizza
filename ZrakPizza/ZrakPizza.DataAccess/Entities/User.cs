namespace ZrakPizza.DataAccess.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
    }
}

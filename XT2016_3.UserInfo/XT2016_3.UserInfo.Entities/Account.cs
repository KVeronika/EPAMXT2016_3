namespace XT2016_3.UserInfo.Entities
{
    public class Account
    {
        public Account(int id, string login)
        {
            this.Id = id;
            this.Login = login;
        }

        public Account(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
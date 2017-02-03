namespace XT2016_3.Auction.Entities
{
    public class User
    {
        public User(int id, string login)
        {
            this.Id = id;
            this.Login = login;
        }

        public User(string login, string password)
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
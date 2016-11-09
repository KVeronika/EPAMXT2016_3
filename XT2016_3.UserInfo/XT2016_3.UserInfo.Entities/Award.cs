namespace XT2016_3.UserInfo.Entities
{
    public class Award
    {
        public Award(string title)
        {
            this.Title = title;
        }

        public Award(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; }

        public string Title { get; set; }
    }
}
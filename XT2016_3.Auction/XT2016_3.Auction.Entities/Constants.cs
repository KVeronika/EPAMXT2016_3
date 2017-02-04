using System.Configuration;

namespace XT2016_3.Auction.Entities
{
    public class Constants
    {
        public const string KeyOfDal = "typeOfDal";
        public const string FileDal = "file";
        public const string SqlDal = "sql";
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public static readonly string userRoleName = "user";
        public static readonly string adminRoleName = "admin";
        public static readonly decimal rateStep = 0.001m;
        public static readonly string defaultDescription = "...";
    }
}
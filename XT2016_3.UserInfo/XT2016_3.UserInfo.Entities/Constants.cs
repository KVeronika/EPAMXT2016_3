using System.Configuration;

namespace XT2016_3.UserInfo.Entities
{
    public class Constants
    {
        public const string DateOfBirthFormat = "MM-dd-yyyy";
        public const string KeyOfDal = "typeOfDal";
        public const string FileDal = "file";
        public const string SqlDal = "sql";
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public static readonly int maxWidth = int.Parse(ConfigurationManager.AppSettings["image:maxwidth"]);
        public static readonly int maxHeight = int.Parse(ConfigurationManager.AppSettings["image:maxheight"]);
        public static readonly string userRoleName = "user";
        public static readonly string adminRoleName = "admin";
    }
}
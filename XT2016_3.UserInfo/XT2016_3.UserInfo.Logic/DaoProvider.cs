using System.Configuration;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.FileDal;
using XT2016_3.UserInfo.SqlDal;

namespace XT2016_3.UserInfo.Logic
{
    internal static class DaoProvider
    {
        static DaoProvider()
        {
            string typeOfDal = ConfigurationManager.AppSettings[Entities.Constants.KeyOfDal];
            if (typeOfDal.Equals(Entities.Constants.FileDal))
            {
                UserDao = new FileUserDao();
                AwardDao = new FileAwardDao();
                UserAwardDao = new FileUserAwardDao();
            }
            if (typeOfDal.Equals(Entities.Constants.SqlDal))
            {
                UserDao = new SqlUserDao();
                AwardDao = new SqlAwardDao();
                UserAwardDao = new SqlUserAwardDao();
                ImageDao = new SqlImageDao();
                AccountDao = new SqlAccountDao();
            }
        }

        public static IUserDao UserDao { get; }

        public static IAwardDao AwardDao { get; }

        public static IUserAwardDao UserAwardDao { get; }

        public static IImageDao ImageDao { get; }

        public static IAccountDao AccountDao { get; set; }
    }
}
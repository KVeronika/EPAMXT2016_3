using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.FileDal;

namespace XT2016_3.UserInfo.Logic
{
    internal static class DaoProvider
    {
        static DaoProvider()
        {
            string typeOfDal = SettingsFromConfig.ReadSetting(Entities.Constants.KeyOfDal);
            if (typeOfDal.Equals(Entities.Constants.FileDal))
            {
                UserDao = new FileUserDao();
            }

            AwardDao = new FileAwardDao();
            UserAwardDao = new FileUserAwardDao();
        }

        public static IUserDao UserDao { get; }

        public static IAwardDao AwardDao { get; }

        public static IUserAwardDao UserAwardDao { get; }
    }
}
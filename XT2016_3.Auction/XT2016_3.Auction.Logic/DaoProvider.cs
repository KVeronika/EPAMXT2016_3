using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.SqlDao;
using System.Configuration;

namespace XT2016_3.Auction.Logic
{
    internal static class DaoProvider
    {
        static DaoProvider()
        {
            string typeOfDal = ConfigurationManager.AppSettings[Entities.Constants.KeyOfDal];
            if (typeOfDal.Equals(Entities.Constants.SqlDal))
            {
                UserDao = new SqlUserDao();
                ProductDao = new SqlProductDao();
                ImageDao = new SqlImageDao();
                RateDao = new SqlRateDao();
            }
        }

        public static IUserDao UserDao { get; }

        public static IProductDao ProductDao { get; }

        public static IImageDao ImageDao { get; }

        public static IRateDao RateDao { get; }
    }
}
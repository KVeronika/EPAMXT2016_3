using XT2016_3.Auction.Logic;
using XT2016_3.Auction.LogicContracts;

namespace XT2016_3.Auction.WebUI.Models
{
    public class LogicProvider
    {
        private static IUserLogic userLogic = new UserLogic();

        private static IProductLogic awardLogic = new ProductLogic();

        private static IImageLogic imageLogic = new ImageLogic();

        private static IRateLogic rateLogic = new RateLogic();

        public static IUserLogic UserLogic
        {
            get { return userLogic; }
        }

        public static IProductLogic ProductLogic
        {
            get { return awardLogic; }
        }

        public static IImageLogic ImageLogic
        {
            get { return imageLogic; }
        }

        public static IRateLogic RateLogic
        {
            get { return rateLogic; }
        }
    }
}
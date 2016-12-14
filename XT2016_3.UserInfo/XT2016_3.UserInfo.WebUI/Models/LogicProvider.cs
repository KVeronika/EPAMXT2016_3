using XT2016_3.UserInfo.Logic;
using XT2016_3.UserInfo.LogicContracts;

namespace XT2016_3.UserInfo.WebUI.Models
{
    public class LogicProvider
    {
        private static IUserLogic userLogic = new UserLogic();

        private static IAwardLogic awardLogic = new AwardLogic();

        private static IImageLogic imageLogic = new ImageLogic();

        private static IAccountLogic accountLogic = new AccountLogic();

        public static IUserLogic UserLogic
        {
            get { return userLogic; }
        }

        public static IAwardLogic AwardLogic
        {
            get { return awardLogic; }
        }

        public static IImageLogic ImageLogic
        {
            get { return imageLogic; }
        }

        public static IAccountLogic AccountLogic
        {
            get { return accountLogic; }
        }
    }
}
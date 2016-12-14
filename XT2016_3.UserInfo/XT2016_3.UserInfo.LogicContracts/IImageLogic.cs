using System.Drawing;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.LogicContracts
{
    public interface IImageLogic
    {
        ImageData GetThumbnail(int id);
        bool AddImageToUser(int userId, ImageInfo info, Image image);
        bool EditImageToUser(int userId, ImageInfo info, Image image);
        bool AddImageToAward(int awardId, ImageInfo info, Image image);
        bool EditImageToAward(int awardId, ImageInfo info, Image image);
    }
}
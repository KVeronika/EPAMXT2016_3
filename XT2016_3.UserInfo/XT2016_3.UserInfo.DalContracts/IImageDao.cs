using System.Drawing;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.DalContracts
{
    public interface IImageDao
    {
        int GetIdByData(byte[] data);
        bool Add(ImageInfo info, Image image);
        bool AddImageToUser(int userId, int imageId);
        bool AddImageToAward(int awardId, int imageId);
        ImageData GetThumbnail(int id);
        int GetUserImage(int userId);
        int GetAwardImage(int awardId);
    }
}
using System.Drawing;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.DaoContracts
{
    public interface IImageDao
    {
        int GetIdByData(byte[] data);

        bool Add(ImageData data);

        bool AddImageToProduct(int productId, int imageId);

        int GetProductImage(int productId);

        ImageData GetData(int id);
    }
}
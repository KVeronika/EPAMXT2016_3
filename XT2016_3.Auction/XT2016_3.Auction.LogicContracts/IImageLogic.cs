using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.LogicContracts
{
    public interface IImageLogic
    {
        ImageData GetData(int id);

        bool AddImageToProduct(int productId, ImageData data);

        bool EditImageToProduct(int productId, ImageData data);
    }
}
using System.Collections.Generic;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.LogicContracts
{
    public interface IRateLogic
    {
        bool Add(int userId, int productId, decimal rate);

        bool BuyNow(int userId, int productId);

        IEnumerable<Product> GetAllFinished(int userId);

        IEnumerable<Rate> GetAllForUser(int userId);
    }
}
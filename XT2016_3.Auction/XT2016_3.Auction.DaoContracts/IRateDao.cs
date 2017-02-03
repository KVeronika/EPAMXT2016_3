using System.Collections.Generic;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.DaoContracts
{
    public interface IRateDao
    {
        bool Add(int userId, int productId, decimal rate);

        IEnumerable<Rate> GetAll();
    }
}
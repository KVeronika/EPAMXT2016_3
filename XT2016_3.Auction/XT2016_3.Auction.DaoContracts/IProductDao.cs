using System.Collections.Generic;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.DaoContracts
{
    public interface IProductDao
    {
        bool Add(Product product);

        bool DeleteForUser(int userId, int productId);

        bool Edit(Product product);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAllForUser(int userId);

        Product GetById(int id);

        bool AddProductToUser(int userId, int productId);

        bool DeleteForAdmin(int productId);
    }
}
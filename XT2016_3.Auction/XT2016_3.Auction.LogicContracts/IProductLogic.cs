using System.Collections.Generic;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.LogicContracts
{
    public interface IProductLogic
    {
        bool Add(Product product);

        bool AddProductToUser(int userId, int productId);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAllForUser(int userId);

        Product GetById(int productId);

        int GetProductImage(int productId);

        IEnumerable<Product> Search(string name);

        bool DeleteForUser(int userId, int productId);

        bool DeleteForAdmin(int productId);

        bool Edit(Product product);
    }
}
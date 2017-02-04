using System;
using System.Collections.Generic;
using System.Linq;
using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.Entities;
using XT2016_3.Auction.LogicContracts;

namespace XT2016_3.Auction.Logic
{
    public class ProductLogic : IProductLogic
    {
        private IProductDao productDao;
        private IImageDao imageDao;
        private IValidator validator;

        public ProductLogic()
        {
            this.productDao = DaoProvider.ProductDao;
            this.imageDao = DaoProvider.ImageDao;
            this.validator = new Validator();
        }

        public bool Add(Product product)
        {
            try
            {
                if (!validator.IsValidNameProduct(product.Name)
                    || !validator.IsValidRate(product.CurrentRate)
                    || !validator.IsValidEndingDate(product.EndingDate))
                {
                    return false;
                }
                if (!validator.IsValidDescriptionProduct(product.Description))
                {
                    product.Description = Constants.defaultDescription;
                }
                return this.productDao.Add(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool AddProductToUser(int userId, int productId)
        {
            try
            {
                if (!validator.IsValidId(userId) || !validator.IsValidId(productId))
                {
                    return false;
                }
                return this.productDao.AddProductToUser(userId, productId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return this.productDao.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetAllForUser(int userId)
        {
            try
            {
                if (!validator.IsValidId(userId))
                {
                    return Enumerable.Empty<Product>();
                }
                return this.productDao.GetAllForUser(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetProductImage(int productId)
        {
            try
            {
                if (!validator.IsValidId(productId))
                {
                    return -1;
                }
                return this.imageDao.GetProductImage(productId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> Search(string name)
        {
            try
            {
                return this.productDao.GetAll()
                .Where(n => n.Name.IndexOf(name, 0, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteForUser(int userId, int productId)
        {
            try
            {
                if (!validator.IsValidId(userId) || !validator.IsValidId(productId))
                {
                    return false;
                }
                return this.productDao.DeleteForUser(userId, productId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteForAdmin(int productId)
        {
            try
            {
                if (!validator.IsValidId(productId))
                {
                    return false;
                }
                return this.productDao.DeleteForAdmin(productId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Edit(Product product)
        {
            try
            {
                if (!validator.IsValidId(product.Id)
                    || !validator.IsValidNameProduct(product.Name)
                    || !validator.IsValidRate(product.CurrentRate))
                {
                    return false;
                }
                if (!validator.IsValidDescriptionProduct(product.Description))
                {
                    product.Description = Constants.defaultDescription;
                }
                Product oldProduct = this.productDao.GetById(product.Id);
                if (!product.Name.Equals(oldProduct.Name) || !product.Description.Equals(oldProduct.Description)
                    || product.CurrentRate != oldProduct.CurrentRate || product.BuyNow != oldProduct.BuyNow
                    || product.EndingDate != oldProduct.EndingDate)
                {
                    return this.productDao.Edit(product);
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Product GetById(int productId)
        {
            try
            {
                return this.GetAll().Where(product => product.Id == productId).First();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
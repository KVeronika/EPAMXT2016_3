using System;
using System.Collections.Generic;
using System.Linq;
using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.Entities;
using XT2016_3.Auction.LogicContracts;

namespace XT2016_3.Auction.Logic
{
    public class RateLogic : IRateLogic
    {
        private IProductDao productDao;
        private IRateDao rateDao;
        private IValidator validator;

        public RateLogic()
        {
            this.productDao = DaoProvider.ProductDao;
            this.rateDao = DaoProvider.RateDao;
            this.validator = new Validator();
        }

        public bool Add(int userId, int productId, decimal rate)
        {
            try
            {
                if (!validator.IsValidId(userId)
                    || !validator.IsValidId(productId)
                    || !validator.IsValidRate(rate))
                {
                    return false;
                }
                Product product = this.productDao.GetById(productId);
                if (rate - product.CurrentRate < Constants.rateStep)
                {
                    return false;
                }
                product.CurrentRate = rate;
                this.productDao.Edit(product);
                return this.rateDao.Add(userId, productId, rate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool BuyNow(int userId, int productId)
        {
            try
            {
                if (!validator.IsValidId(userId) || !validator.IsValidId(productId))
                {
                    return false;
                }
                Product product = this.productDao.GetById(productId);
                product.EndingDate = DateTime.Now;
                this.productDao.Edit(product);
                return this.rateDao.Add(userId, productId, product.CurrentRate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Rate> GetAllForUser(int userId)
        {
            try
            {
                if (!validator.IsValidId(userId))
                {
                    return Enumerable.Empty<Rate>();
                }
                return this.rateDao.GetAll().Where(rate => rate.UserId == userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetAllFinished(int userId)
        {
            try
            {
                var products = new List<Product>();
                if (!validator.IsValidId(userId))
                {
                    return Enumerable.Empty<Product>();
                }
                List<Rate> rates = new List<Rate>(this.rateDao.GetAll().Where(rate => rate.UserId == userId));
                List<Rate> uniqueProductRate = new List<Rate>();
                foreach (var rate in rates)
                {
                    if (uniqueProductRate.Any(temp => temp.UserId == rate.UserId
                        && temp.ProductId == rate.ProductId
                        && temp.Cost < rate.Cost))
                    {
                        uniqueProductRate.Find(temp => temp.UserId == rate.UserId
                                               && temp.ProductId == rate.ProductId
                                               && temp.Cost < rate.Cost).Cost = rate.Cost;
                    }
                    else
                    {
                        uniqueProductRate.Add(rate);
                    }
                }
                foreach (var rate in uniqueProductRate)
                {
                    int productId = rate.ProductId;
                    Product product = this.productDao.GetById(productId);
                    if (product.EndingDate < DateTime.Now
                        && product.CurrentRate == uniqueProductRate.Find(x => x.ProductId == productId).Cost)
                    {
                        products.Add(product);
                    }
                }
                return products;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
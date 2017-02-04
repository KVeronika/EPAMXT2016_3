using System;
using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.Entities;
using XT2016_3.Auction.LogicContracts;

namespace XT2016_3.Auction.Logic
{
    public class ImageLogic : IImageLogic
    {
        private IImageDao imageDao;
        private IValidator validator;

        public ImageLogic()
        {
            this.imageDao = DaoProvider.ImageDao;
            this.validator = new Validator();
        }

        public bool AddImageToProduct(int productId, ImageData data)
        {
            try
            {
                if (!validator.IsValidId(productId) || !validator.IsValidImageData(data))
                {
                    return false;
                }
                int imageId = this.GetIdByData(data);
                if (imageId < 0)
                {
                    this.imageDao.Add(data);
                    imageId = this.GetIdByData(data);
                }
                this.imageDao.AddImageToProduct(productId, imageId);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private int GetIdByData(ImageData data)
        {
            try
            {
                if (!validator.IsValidImageData(data))
                {
                    return -1;
                }
                return this.imageDao.GetIdByData(data.Data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EditImageToProduct(int productId, ImageData data)
        {
            try
            {
                if (!validator.IsValidId(productId) || !validator.IsValidImageData(data))
                {
                    return false;
                }
                int imageId = this.imageDao.GetIdByData(data.Data);
                int userImageId = this.imageDao.GetProductImage(productId);
                if (imageId < 0)
                {
                    this.imageDao.Add(data);
                    imageId = this.imageDao.GetIdByData(data.Data);
                }
                if (userImageId != imageId)
                {
                    this.imageDao.AddImageToProduct(productId, imageId);
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ImageData GetData(int id)
        {
            try
            {
                if (!validator.IsValidId(id))
                {
                    return null;
                }
                return this.imageDao.GetData(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
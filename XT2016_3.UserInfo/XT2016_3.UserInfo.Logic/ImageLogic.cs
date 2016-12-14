using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;
using XT2016_3.UserInfo.LogicContracts;

namespace XT2016_3.UserInfo.Logic
{
    public class ImageLogic : IImageLogic
    {
        private IImageDao imageDao;

        public ImageLogic()
        {
            this.imageDao = DaoProvider.ImageDao;
        }

        public ImageData GetThumbnail(int id)
        {
            return this.imageDao.GetThumbnail(id);
        }

        public bool AddImageToUser(int userId, ImageInfo info, Image image)
        {
            try
            {
                int imageId = this.GetIdByData(info, image);
                if (imageId < 0)
                {
                    this.imageDao.Add(info, image);
                }
                this.imageDao.AddImageToUser(userId, imageId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private int GetIdByData(ImageInfo info, Image image)
        {
            var memStr = new MemoryStream();
            image.Save(memStr, ImageFormat.Png);
            byte[] data = memStr.ToArray();
            info.Id = this.imageDao.GetIdByData(data);
            return info.Id;
        }

        public bool EditImageToUser(int userId, ImageInfo info, Image image)
        {
            var memStr = new MemoryStream();
            image.Save(memStr, ImageFormat.Png);
            byte[] data = memStr.ToArray();
            int imageId = this.imageDao.GetIdByData(data);
            int userImageId = this.imageDao.GetUserImage(userId);
            if (imageId < 0)
            {
                this.imageDao.Add(info, image);
                imageId = this.imageDao.GetIdByData(data);
            }
            if (userImageId != imageId)
            {
                this.imageDao.AddImageToUser(userId, imageId);
            }
            return true;
        }

        public bool AddImageToAward(int awardId, ImageInfo info, Image image)
        {
            try
            {
                int imageId = this.GetIdByData(info, image);
                if (imageId < 0)
                {
                    this.imageDao.Add(info, image);
                }
                this.imageDao.AddImageToAward(awardId, imageId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditImageToAward(int awardId, ImageInfo info, Image image)
        {
            var memStr = new MemoryStream();
            image.Save(memStr, ImageFormat.Png);
            byte[] data = memStr.ToArray();
            int imageId = this.imageDao.GetIdByData(data);
            int awardImageId = this.imageDao.GetAwardImage(awardId);
            if (imageId < 0)
            {
                this.imageDao.Add(info, image);
                imageId = this.imageDao.GetIdByData(data);
            }
            if (awardImageId != imageId)
            {
                this.imageDao.AddImageToAward(awardId, imageId);
            }
            return true;
        }
    }
}
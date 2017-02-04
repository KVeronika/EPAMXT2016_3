using System;
using XT2016_3.Auction.Entities;
using XT2016_3.Auction.LogicContracts;

namespace XT2016_3.Auction.Logic
{
    public class Validator : IValidator
    {
        public bool IsValidDescriptionProduct(string description)
        {
            return !string.IsNullOrWhiteSpace(description);
        }

        public bool IsValidEndingDate(DateTime date)
        {
            return (date > DateTime.Now);
        }

        public bool IsValidId(int id)
        {
            return id > 0;
        }

        public bool IsValidImageData(ImageData data)
        {
            return (!(data.Data.Length == 0) || !string.IsNullOrEmpty(data.ContentType));
        }

        public bool IsValidNameProduct(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password);
        }

        public bool IsValidRate(decimal rate)
        {
            return rate > 0;
        }

        public bool IsValidRoleName(string name)
        {
            return (string.Equals(name, Constants.adminRoleName) || string.Equals(name, Constants.userRoleName));
        }

        public bool IsValidUserLogin(string login)
        {
            return !string.IsNullOrWhiteSpace(login);
        }
    }
}
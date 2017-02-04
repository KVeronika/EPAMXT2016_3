using System;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.LogicContracts
{
    public interface IValidator
    {
        bool IsValidId(int id);

        bool IsValidImageData(ImageData data);

        bool IsValidNameProduct(string name);

        bool IsValidDescriptionProduct(string description);

        bool IsValidRate(decimal rate);

        bool IsValidEndingDate(DateTime date);

        bool IsValidUserLogin(string login);

        bool IsValidPassword(string password);

        bool IsValidRoleName(string name);
    }
}
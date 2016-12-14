using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.LogicContracts
{
    public interface IAwardLogic
    {
        Award Add(string title);

        Award Edit(int awardId, string oldTitle, string newTitle);

        bool Delete(int idForDelete);

        Award[] GetAll();

        int GetAwardImage(int awardId);
    }
}
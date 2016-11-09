using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.LogicContracts
{
    public interface IAwardLogic
    {
        Award Add(string title);

        Award[] GetAll();
    }
}
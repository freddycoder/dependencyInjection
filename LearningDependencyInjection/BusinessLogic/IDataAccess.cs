namespace LearningDependencyInjection.BusinessLogic
{
    public interface IDataAccess
    {
        void LoadData();
        void SaveData(string name);
    }
}
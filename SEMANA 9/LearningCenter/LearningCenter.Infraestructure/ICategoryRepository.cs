namespace LearningCenter.Infraestructure;

public interface ICategoryRepository
{
    List<string> getAll();
    string getCategoryById(int id);
    bool create(string id);
}
namespace LearningCenter.Infraestructure;

public interface ICategoryRepository
{
    List<Category> getAll();
    Category getCategoryById(int id);
    Task<bool> create(Category category);
    bool Update(int id, string newName);
    bool Delete(int id);
}
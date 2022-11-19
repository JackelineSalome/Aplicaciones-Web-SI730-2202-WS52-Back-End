using LearningCenter.Infraestructure;

namespace LearningCenter.Domain;

public interface ICategoryDomain
{
    List<Category> getAll();
    Category getCategoryById(int id);
    Task<bool> createCategory(Category category);
    Boolean updateCategory(int id, string name);
    Boolean deleteCategory(int id);

}
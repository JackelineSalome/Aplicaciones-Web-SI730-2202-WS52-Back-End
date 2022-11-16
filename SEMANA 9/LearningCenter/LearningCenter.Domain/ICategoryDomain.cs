namespace LearningCenter.Domain;

public interface ICategoryDomain
{
    IEnumerable<string> getAll();
    string getCategoryById(int id);
    Boolean createCategory(string name);
    Boolean updateCategory(string name);
    Boolean deleteCategory(int id);

}
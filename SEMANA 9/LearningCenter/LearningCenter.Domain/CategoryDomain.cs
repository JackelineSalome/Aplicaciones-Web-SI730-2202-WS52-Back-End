using LearningCenter.Infraestructure;

namespace LearningCenter.Domain;

public class CategoryDomain : ICategoryDomain
{
    private ICategoryRepository _categoryRepository;
    
    public CategoryDomain(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public IEnumerable<string> getAll()
    {
        //Logica del negocio
        //Conect
        return _categoryRepository.getAll();
    }

    public string getCategoryById(int id)
    {
        return "body from Domain v2  " + id.ToString();
    }

    public bool createCategory(string name)
    {
        return true;
    }

    public bool updateCategory(string name)
    {
        return true;
    }

    public bool deleteCategory(int id)
    {
        return true;
    }
}
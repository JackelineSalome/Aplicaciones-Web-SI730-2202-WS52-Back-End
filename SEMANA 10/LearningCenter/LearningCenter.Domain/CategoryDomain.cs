using LearningCenter.Infraestructure;

namespace LearningCenter.Domain;

public class CategoryDomain : ICategoryDomain
{
    private ICategoryRepository _categoryRepository;
    
    public CategoryDomain(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public List<Category> getAll()
    {
        //Logica del negocio
        //Conect
        return _categoryRepository.getAll();
    }

    public Category getCategoryById(int id)
    {
        return _categoryRepository.getCategoryById(id);
    }

    public async Task<bool> createCategory(Category category)
    {
        return await _categoryRepository.create(category);
    }

    public bool updateCategory(int id, string name)
    {
        return _categoryRepository.Update(id, name);
    }

    public bool deleteCategory(int id)
    {
        return _categoryRepository.Delete(id);
    }
}
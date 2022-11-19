using System.Reflection.Metadata;
using System.Security;
using LearningCenter.Infraestructure;
using LearningCenter.Shared;
using Microsoft.VisualBasic;

namespace LearningCenter.Domain;

public class CategoryDomain : ICategoryDomain
{
    private ICategoryRepository _categoryRepository;
    
    public CategoryDomain(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<List<Category>> getAll(string name)
    {
        //Logica del negocio
        //Conect
        return await _categoryRepository.getAll(name);
    }

    public async Task<Category> getCategoryById(int id)
    {
        return await _categoryRepository.getCategoryById(id);
    }

    public async Task<bool> createCategory(Category category)
    {
        if (category.Quantity > Constans.MaxQuantityInventory)
        {
            throw new VerificationException("Quantity exceds the limit");
        }
        if (category.Description == category.Name)
        {
            throw new ArgumentException("Description and Name are equeals");
        }

        category.Name = category.Name.ReplaceBlankByUndercores();
        //category.Name = category.Name.Replace(" ", "_"); extension methods
        category.Description = category.Description.ReplaceBlankByUndercores();
        
        return await _categoryRepository.create(category);
    }

    public Task<bool> updateCategory(int id, Category  category)
    {
        return _categoryRepository.Update(id, category);
    }

    public bool deleteCategory(int id)
    {
        return _categoryRepository.Delete(id);
    }
}
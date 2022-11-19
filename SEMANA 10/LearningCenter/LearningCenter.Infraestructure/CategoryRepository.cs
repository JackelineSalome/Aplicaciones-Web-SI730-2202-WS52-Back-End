using LearningCenter.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure;

public class CategoryRepository : ICategoryRepository
{
    private LearningCenterDB _learningCenterDb;
    
    public CategoryRepository(LearningCenterDB learningCenterDb)
    {
        _learningCenterDb = learningCenterDb;
    }
    public List<Category> getAll()
    {
        //Conectar a la BD a API, al file --> datos
        
        var filterByName = "category";

        return _learningCenterDb.Categories
            .Include(category => category.Tutorials)
            .Where(category => category.IsActive && category.Name.Contains(filterByName)) //listado &&= AND
            .ToList();
        
        //var resul = from categorias in _learningCenterDb.Categories
        //    join tutoriales in _learningCenterDb.Tutorials  on categorias.Id equals  tutoriales.CategoryId
        //    select tutoriales.Category 

        //new Tutorial().DateCreated;
        //"SELECT * FROM Category"
        //"sp.selectAll"
    }

    public Category getCategoryById(int id)
    {
        //Conectar a la BD a API, al file --> datos
        return _learningCenterDb.Categories.Find(id);
    }

    public async Task<bool> create(Category category)
    {
        /*Category category = new Category();
        category.Name = name;
        category.Description = "Description" + name;*/

        using (var transaction = _learningCenterDb.Database.BeginTransactionAsync());

        try
        {
            _learningCenterDb.Categories.AddAsync(category);
            _learningCenterDb.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _learningCenterDb.Database.RollbackTransactionAsync();
        }
        
        
        _learningCenterDb.Database.CommitTransactionAsync();

        return true;
    }

    public bool Update(int id, string newName)
    {
        Category categorie = _learningCenterDb.Categories.Find(id);
        categorie.Name = newName;
        
        _learningCenterDb.Categories.Update(categorie);
        _learningCenterDb.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        Category categorie = _learningCenterDb.Categories.Find(id);

        //_learningCenterDb.Categories.Remove(categorie);
        //_learningCenterDb.SaveChanges();
        categorie.IsActive = false;
        categorie.DateUpdated = DateTime.Now;
        _learningCenterDb.Categories.Update(categorie);
        _learningCenterDb.SaveChanges();

        return true;
    }
}
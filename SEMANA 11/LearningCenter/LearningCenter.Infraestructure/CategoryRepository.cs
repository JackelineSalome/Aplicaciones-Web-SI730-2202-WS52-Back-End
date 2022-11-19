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
    public async Task<List<Category>> getAll(string name)
    {
        //Conectar a la BD a API, al file --> datos
        
        return await _learningCenterDb.Categories
            .Include(category => category.Tutorials)
            .Where(category => category.IsActive && category.Name.Contains(name)) //listado &&= AND
            .ToListAsync();
        
        //var resul = from categorias in _learningCenterDb.Categories
        //    join tutoriales in _learningCenterDb.Tutorials  on categorias.Id equals  tutoriales.CategoryId
        //    select tutoriales.Category 

        //new Tutorial().DateCreated;
        //"SELECT * FROM Category"
        //"sp.selectAll"
    }

    public async Task<Category> getCategoryById(int id)
    {
        //Conectar a la BD a API, al file --> datos
        return await _learningCenterDb.Categories
            .Include(category => category.Tutorials)
            .SingleOrDefaultAsync(categery => categery.Id == id);
    }

    public async Task<bool> create(Category category)
    {
        /*Category category = new Category();
        category.Name = name;
        category.Description = "Description" + name;*/

        using (var transaction = _learningCenterDb.Database.BeginTransactionAsync());

        try
        {
            await _learningCenterDb.Categories.AddAsync(category);
            await _learningCenterDb.SaveChangesAsync();
            await _learningCenterDb.Database.CommitTransactionAsync();
            ;
        }
        catch (Exception e)
        {
            await _learningCenterDb.Database.RollbackTransactionAsync();
        }
        finally
        {
            _learningCenterDb.DisposeAsync();
        }
        
        

        return true;
    }

    public async Task<bool> Update(int id, Category category)
    {
        using (var transacction = await _learningCenterDb.Database.BeginTransactionAsync())
        {
            try
            {
                var existingCategory = await _learningCenterDb.Categories.FindAsync(id);

                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                existingCategory.DateUpdated = DateTime.Now;

                _learningCenterDb.Categories.Update(existingCategory);
                await _learningCenterDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _learningCenterDb.Database.RollbackTransactionAsync();
            }
        }

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
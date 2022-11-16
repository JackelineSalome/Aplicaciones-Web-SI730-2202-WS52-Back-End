namespace LearningCenter.Infraestructure;

public class CategoryRepository : ICategoryRepository
{
    public List<string> getAll()
    {
        //Conectar a la BD a API, al file --> datos
        
        return new List<string>() { "value1 v2 repository", "value2 v2 repository" };


        //new Tutorial().DateCreated;
        //"SELECT * FROM Category"
        //"sp.selectAll"
    }

    public string getCategoryById(int id)
    {
        //Conectar a la BD a API, al file --> datos
        throw new NotImplementedException();
    }

    public bool create(string id)
    {
        throw new NotImplementedException();
    }
}
namespace LearningCenter.Infraestructure;

public class Category:BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Tutorial> Tutorials { get; set; }

    
}
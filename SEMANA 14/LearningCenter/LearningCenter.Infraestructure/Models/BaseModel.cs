namespace LearningCenter.Infraestructure;

public class BaseModel
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public bool IsActive { get; set; }
}
using LearningCenter.Infraestructure;
using Moq;

namespace LearningCenter.Domain.Tests1;

public class CategoryDomainUnitTest
{
    [Fact]
    public void CreateCategory_ReturnTrue()
    {
        //AAA
        //Arrange
        
        //ICategoryRepository categoryRepository = new ICategoryRepository()

        var categoryRepository = new Mock<ICategoryRepository>();
        categoryRepository.Setup(categoryRepository => categoryRepository.create(It.IsAny<Category>()))
            .Returns(Task.FromResult(true));
        
        var expectedValue = Task.FromResult(true);
        var category = new Category()
        {
            Name = "Name Fake",
            Description = "Description fake",
            Quantity = 50
        };
        
        var categoryDomain = new CategoryDomain(categoryRepository.Object);

    

        //Act

        var result = categoryDomain.createCategory(category);

        //Assert
        Assert.True(result.Result);

    }
}
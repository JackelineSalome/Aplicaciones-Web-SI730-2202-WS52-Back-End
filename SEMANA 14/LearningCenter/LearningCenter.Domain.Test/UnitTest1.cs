using LearningCenter.Infraestructure;

namespace LearningCenter.Domain.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Sum_ReturmSum()
    {
        //AAA
        //Arange
        int number1 = 10;
        int number2 = 20;
        int expectedValue = 30; 
        var testableDomain = new TesteableDomain();

        //Act
        var returnedValue = testableDomain.sum(number1, number2);

        //Assert
        Assert.AreEqual(expectedValue,returnedValue );
        //Assert.That(result, Is.EqualTo(expected));
    } 
    
    [Test] 
    public void Mul_ReturmMul()
    {
        //AAA
        //Arange
        int number1 = 1;
        int number2 = 1;
        int expectedValue = 1; 
        var testableDomain = new TesteableDomain();

        //Act
        var returnedValue = testableDomain.multiply(number1, number2);

        //Assert
        Assert.AreEqual(expectedValue,returnedValue );
    }
}
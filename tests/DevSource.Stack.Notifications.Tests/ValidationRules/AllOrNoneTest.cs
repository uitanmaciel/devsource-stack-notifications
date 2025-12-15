namespace DevSource.Stack.Notifications.Tests.ValidationRules;

[TestClass]
public class AllOrNoneTest
{
    [TestMethod]
    public void WhenAllValuesAreNotNull_NotReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value1 = "test1";
        string? value2 = "test2";
        string? value3 = "test3";
        
        // Act
        validation.AllOrNone(value1, value2, value3);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenAllValuesAreNull_NotReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value1 = null;
        string? value2 = null;
        string? value3 = null;
        
        // Act
        validation.AllOrNone(value1, value2, value3);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenSomeValuesAreNull_ReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value1 = "test1";
        string? value2 = null;
        string? value3 = "test3";
        
        // Act
        validation.AllOrNone(value1, value2, value3);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenOnlyOneValueIsNull_ReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value1 = "test1";
        string? value2 = "test2";
        string? value3 = null;
        
        // Act
        validation.AllOrNone(value1, value2, value3);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenOnlyOneValueIsNotNull_ReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value1 = null;
        string? value2 = null;
        string? value3 = "test3";
        
        // Act
        validation.AllOrNone(value1, value2, value3);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

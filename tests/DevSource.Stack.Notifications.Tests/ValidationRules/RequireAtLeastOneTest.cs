namespace DevSource.Stack.Notifications.Tests.ValidationRules;

[TestClass]
public class RequireAtLeastOneTest
{
    [TestMethod]
    public void WhenAtLeastOneValueIsNotNull_NotReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value1 = "test";
        string? value2 = null;
        string? value3 = null;
        
        // Act
        validation.RequireAtLeastOne(value1, value2, value3);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenAllValuesAreNotNull_NotReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value1 = "test1";
        string? value2 = "test2";
        string? value3 = "test3";
        
        // Act
        validation.RequireAtLeastOne(value1, value2, value3);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenAllValuesAreNull_ReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value1 = null;
        string? value2 = null;
        string? value3 = null;
        
        // Act
        validation.RequireAtLeastOne(value1, value2, value3);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenSingleValueIsNotNull_NotReturnNotification()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        string? value = "test";
        
        // Act
        validation.RequireAtLeastOne(value);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
}

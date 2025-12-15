namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class EndsWithTest
{
    [TestMethod]
    public void WhenStringEndsWithSuffix_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "HelloWorld";
        const string suffix = "World";
        
        // Act
        validation.EndsWith("Value", value, suffix);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringDoesNotEndWithSuffix_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "HelloWorld";
        const string suffix = "Universe";
        
        // Act
        validation.EndsWith("Value", value, suffix);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

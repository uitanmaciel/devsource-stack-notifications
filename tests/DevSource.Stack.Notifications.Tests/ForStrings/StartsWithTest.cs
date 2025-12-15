namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class StartsWithTest
{
    [TestMethod]
    public void WhenStringStartsWithPrefix_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "HelloWorld";
        const string prefix = "Hello";
        
        // Act
        validation.StartsWith("Value", value, prefix);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringDoesNotStartWithPrefix_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "GoodbyeWorld";
        const string prefix = "Hello";
        
        // Act
        validation.StartsWith("Value", value, prefix);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

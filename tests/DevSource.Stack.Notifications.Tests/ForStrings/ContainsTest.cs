namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class ContainsTest
{
    [TestMethod]
    public void WhenStringContainsSubstring_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "HelloWorld";
        const string substring = "oWo";
        
        // Act
        validation.Contains("Value", value, substring);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringDoesNotContainSubstring_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "HelloWorld";
        const string substring = "xyz";
        
        // Act
        validation.Contains("Value", value, substring);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

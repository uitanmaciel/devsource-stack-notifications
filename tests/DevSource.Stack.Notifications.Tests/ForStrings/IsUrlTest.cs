namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsUrlTest
{
    [TestMethod]
    public void WhenStringIsValidHttpUrl_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "http://www.example.com";
        
        // Act
        validation.IsUrl("Value", value);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringIsValidHttpsUrl_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "https://www.example.com";
        
        // Act
        validation.IsUrl("Value", value);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringIsInvalidUrl_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "not-a-url";
        
        // Act
        validation.IsUrl("Value", value);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringIsRelativeUrl_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "/relative/path";
        
        // Act
        validation.IsUrl("Value", value);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

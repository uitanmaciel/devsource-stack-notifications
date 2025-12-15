namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class ContainsOnlyTest
{
    [TestMethod]
    public void WhenStringContainsOnlyAllowedCharacters_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "abc123";
        const string allowedChars = "abc123456789";
        
        // Act
        validation.ContainsOnly("Value", value, allowedChars);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringContainsInvalidCharacters_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "abc123@";
        const string allowedChars = "abc123";
        
        // Act
        validation.ContainsOnly("Value", value, allowedChars);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

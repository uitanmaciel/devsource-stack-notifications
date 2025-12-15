namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class MatchesPatternTest
{
    [TestMethod]
    public void WhenStringMatchesPattern_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "abc123";
        const string pattern = @"^[a-z]{3}\d{3}$";
        
        // Act
        validation.MatchesPattern("Value", value, pattern);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringDoesNotMatchPattern_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "abc12";
        const string pattern = @"^[a-z]{3}\d{3}$";
        
        // Act
        validation.MatchesPattern("Value", value, pattern);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

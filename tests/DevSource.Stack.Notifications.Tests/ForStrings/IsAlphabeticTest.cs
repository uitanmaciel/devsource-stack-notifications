namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsAlphabeticTest
{
    [TestMethod]
    public void WhenStringIsAlphabetic_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "abcXYZ";
        
        // Act
        validation.IsAlphabetic("Value", value);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringContainsNumbers_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "abc123";
        
        // Act
        validation.IsAlphabetic("Value", value);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringIsEmpty_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "";
        
        // Act
        validation.IsAlphabetic("Value", value);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

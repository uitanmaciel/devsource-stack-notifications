namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsAlphanumericTest
{
    [TestMethod]
    public void WhenStringIsAlphanumeric_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "abc123XYZ";
        
        // Act
        validation.IsAlphanumeric("Value", value);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringContainsSpecialCharacters_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "abc123@";
        
        // Act
        validation.IsAlphanumeric("Value", value);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

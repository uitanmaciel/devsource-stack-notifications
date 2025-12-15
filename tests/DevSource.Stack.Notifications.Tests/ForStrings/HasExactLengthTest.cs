namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class HasExactLengthTest
{
    [TestMethod]
    public void WhenStringHasExactLength_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "12345";
        
        // Act
        validation.HasExactLength("Value", value, 5);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringDoesNotHaveExactLength_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "1234";
        
        // Act
        validation.HasExactLength("Value", value, 5);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

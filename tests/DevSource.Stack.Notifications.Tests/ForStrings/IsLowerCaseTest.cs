namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsLowerCaseTest
{
    [TestMethod]
    public void WhenStringIsLowerCase_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "hello";
        
        // Act
        validation.IsLowerCase("Value", value);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringIsNotLowerCase_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "Hello";
        
        // Act
        validation.IsLowerCase("Value", value);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

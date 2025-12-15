namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsUpperCaseTest
{
    [TestMethod]
    public void WhenStringIsUpperCase_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "HELLO";
        
        // Act
        validation.IsUpperCase("Value", value);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringIsNotUpperCase_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "Hello";
        
        // Act
        validation.IsUpperCase("Value", value);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

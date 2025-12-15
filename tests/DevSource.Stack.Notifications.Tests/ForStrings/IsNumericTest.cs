namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsNumericTest
{
    [TestMethod]
    public void WhenStringIsNumeric_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "123456";
        
        // Act
        validation.IsNumeric("Value", value);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringContainsLetters_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string value = "123abc";
        
        // Act
        validation.IsNumeric("Value", value);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

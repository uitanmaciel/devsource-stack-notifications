namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsNullTest
{
    [TestMethod]
    public void WhenStringIsNull_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const string? value = null;
        
        // Act
        // Validate that the string is not null
        validation.IsNull("Value", value);
        
        // Assert
        // Verify that there are no validation notifications, indicating the string is not null
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenStringIsNull_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const string? value = "0123456789";
        
        // Act
        // Validate that the string is not null
        validation.IsNull("Value", value);
        
        // Assert
        // Verify that there are no validation notifications, indicating the string is not null
        Assert.IsTrue(!validation.HasNotifications);
    }
}
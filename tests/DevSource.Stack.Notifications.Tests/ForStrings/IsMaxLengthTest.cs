namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsMaxLengthTest
{
    [TestMethod]
    public void WhenStringIsMaxLength_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const string value = "12345678901";
        const int maxLength = 10;
        
        // Act
        // Validate that the string is within the specified maximum length
        validation.MaxLength("Value", value, maxLength);
        
        // Assert
        // Verify that there are no validation notifications, indicating the string is within the maximum length
        Assert.IsTrue(validation.HasNotifications);
    }
}
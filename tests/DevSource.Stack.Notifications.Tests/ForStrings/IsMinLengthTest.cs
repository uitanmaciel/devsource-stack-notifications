namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsMinLengthTest
{
    [TestMethod]
    public void WhenStringIsMinLength_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const string value = "123456789";
        const int minLength = 10;
        
        // Act
        // Validate that the string is within the specified minimum length
        validation.MinLength("Value", value, minLength);
        
        // Assert
        // Verify that there are no validation notifications, indicating the string is within the minimum length
        Assert.IsTrue(validation.HasNotifications);
    }
}
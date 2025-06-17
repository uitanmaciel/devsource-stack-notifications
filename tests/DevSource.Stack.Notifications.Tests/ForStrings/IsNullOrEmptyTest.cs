namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsNullOrEmptyTest
{
    [TestMethod]
    public void WhenStringIsNullOrEmpty_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const string value = "";
        
        // Act
        // Validate that the string is not null or empty
        validation.IsNullOrEmpty("Value", value);
        
        // Assert
        // Verify that there are no validation notifications, indicating the string is not null or empty
        Assert.IsTrue(!validation.HasNotifications);
    }

    [TestMethod]
    public void WhenStringIsNotNullOrEmpty_ReturnNotification()
    {
        var validation = new ValidationRules<object>();
        const string value = "abc";

        validation.IsNullOrEmpty("Value", value);

        Assert.IsTrue(validation.HasNotifications);
    }
}
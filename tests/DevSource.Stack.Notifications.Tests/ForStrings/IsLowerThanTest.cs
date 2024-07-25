namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsLowerThanTest
{
    [TestMethod]
    public void WhenStringIsLowerThan_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const string value = "012345";
        const int size = 10;
        
        // Act
        // Validate that the value is lower than the maximum value
        validation.IsLowerThan("Value", value, size);
        
        // Assert
        // Verify that there are no validation notifications, indicating the value is lower than the maximum value
        Assert.IsTrue(validation.HasNotifications);
    }
}
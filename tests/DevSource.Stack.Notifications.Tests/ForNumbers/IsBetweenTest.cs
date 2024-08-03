namespace DevSource.Stack.Notifications.Tests.ForNumbers;

[TestClass]
public class IsBetweenTest
{
    [TestMethod]
    public void WhenNumberIsBetween_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const double value = 5.2;
        const double min = 5.1;
        const double max = 5.3;
        
        // Act
        // Validate that the number is between the specified minimum and maximum values
        validation.IsBetween("Value", value, min, max);
        
        // Assert
        // Verify that there are no validation notifications, indicating the number is between the minimum and maximum values
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenNumberIsNotBetween_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const double value = 5.2;
        const double min = 5.3;
        const double max = 5.4;
        
        // Act
        // Validate that the number is between the specified minimum and maximum values
        validation.IsBetween("Value", value, min, max);
        
        // Assert
        // Verify that there are validation notifications, indicating the number is not between the minimum and maximum values
        Assert.IsTrue(validation.HasNotifications);
    }
}
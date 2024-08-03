namespace DevSource.Stack.Notifications.Tests.ForNumbers;

[TestClass]
public class IsGreaterThanTest
{
    [TestMethod]
    public void WhenNumberIsGreaterThan_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const double value = 5.2;
        const double comparison = 5.1;
        
        // Act
        // Validate that the number is greater than the specified comparison value
        validation.IsGreaterThan("Value", value, comparison);
        
        // Assert
        // Verify that there are no validation notifications, indicating the number is greater than the comparison value
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenNumberIsNotGreaterThan_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const double value = 5.2;
        const double comparison = 6.3;
        
        // Act
        // Validate that the number is greater than the specified comparison value
        validation.IsGreaterThan("Value", value, comparison);
        
        // Assert
        // Verify that there are validation notifications, indicating the number is not greater than the comparison value
        Assert.IsTrue(validation.HasNotifications);
    }
}
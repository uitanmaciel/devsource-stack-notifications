namespace DevSource.Stack.Notifications.Tests.ForNumbers;

[TestClass]
public class IsLowerThanTest
{
    [TestMethod]
    public void WhenNumberIsLowerThan_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const double value = 5.2;
        const double comparison = 5.3;
        
        // Act
        // Validate that the number is lower than the specified comparison value
        validation.IsLowerThan("Value", value, comparison);
        
        // Assert
        // Verify that there are no validation notifications, indicating the number is lower than the comparison value
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenNumberIsNotLowerThan_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const double value = 5.2;
        const double comparison = 4.1;
        
        // Act
        // Validate that the number is lower than the specified comparison value
        validation.IsLowerThan("Value", value, comparison);
        
        // Assert
        // Verify that there are validation notifications, indicating the number is not lower than the comparison value
        Assert.IsTrue(validation.HasNotifications);
    }
}
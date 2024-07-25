namespace DevSource.Stack.Notifications.Tests.ForDateTime;

[TestClass]
public class IsInThePastTest
{
    [TestMethod]
    public void WhenDateIsInThePast_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        var date = DateTime.Now.AddDays(-1);
        
        // Act
        // Validate that the current date is within the specified date range
        validation.IsInThePast("Date", date);
        
        // Assert
        // Verify that there are no validation notifications, indicating the date is within the range
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenDateIsNotInThePast_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        var date = DateTime.Now.AddDays(1);
        
        // Act
        // Validate that the current date is within the specified date range
        validation.IsInThePast("Date", date);
        
        // Assert
        // Verify that there are no validation notifications, indicating the date is within the range
        Assert.IsTrue(validation.HasNotifications);
    }
}
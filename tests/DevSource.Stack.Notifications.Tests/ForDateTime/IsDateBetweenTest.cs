namespace DevSource.Stack.Notifications.Tests.ForDateTime;

[TestClass]
public class IsDateBetweenTest
{
    [TestMethod]
    public void WhenDateIsBetweenRange_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        var date = DateTime.Now;
        var from = date.AddDays(-1);
        var to = date.AddDays(1);
        
        // Act
        // Validate that the current date is within the specified date range
        validation.IsDateBetween("Date", date, from, to);
        
        // Assert
        // Verify that there are no validation notifications, indicating the date is within the range
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenDateIsNotBetweenRange_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        var date = DateTime.Now;
        var from = date.AddDays(-2);
        var to = date.AddDays(-1);
        
        // Act
        // Validate that the current date is within the specified date range
        validation.IsDateBetween("Date", date, from, to);
        
        // Assert
        // Verify that there are no validation notifications, indicating the date is within the range
        Assert.IsTrue(validation.HasNotifications);
    }
}
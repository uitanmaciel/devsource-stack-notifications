﻿namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsGreaterThanTest
{
    [TestMethod]
    public void WhenStringIsGreaterThan_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const string value = "012345";
        const int max = 5;
        
        // Act
        // Validate that the value is greater than the minimum value
        validation.IsGreaterThan("Value", value, max);
        
        // Assert
        // Verify that there are no validation notifications, indicating the value is greater than the minimum value
        Assert.IsTrue(validation.HasNotifications);
    }
}
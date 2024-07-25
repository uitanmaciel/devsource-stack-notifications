namespace DevSource.Stack.Notifications.Tests.ForPassword;

[TestClass]
public class IsValidPasswordTest
{
    /// <summary>
    /// Tests the IsPassword method in the ValidationRules class with a valid password.
    /// The method should recognize a valid password that meets the specified minimum length and complexity requirements.
    /// As a result, it should not add any notifications to the validation instance, indicating the password is valid.
    /// </summary>
    [TestMethod]
    public void WhenPasswordIsValid_NotReturnNotification()
    {
        // Arrange
        // Create a new instance of ValidationRules for an object.
        // Define a valid password string that meets the required criteria (minimum length and complexity).
        // Set the minimum length for the password validation.
        var validation = new ValidationRules<object>();
        const string password = "Password123!";
        const int min = 8;
        
        // Act
        // Call the IsPassword method with the "Password" key and the valid password string.
        // This should perform the validation and, because the password is valid,
        // not add any notification to the validation instance.
        validation.IsPassword("Password", password, min);
        
        // Assert
        // Verify that the validation instance has no notifications,
        // indicating that the password was correctly identified as valid.
        Assert.IsTrue(!validation.HasNotifications);
    }
}
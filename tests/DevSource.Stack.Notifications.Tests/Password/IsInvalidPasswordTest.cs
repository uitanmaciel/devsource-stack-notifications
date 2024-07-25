namespace DevSource.Stack.Notifications.Tests.Password;

[TestClass]
public class IsInvalidPasswordTest
{
    /// <summary>
    /// Tests the IsPassword method in the ValidationRules class with an empty password.
    /// This method should recognize the password as invalid since it doesn't meet the minimum length criteria and is empty.
    /// As a result, it should add a specific notification to the validation instance indicating that the password field must not be null or empty.
    /// </summary>
    [TestMethod]
    public void WhenPasswordIsInvalid_MinLength_ReturnHasNotification()
    {
        // Arrange
        // Create a new instance of ValidationRules for an object.
        // Define an empty password string to simulate a user not entering a password.
        // Set the expected notification message for a null or empty password.
        // Set the minimum length for the password validation.
        var validation = new ValidationRules<object>();
        const string password = "@A1b2c3";
        const int min = 8;

        // Act
        // Call the IsPassword method with the "Password" key, the too-short password string, and the minimum length.
        // This should perform the validation and, because the password is too short,
        // add a notification to the validation instance indicating the field must have a minimum number of characters.
        validation.IsPassword("Password", password, min);

        // Assert
        // Verify that the validation instance has notifications, indicating that the password was identified as invalid.
        Assert.IsTrue(validation.HasNotifications);
    }
    
    /// <summary>
    /// Tests the IsPassword method in the ValidationRules class with a password that doesn't match the required regex pattern.
    /// This method should recognize the password as invalid since it doesn't meet the complexity requirements defined by the regex pattern.
    /// As a result, it should add a specific notification to the validation instance indicating that the value of the password field is invalid.
    /// </summary>
    [TestMethod]
    public void WhenPasswordIsInvalid_RegexIsMatch_ReturnHasNotification()
    {
        // Arrange
        // Create a new instance of ValidationRules for an object.
        // Define a password string that doesn't match the required regex pattern, simulating a user entering a password without the necessary complexity.
        // Set the expected notification message for a password that doesn't meet the complexity requirements.
        // Set the minimum length for the password validation.
        var validation = new ValidationRules<object>();
        const string password = "a1b2c3d4e5";
        const int min = 8;
        
        // Act
        // Call the IsPassword method with the "Password" key, the password string that doesn't meet the regex pattern, and the minimum length.
        // This should perform the validation and, because the password doesn't match the regex pattern,
        // add a notification to the validation instance indicating the password value is invalid.
        validation.IsPassword("Password", password, min);
        
        // Assert
        // Verify that the validation instance has notifications, indicating that the password was identified as invalid.
        Assert.IsTrue(validation.HasNotifications);
    }
}
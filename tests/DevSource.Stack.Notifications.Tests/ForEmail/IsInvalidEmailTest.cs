namespace DevSource.Stack.Notifications.Tests.ForEmail;

[TestClass]
public class IsInvalidEmailTest
{
    /// <summary>
    /// Tests the IsEmail method in the ValidationRules class with an invalid email address.
    /// The method should identify the invalid email and add a notification to the validation instance.
    /// </summary>
    [TestMethod]
    public void WhenEmailIsInvalid_ReturnHasNotification()
    {
        //Arrange
        // Create a new instance of ValidationRules for an object.
        // Define an invalid email string that does not include the '@' character.
        var validation = new ValidationRules<object>();
        const string email = "email.com";
        
        //Act
        // Call the IsEmail method with the "Email" key and the invalid email string.
        // This should perform the validation and, because the email is invalid,
        // add a notification to the validation instance.
        validation.IsEmail("Email", email);

        //Assert
        // Check if the validation instance has notifications,
        // if there are notifications the test is correct.
        Assert.IsTrue(validation.HasNotifications);
    }
}
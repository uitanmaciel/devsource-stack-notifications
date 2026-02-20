namespace DevSource.Stack.Notifications.Tests.ForFiles;

[TestClass]
public class HasValidMimeTypeTest
{
    [TestMethod]
    public void WhenMimeTypeIsValid_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string mimeType = "application/pdf";
        string[] allowedMimeTypes = { "application/pdf", "image/jpeg", "image/png" };
        
        // Act
        validation.HasValidMimeType("File", mimeType, allowedMimeTypes);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenMimeTypeIsValidCaseInsensitive_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string mimeType = "APPLICATION/PDF";
        string[] allowedMimeTypes = { "application/pdf", "image/jpeg", "image/png" };
        
        // Act
        validation.HasValidMimeType("File", mimeType, allowedMimeTypes);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenMimeTypeIsInvalid_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string mimeType = "application/x-msdownload";
        string[] allowedMimeTypes = { "application/pdf", "image/jpeg", "image/png" };
        
        // Act
        validation.HasValidMimeType("File", mimeType, allowedMimeTypes);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenMimeTypeIsNull_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        string? mimeType = null;
        string[] allowedMimeTypes = { "application/pdf", "image/jpeg", "image/png" };
        
        // Act
        validation.HasValidMimeType("File", mimeType!, allowedMimeTypes);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
}

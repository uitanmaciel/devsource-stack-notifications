namespace DevSource.Stack.Notifications.Tests.ForFiles;

[TestClass]
public class HasValidExtensionTest
{
    [TestMethod]
    public void WhenFileHasValidExtension_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string fileName = "document.pdf";
        string[] allowedExtensions = { ".pdf", ".doc", ".docx" };
        
        // Act
        validation.HasValidExtension("File", fileName, allowedExtensions);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenFileHasValidExtensionCaseInsensitive_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string fileName = "document.PDF";
        string[] allowedExtensions = { ".pdf", ".doc", ".docx" };
        
        // Act
        validation.HasValidExtension("File", fileName, allowedExtensions);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenFileHasInvalidExtension_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string fileName = "document.exe";
        string[] allowedExtensions = { ".pdf", ".doc", ".docx" };
        
        // Act
        validation.HasValidExtension("File", fileName, allowedExtensions);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenFileHasNoExtension_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string fileName = "document";
        string[] allowedExtensions = { ".pdf", ".doc", ".docx" };
        
        // Act
        validation.HasValidExtension("File", fileName, allowedExtensions);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

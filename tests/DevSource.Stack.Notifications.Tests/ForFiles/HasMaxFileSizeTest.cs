namespace DevSource.Stack.Notifications.Tests.ForFiles;

[TestClass]
public class HasMaxFileSizeTest
{
    [TestMethod]
    public void WhenFileSizeIsWithinLimit_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const long fileSize = 1024 * 1024; // 1 MB
        const long maxSize = 5 * 1024 * 1024; // 5 MB
        
        // Act
        validation.HasMaxFileSize("File", fileSize, maxSize);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenFileSizeIsExactlyAtLimit_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const long fileSize = 5 * 1024 * 1024; // 5 MB
        const long maxSize = 5 * 1024 * 1024; // 5 MB
        
        // Act
        validation.HasMaxFileSize("File", fileSize, maxSize);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenFileSizeExceedsLimit_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const long fileSize = 10 * 1024 * 1024; // 10 MB
        const long maxSize = 5 * 1024 * 1024; // 5 MB
        
        // Act
        validation.HasMaxFileSize("File", fileSize, maxSize);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

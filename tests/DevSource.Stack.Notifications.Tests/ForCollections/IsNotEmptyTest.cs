namespace DevSource.Stack.Notifications.Tests.ForCollections;

[TestClass]
public class IsNotEmptyTest
{
    [TestMethod]
    public void WhenCollectionHasItems_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3 };
        
        // Act
        validation.IsNotEmpty("Collection", collection);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionIsEmpty_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int>();
        
        // Act
        validation.IsNotEmpty("Collection", collection);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionIsNull_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        List<int>? collection = null;
        
        // Act
        validation.IsNotEmpty("Collection", collection);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

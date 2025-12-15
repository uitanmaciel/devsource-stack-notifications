namespace DevSource.Stack.Notifications.Tests.ForCollections;

[TestClass]
public class HasMinItemsTest
{
    [TestMethod]
    public void WhenCollectionHasMinimumItems_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3, 4, 5 };
        
        // Act
        validation.HasMinItems("Collection", collection, 3);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionHasExactMinimumItems_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3 };
        
        // Act
        validation.HasMinItems("Collection", collection, 3);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionHasFewerItems_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2 };
        
        // Act
        validation.HasMinItems("Collection", collection, 3);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

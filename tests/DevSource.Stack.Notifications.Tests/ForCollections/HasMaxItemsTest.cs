namespace DevSource.Stack.Notifications.Tests.ForCollections;

[TestClass]
public class HasMaxItemsTest
{
    [TestMethod]
    public void WhenCollectionHasFewerThanMaxItems_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3 };
        
        // Act
        validation.HasMaxItems("Collection", collection, 5);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionHasExactMaxItems_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3, 4, 5 };
        
        // Act
        validation.HasMaxItems("Collection", collection, 5);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionHasMoreThanMaxItems_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3, 4, 5, 6 };
        
        // Act
        validation.HasMaxItems("Collection", collection, 5);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}

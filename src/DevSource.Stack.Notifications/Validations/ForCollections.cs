namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that a collection is not null or empty.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNotEmpty<TItem>(string key, IEnumerable<TItem>? collection)
    {
        if (collection == null || !collection.Any())
            AddNotification(new Notification(Error.CollectionMustNotBeEmpty(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection is not null or empty, with a custom error message.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNotEmpty<TItem>(string key, IEnumerable<TItem>? collection, string message)
    {
        if (collection == null || !collection.Any())
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection has a minimum number of items.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="minCount">The minimum required number of items.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasMinItems<TItem>(string key, IEnumerable<TItem>? collection, int minCount)
    {
        if (collection?.Count() < minCount)
            AddNotification(new Notification(Error.CollectionMinItems(key, minCount)));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection has a minimum number of items, with a custom error message.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="minCount">The minimum required number of items.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasMinItems<TItem>(string key, IEnumerable<TItem>? collection, int minCount, string message)
    {
        if (collection?.Count() < minCount)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection has a maximum number of items.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="maxCount">The maximum allowed number of items.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasMaxItems<TItem>(string key, IEnumerable<TItem>? collection, int maxCount)
    {
        if (collection?.Count() > maxCount)
            AddNotification(new Notification(Error.CollectionMaxItems(key, maxCount)));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection has a maximum number of items, with a custom error message.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="maxCount">The maximum allowed number of items.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasMaxItems<TItem>(string key, IEnumerable<TItem>? collection, int maxCount, string message)
    {
        if (collection?.Count() > maxCount)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection has an exact number of items.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="exactCount">The exact required number of items.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasExactItems<TItem>(string key, IEnumerable<TItem>? collection, int exactCount)
    {
        if (collection?.Count() != exactCount)
            AddNotification(new Notification(Error.CollectionExactItems(key, exactCount)));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection has an exact number of items, with a custom error message.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="exactCount">The exact required number of items.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasExactItems<TItem>(string key, IEnumerable<TItem>? collection, int exactCount, string message)
    {
        if (collection?.Count() != exactCount)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection contains unique items (no duplicates).
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasUniqueItems<TItem>(string key, IEnumerable<TItem>? collection)
    {
        if (collection != null && collection.Count() != collection.Distinct().Count())
            AddNotification(new Notification(Error.CollectionMustHaveUniqueItems(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection contains unique items (no duplicates), with a custom error message.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasUniqueItems<TItem>(string key, IEnumerable<TItem>? collection, string message)
    {
        if (collection != null && collection.Count() != collection.Distinct().Count())
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection contains a specific item.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="item">The item that must be present in the collection.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> ContainsItem<TItem>(string key, IEnumerable<TItem>? collection, TItem item)
    {
        if (collection?.Contains(item) != true)
            AddNotification(new Notification(Error.CollectionMustContainItem(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that a collection contains a specific item, with a custom error message.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="item">The item that must be present in the collection.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> ContainsItem<TItem>(string key, IEnumerable<TItem>? collection, TItem item, string message)
    {
        if (collection?.Contains(item) != true)
            AddNotification(new Notification(key, message));
        
        return this;
    }
}

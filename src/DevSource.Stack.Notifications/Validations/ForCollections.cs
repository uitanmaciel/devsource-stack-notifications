namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that a collection is not null or empty, with a custom error message.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <param name="key">The key representing the collection field in the object being validated.</param>
    /// <param name="collection">The collection to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNotEmpty<TItem>(string key, IEnumerable<TItem>? collection, string? message = null)
    {
        if (collection is null || !collection.Any())
            return Notify(key, message ?? Error.CollectionMustNotBeEmpty(key));
        
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
    public ValidationRules<T> HasMinItems<TItem>(string key, IEnumerable<TItem>? collection, int minCount, string? message = null)
    {
        if (CountFast(collection) < minCount)
            return Notify(key, message ?? Error.CollectionMinItems(key, minCount));
        
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
    public ValidationRules<T> HasMaxItems<TItem>(string key, IEnumerable<TItem>? collection, int maxCount, string? message = null)
    {
        if (CountFast(collection) > maxCount)
            return Notify(key, message ?? Error.CollectionMaxItems(key, maxCount));
        
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
    public ValidationRules<T> HasExactItems<TItem>(string key, IEnumerable<TItem>? collection, int exactCount, string? message = null)
    {
        if (CountFast(collection) != exactCount)
            return Notify(key, message ?? Error.CollectionExactItems(key, exactCount));
        
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
    public ValidationRules<T> HasUniqueItems<TItem>(string key, IEnumerable<TItem>? collection, string? message = null)
    {
        if (collection is not null && HasDuplicates(collection))
            return Notify(key, message ?? Error.CollectionMustHaveUniqueItems(key));

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
    public ValidationRules<T> ContainsItem<TItem>(string key, IEnumerable<TItem>? collection, TItem item, string? message = null)
    {
        if (collection is null || !collection.Contains(item))
            return Notify(key, message ?? Error.CollectionMustContainItem(key));
        
        return this;
    }

    private static int CountFast<TItem>(IEnumerable<TItem>? collection)
    {
        if (collection is null) return 0;
        
        return collection is ICollection<TItem> c ? c.Count : collection.Count();
    }

    private static bool HasDuplicates<TItem>(IEnumerable<TItem> collection)
    {
        var set = new HashSet<TItem>();
        foreach (var item in collection)
            if (!set.Add(item))
                return true;

        return false;
    }
}

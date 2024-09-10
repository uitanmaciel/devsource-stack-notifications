namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The double value that the length of the key should be greater than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsGreaterThan(string key, double value, double comparer)
    {
        if(value < comparer)
            AddNotification(new Notification(Error.IsGreaterThan(key, comparer)));
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The double value that the length of the key should be greater than.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsGreaterThan(string key, double value, double comparer, string message)
    {
        if(value < comparer)
            AddNotification(new Notification(key, message));
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The integer value that the length of the key should be greater than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsGreaterThan(string key, int value, int comparer)
    {
        if(value < comparer)
            AddNotification(new Notification(Error.IsGreaterThan(key, comparer)));
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The integer value that the length of the key should be greater than.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsGreaterThan(string key, int value, int comparer, string message)
    {
        if(value < comparer)
            AddNotification(new Notification(key, message));
        return this;
    }
    
    
    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The decimal value that the length of the key should be greater than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsGreaterThan(string key, decimal value, decimal comparer)
    {
        if(value < comparer)
            AddNotification(new Notification(Error.IsGreaterThan(key, comparer)));
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The decimal value that the length of the key should be greater than.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsGreaterThan(string key, decimal value, decimal comparer, string message)
    {
        if(value < comparer)
            AddNotification(new Notification(key, message));
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The double value to be validated.</param>
    /// <param name="comparer">The double value that the length of the key should be less than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerThan(string key, double value, double comparer)
    {
        if(value > comparer)
            AddNotification(new Notification(Error.IsLowerThan(key, comparer)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The double value to be validated.</param>
    /// <param name="comparer">The double value that the length of the key should be less than.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerThan(string key, double value, double comparer, string message)
    {
        if(value > comparer)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The integer value to be validated.</param>
    /// <param name="comparer">The integer value that the length of the key should be less than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerThan(string key, int value, int comparer)
    {
        if(value > comparer)
            AddNotification(new Notification(Error.IsLowerThan(key, comparer)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The integer value to be validated.</param>
    /// <param name="comparer">The integer value that the length of the key should be less than.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerThan(string key, int value, int comparer, string message)
    {
        if(value > comparer)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The decimal value that the length of the key should be less than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerThan(string key, decimal value, decimal comparer)
    {
        if(value > comparer)
            AddNotification(new Notification(Error.IsLowerThan(key, comparer)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The decimal value that the length of the key should be less than.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerThan(string key, decimal value, decimal comparer, string message)
    {
        if(value > comparer)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given double value is within the specified range [min, max]. If the value is outside this range, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The double value to be validated.</param>
    /// <param name="min">The minimum allowable value.</param>
    /// <param name="max">The maximum allowable value.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, double value, double min, double max)
    {
        if(value < min || value > max)
            AddNotification(new Notification(Error.IsBetween(key, min, max)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given double value is within the specified range [min, max]. If the value is outside this range, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The double value to be validated.</param>
    /// <param name="min">The minimum allowable value.</param>
    /// <param name="max">The maximum allowable value.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, double value, double min, double max, string message)
    {
        if(value < min || value > max)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given double value is within the specified range [min, max]. If the value is outside this range, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The double value to be validated.</param>
    /// <param name="min">The minimum allowable value.</param>
    /// <param name="max">The maximum allowable value.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, decimal value, decimal min, decimal max)
    {
        if(value < min || value > max)
            AddNotification(new Notification(Error.IsBetween(key, min, max)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given double value is within the specified range [min, max]. If the value is outside this range, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The double value to be validated.</param>
    /// <param name="min">The minimum allowable value.</param>
    /// <param name="max">The maximum allowable value.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, decimal value, decimal min, decimal max, string message)
    {
        if(value < min || value > max)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given double value is within the specified range [min, max]. If the value is outside this range, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The double value to be validated.</param>
    /// <param name="min">The minimum allowable value.</param>
    /// <param name="max">The maximum allowable value.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, int value, int min, int max)
    {
        if(value < min || value > max)
            AddNotification(new Notification(Error.IsBetween(key, min, max)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given double value is within the specified range [min, max]. If the value is outside this range, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The double value to be validated.</param>
    /// <param name="min">The minimum allowable value.</param>
    /// <param name="max">The maximum allowable value.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, int value, int min, int max, string message)
    {
        if(value < min || value > max)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two double values. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The double value to be compared.</param>
    /// <param name="comparer">The double value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, double value, double comparer)
    {
        if(value != comparer)
            AddNotification(new Notification(Error.Compare(key, comparer)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two double values. If the values are not equal, adds a notification with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The double value to be compared.</param>
    /// <param name="comparer">The double value to compare against.</param>
    /// <param name="message">The custom message for the notification if the comparison fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, double value, double comparer, string message)
    {
        if(value != comparer)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two integer values. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The integer value to be compared.</param>
    /// <param name="comparer">The integer value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, int value, int comparer)
    {
        if(value != comparer)
            AddNotification(new Notification(Error.Compare(key, comparer)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two integer values. If the values are not equal, adds a notification with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The integer value to be compared.</param>
    /// <param name="comparer">The integer value to compare against.</param>
    /// <param name="message">The custom message for the notification if the comparison fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, int value, int comparer, string message)
    {
        if(value != comparer)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two decimal values. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The decimal value to be compared.</param>
    /// <param name="comparer">The decimal value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, decimal value, decimal comparer)
    {
        if(value != comparer)
            AddNotification(new Notification(Error.Compare(key, comparer)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two decimal values. If the values are not equal, adds a notification with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The decimal value to be compared.</param>
    /// <param name="comparer">The decimal value to compare against.</param>
    /// <param name="message">The custom message for the notification if the comparison fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, decimal value, decimal comparer, string message)
    {
        if(value != comparer)
            AddNotification(new Notification(key, message));
        
        return this;
    }
}
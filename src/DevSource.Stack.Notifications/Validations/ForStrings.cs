namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that the length of the string does not exceed the specified maximum length.
    /// If the key is null or empty, or if the length exceeds the specified maximum, a notification is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="maxLength">The maximum allowed length for the string.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MaxLength(string key, string value, int maxLength)
    {
        if (value.Length > maxLength)
            AddNotification(new Notification(Error.MaxLength(key, maxLength)));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the string does not exceed the specified maximum length, with a custom error message.
    /// If the key is null or empty, or if the length exceeds the specified maximum, a custom notification is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="maxLength">The maximum allowed length for the string.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MaxLength(string key, string value, int maxLength, string message)
    {
        if (value.Length > maxLength)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the string meets or exceeds the specified minimum length.
    /// If the key is null or empty, or if the length is less than the specified minimum, a notification is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="minLength">The minimum required length for the string.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MinLength(string key, string value, int minLength)
    {
        if (value.Length < minLength)
            AddNotification(new Notification(Error.MinLength(key, minLength)));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the string meets or exceeds the specified minimum length, with a custom error message.
    /// If the key is null or empty, or if the length is less than the specified minimum, a custom notification is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="minLength">The minimum required length for the string.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MinLength(string key, string value, int minLength, string message)
    {
        if (value.Length < minLength)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is not null or an empty string.
    /// If the key is null or empty, a standard notification indicating the field should not be null is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNotNull(string key, string value)
    {
        if (string.IsNullOrEmpty(value))
            AddNotification(new Notification(Error.IsNotNull(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is not null or an empty string, with a custom error message.
    /// If the key is null or empty, a custom notification is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNotNull(string key, string value, string message)
    {
        if (string.IsNullOrEmpty(value))
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given string value is not null or empty. If the value is null or empty, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsNotNullOrEmpty(string key, string value)
    {
        if (string.IsNullOrEmpty(value))
            AddNotification(new Notification(Error.IsNotNullOrEmpty(key)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given string value is not null or empty. If the value is null or empty, adds a notification with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom message for the notification if the validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsNotNullOrEmpty(string key, string value, string message)
    {
        if (string.IsNullOrEmpty(value))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Checks whether the provided value is <c>null</c> or an empty string.
    /// When the value is missing, a notification is added indicating that the
    /// field must contain data.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNull(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
            AddNotification(new Notification(Error.IsNull(key)));
        
        return this;
    }

    /// <summary>
    /// Checks whether the provided value is <c>null</c> or an empty string and
    /// adds a notification with a custom message when the value is missing,
    /// enforcing that the field must contain data.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message for the notification.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNull(string key, string value, string message)
    {
        if (!string.IsNullOrEmpty(value))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the provided value is <c>null</c> or an empty string. If
    /// the value is missing, a notification is added requiring the field to
    /// contain data.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNullOrEmpty(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
            AddNotification(new Notification(key, Error.IsNullOrEmpty(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the provided value is <c>null</c> or empty and adds a
    /// notification with a custom message when it is, ensuring that the field
    /// must contain data.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message for the notification.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNullOrEmpty(string key, string value, string message)
    {
        if (!string.IsNullOrEmpty(value))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Determines whether the provided value is <c>null</c>, empty or contains
    /// only white-space characters. When such a value is detected, a
    /// notification is added indicating the field must have a value.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNullOrWhiteSpace(string key, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            AddNotification(new Notification(key, Error.IsNullOrWhiteSpace(key)));
        
        return this;
    }

    /// <summary>
    /// Determines whether the provided value is <c>null</c>, empty or consists
    /// solely of white-space characters and, if so, adds a notification using
    /// the supplied message to require that the field be populated.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message for the notification.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNullOrWhiteSpace(string key, string value, string message)
    {
        if (!string.IsNullOrWhiteSpace(value))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="greaterThan">The integer value that the length of the key should be greater than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLengthGreaterThan(string key, string value, int greaterThan)
    {
        if (value.Length < greaterThan)
            AddNotification(new Notification(Error.IsGreaterThan(key, greaterThan)));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value, with a custom error message.
    /// If the key is null or empty, or its length is not greater than the provided value, a custom notification is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="greaterThan">The integer value that the length of the key should be greater than.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLengthGreaterThan(string key, string value, int greaterThan, string message)
    {
        if (value.Length < greaterThan)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard notification is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="lowerThan">The integer value that the length of the key should be less than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLengthLowerThan(string key, string value, int lowerThan)
    {
        if (value.Length > lowerThan)
            AddNotification(new Notification(Error.IsLowerThan(key, lowerThan)));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is less than the provided value, with a custom error message.
    /// If the key is null or empty, or its length is not less than the provided value, a custom notification is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="lowerThan">The integer value that the length of the key should be less than.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLengthLowerThan(string key, string value, int lowerThan, string message)
    {
        if (value.Length > lowerThan)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the given GUID is not empty. If the GUID is empty, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the GUID value being validated.</param>
    /// <param name="value">The GUID value to be validated.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> IsGuidNotEmpty(string key, Guid value)
    {
        if (value == Guid.Empty)
            AddNotification(new Notification(Error.IsNotNull(key)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the given GUID is not empty. If the GUID is empty, adds a notification with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the GUID value being validated.</param>
    /// <param name="value">The GUID value to be validated.</param>
    /// <param name="message">The custom message for the notification if the validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> IsGuidNotEmpty(string key, Guid value, string message)
    {
        if (value == Guid.Empty)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two string values. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, string value, string compareValue)
    {
        if (value != compareValue)
            AddNotification(new Notification(Error.Compare(key, compareValue)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two string values. If the values are not equal, adds a notification with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="message">The custom message for the notification if the validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, string value, string compareValue, string message)
    {
        if (value != compareValue)
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two string values using the specified comparison type. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="comparisonType">The type of string comparison to perform.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, string value, string compareValue, StringComparison comparisonType)
    {
        if (!string.Equals(value, compareValue, comparisonType))
            AddNotification(new Notification(Error.Compare(key, compareValue)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two string values using the specified comparison type. If the values are not equal, adds a notification with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="comparisonType">The type of string comparison to perform.</param>
    /// <param name="message">The custom message for the notification if the comparison fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, string value, string compareValue, StringComparison comparisonType, string message)
    {
        if (!string.Equals(value, compareValue, comparisonType))
            AddNotification(new Notification(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two GUID values. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The GUID value to be compared.</param>
    /// <param name="compareValue">The GUID value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, Guid value, Guid compareValue)
    {
        if (value != compareValue)
            AddNotification(new Notification(Error.Compare(key, compareValue)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two GUID values. If the values are not equal, adds a notification with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The GUID value to be compared.</param>
    /// <param name="compareValue">The GUID value to compare against.</param>
    /// <param name="message">The custom message for the notification if the comparison fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, Guid value, Guid compareValue, string message)
    {
        if (value != compareValue)
            AddNotification(new Notification(key, message));
        
        return this;
    }
}
using DevSource.Stack.Notifications.Validations.Internal; // Added this
using System; // Added for Action

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
        ValidationRuleRunners.MaxLength(
            value,
            maxLength,
            key,
            Error.MaxLength(key, maxLength),
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.MaxLength(
            value,
            maxLength,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.MinLength(
            value,
            minLength,
            key,
            Error.MinLength(key, minLength),
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.MinLength(
            value,
            minLength,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        // Original logic: AddNotification if string.IsNullOrEmpty(value) with Error.IsNotNull(key)
        ValidationRuleRunners.IsNotNullOrEmpty(
            value,
            key,
            Error.IsNotNull(key),
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsNotNullOrEmpty(
            value,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsNotNullOrEmpty(
            value,
            key,
            Error.IsNotNullOrEmpty(key),
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsNotNullOrEmpty(
            value,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        // Original logic: AddNotification if !string.IsNullOrEmpty(value) with Error.IsNull(key)
        ValidationRuleRunners.IsNullOrEmpty(
            value,
            key,
            Error.IsNull(key),
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsNullOrEmpty(
            value,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        // Original logic: AddNotification if !string.IsNullOrEmpty(value) with Error.IsNullOrEmpty(key)
        ValidationRuleRunners.IsNullOrEmpty(
            value,
            key,
            Error.IsNullOrEmpty(key),
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsNullOrEmpty(
            value,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        // Original logic: AddNotification if !string.IsNullOrWhiteSpace(value) with Error.IsNullOrWhiteSpace(key)
        ValidationRuleRunners.IsNullOrWhiteSpace(
            value,
            key,
            Error.IsNullOrWhiteSpace(key),
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsNullOrWhiteSpace(
            value,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsLengthGreaterThan(
            value,
            greaterThan,
            key,
            Error.IsGreaterThan(key, greaterThan),
            this.AddNotification,
            null);
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
        ValidationRuleRunners.IsLengthGreaterThan(
            value,
            greaterThan,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsLengthLowerThan(
            value,
            lowerThan,
            key,
            Error.IsLowerThan(key, lowerThan),
            this.AddNotification,
            null);
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
        ValidationRuleRunners.IsLengthLowerThan(
            value,
            lowerThan,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.IsGuidNotEmpty(
            value,
            key,
            Error.IsNotNull(key),
            this.AddNotification,
            null,
            isCustomMessage: true); // Error.IsNotNull provides a full message
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
        ValidationRuleRunners.IsGuidNotEmpty(
            value,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            Error.Compare(key, compareValue),
            StringComparison.Ordinal,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            message,
            StringComparison.Ordinal,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            Error.Compare(key, compareValue),
            comparisonType,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            message,
            comparisonType,
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            Error.Compare(key, compareValue.ToString()), // Error.Compare expects string for value
            this.AddNotification,
            null,
            isCustomMessage: true);
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
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            message,
            this.AddNotification,
            null,
            isCustomMessage: true);
        return this;
    }
}
using DevSource.Stack.Notifications.Abstractions; // Required for DomainException
using DevSource.Stack.Notifications.Validations.Internal; // Added this
using System; // Added for Action & Guid

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRulesException<T>
{
    /// <summary>
    /// Validates that the length of the string does not exceed the specified maximum length.
    /// If the key is null or empty, or if the length exceeds the specified maximum, a domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="maxLength">The maximum allowed length for the string.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> MaxLength(string key, string value, int maxLength)
    {
        ValidationRuleRunners.MaxLength(
            value,
            maxLength,
            key,
            Error.MaxLength(key, maxLength),
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the length of the string does not exceed the specified maximum length, with a custom error message.
    /// If the key is null or empty, or if the length exceeds the specified maximum, a custom domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="maxLength">The maximum allowed length for the string.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> MaxLength(string key, string value, int maxLength, string message)
    {
        ValidationRuleRunners.MaxLength(
            value,
            maxLength,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the length of the string meets or exceeds the specified minimum length.
    /// If the key is null or empty, or if the length is less than the specified minimum, a domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="minLength">The minimum required length for the string.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> MinLength(string key, string value, int minLength)
    {
        ValidationRuleRunners.MinLength(
            value,
            minLength,
            key,
            Error.MinLength(key, minLength),
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the length of the string meets or exceeds the specified minimum length, with a custom error message.
    /// If the key is null or empty, or if the length is less than the specified minimum, a custom domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="minLength">The minimum required length for the string.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> MinLength(string key, string value, int minLength, string message)
    {
        ValidationRuleRunners.MinLength(
            value,
            minLength,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key is not null or an empty string.
    /// If the key is null or empty, a standard domain exception indicating the field should not be null is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNotNull(string key, string value)
    {
        // Original logic: PublishException if string.IsNullOrEmpty(value) with Error.IsNotNull(key)
        ValidationRuleRunners.IsNotNullOrEmpty(
            value,
            key,
            Error.IsNotNull(key),
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key is not null or an empty string, with a custom error message.
    /// If the key is null or empty, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNotNull(string key, string value, string message)
    {
        ValidationRuleRunners.IsNotNullOrEmpty(
            value,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Validates that a given string value is not null or empty. If the value is null or empty, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> for method chaining.</returns>
    public ValidationRulesException<T> IsNotNullOrEmpty(string key, string value)
    {
        ValidationRuleRunners.IsNotNullOrEmpty(
            value,
            key,
            Error.IsNotNullOrEmpty(key),
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Validates that a given string value is not null or empty. If the value is null or empty, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom message for the domain exception if the validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> for method chaining.</returns>
    public ValidationRulesException<T> IsNotNullOrEmpty(string key, string value, string message)
    {
        ValidationRuleRunners.IsNotNullOrEmpty(
            value,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null or an empty string.
    /// If the key is not null or empty, a standard domain exception indicating the field should be null is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNull(string key, string value)
    {
        ValidationRuleRunners.IsNullOrEmpty(
            value,
            key,
            Error.IsNull(key),
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null or an empty string, with a custom error message.
    /// If the key is not null or empty, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNull(string key, string value, string message)
    {
        ValidationRuleRunners.IsNullOrEmpty(
            value,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null or an empty string.
    /// If the key is not null and not empty, a standard domain exception indicating the field should be null or empty is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNullOrEmpty(string key, string value)
    {
        ValidationRuleRunners.IsNullOrEmpty(
            value,
            key,
            Error.IsNullOrEmpty(key),
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null or an empty string, with a custom error message.
    /// If the key is not null and not empty, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNullOrEmpty(string key, string value, string message)
    {
        ValidationRuleRunners.IsNullOrEmpty(
            value,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null, an empty string, or consists only of white-space characters.
    /// If the key is not null, not empty, and not just white-space, a standard domain exception indicating the field should be null or white-space is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNullOrWhiteSpace(string key, string value)
    {
        ValidationRuleRunners.IsNullOrWhiteSpace(
            value,
            key,
            Error.IsNullOrWhiteSpace(key),
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null, an empty string, or consists only of white-space characters, with a custom error message.
    /// If the key is not null, not empty, and not just white-space, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNullOrWhiteSpace(string key, string value, string message)
    {
        ValidationRuleRunners.IsNullOrWhiteSpace(
            value,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="greaterThan">The integer value that the length of the key should be greater than.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsLengthGreaterThan(string key, string value, int greaterThan)
    {
        ValidationRuleRunners.IsLengthGreaterThan(
            value,
            greaterThan,
            key,
            Error.IsGreaterThan(key, greaterThan),
            null,
            this.PublishException);
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value, with a custom error message.
    /// If the key is null or empty, or its length is not greater than the provided value, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="greaterThan">The integer value that the length of the key should be greater than.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsLengthGreaterThan(string key, string value, int greaterThan, string message)
    {
        ValidationRuleRunners.IsLengthGreaterThan(
            value,
            greaterThan,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="lowerThan">The integer value that the length of the key should be less than.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsLengthLowerThan(string key, string value, int lowerThan)
    {
        ValidationRuleRunners.IsLengthLowerThan(
            value,
            lowerThan,
            key,
            Error.IsLowerThan(key, lowerThan),
            null,
            this.PublishException);
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is less than the provided value, with a custom error message.
    /// If the key is null or empty, or its length is not less than the provided value, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="lowerThan">The integer value that the length of the key should be less than.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsLengthLowerThan(string key, string value, int lowerThan, string message)
    {
        ValidationRuleRunners.IsLengthLowerThan(
            value,
            lowerThan,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Validates that the given GUID is not empty. If the GUID is empty, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the GUID value being validated.</param>
    /// <param name="value">The GUID value to be validated.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> IsGuidNotEmpty(string key, Guid value)
    {
        ValidationRuleRunners.IsGuidNotEmpty(
            value,
            key,
            Error.IsNotNull(key), // Original uses Error.IsNotNull for this case
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Validates that the given GUID is not empty. If the GUID is empty, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the GUID value being validated.</param>
    /// <param name="value">The GUID value to be validated.</param>
    /// <param name="message">The custom message for the domain exception if the validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> IsGuidNotEmpty(string key, Guid value, string message)
    {
        ValidationRuleRunners.IsGuidNotEmpty(
            value,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Compares two string values. If the values are not equal, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, string value, string compareValue)
    {
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            Error.Compare(key, compareValue),
            StringComparison.Ordinal,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Compares two string values. If the values are not equal, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="message">The custom message for the domain exception if the validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, string value, string compareValue, string message)
    {
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            message,
            StringComparison.Ordinal,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Compares two string values using the specified comparison type. If the values are not equal, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="comparisonType">The type of string comparison to perform.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, string value, string compareValue, StringComparison comparisonType)
    {
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            Error.Compare(key, compareValue),
            comparisonType,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Compares two string values using the specified comparison type. If the values are not equal, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="comparisonType">The type of string comparison to perform.</param>
    /// <param name="message">The custom message for the domain exception if the comparison fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, string value, string compareValue, StringComparison comparisonType, string message)
    {
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            message,
            comparisonType,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Compares two GUID values. If the values are not equal, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The GUID value to be compared.</param>
    /// <param name="compareValue">The GUID value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, Guid value, Guid compareValue)
    {
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            Error.Compare(key, compareValue.ToString()), // Error.Compare expects string for value
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Compares two GUID values. If the values are not equal, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The GUID value to be compared.</param>
    /// <param name="compareValue">The GUID value to compare against.</param>
    /// <param name="message">The custom message for the domain exception if the comparison fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, Guid value, Guid compareValue, string message)
    {
        ValidationRuleRunners.Compare(
            value,
            compareValue,
            key,
            message,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }
}
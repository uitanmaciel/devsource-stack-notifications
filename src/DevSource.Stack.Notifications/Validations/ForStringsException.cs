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
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> MaxLength(string key, string value, int maxLength)
    {
        if (value.Length > maxLength)
            PublishException(new DomainException(Error.MaxLength(key, maxLength)));
        
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
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> MaxLength(string key, string value, int maxLength, string message)
    {
        if (value.Length > maxLength)
            PublishException(new DomainException(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the string meets or exceeds the specified minimum length.
    /// If the key is null or empty, or if the length is less than the specified minimum, a domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="minLength">The minimum required length for the string.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> MinLength(string key, string value, int minLength)
    {
        if (value.Length < minLength)
            PublishException(new DomainException(Error.MinLength(key, minLength)));
        
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
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> MinLength(string key, string value, int minLength, string message)
    {
        if (value.Length < minLength)
            PublishException(new DomainException(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is not null or an empty string.
    /// If the key is null or empty, a standard domain exception indicating the field should not be null is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNotNull(string key, string value)
    {
        if (string.IsNullOrEmpty(value))
            PublishException(new DomainException(Error.IsNotNull(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is not null or an empty string, with a custom error message.
    /// If the key is null or empty, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNotNull(string key, string value, string message)
    {
        if (string.IsNullOrEmpty(value))
            PublishException(new DomainException(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given string value is not null or empty. If the value is null or empty, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRulesException<T> IsNotNullOrEmpty(string key, string value)
    {
        if (string.IsNullOrEmpty(value))
            PublishException(new DomainException(Error.IsNotNullOrEmpty(key)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that a given string value is not null or empty. If the value is null or empty, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom message for the domain exception if the validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRulesException<T> IsNotNullOrEmpty(string key, string value, string message)
    {
        if (string.IsNullOrEmpty(value))
            PublishException(new DomainException(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null or an empty string.
    /// If the key is not null or empty, a standard domain exception indicating the field should be null is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNull(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
            PublishException(new DomainException(Error.IsNull(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null or an empty string, with a custom error message.
    /// If the key is not null or empty, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNull(string key, string value, string message)
    {
        if (!string.IsNullOrEmpty(value))
            PublishException(new DomainException(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null or an empty string.
    /// If the key is not null and not empty, a standard domain exception indicating the field should be null or empty is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNullOrEmpty(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
            PublishException(new DomainException(key, Error.IsNullOrEmpty(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null or an empty string, with a custom error message.
    /// If the key is not null and not empty, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNullOrEmpty(string key, string value, string message)
    {
        if (!string.IsNullOrEmpty(value))
            PublishException(new DomainException(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null, an empty string, or consists only of white-space characters.
    /// If the key is not null, not empty, and not just white-space, a standard domain exception indicating the field should be null or white-space is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNullOrWhiteSpace(string key, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            PublishException(new DomainException(key, Error.IsNullOrWhiteSpace(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key is null, an empty string, or consists only of white-space characters, with a custom error message.
    /// If the key is not null, not empty, and not just white-space, a custom domain exception is added using the provided message.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the domain exception if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsNullOrWhiteSpace(string key, string value, string message)
    {
        if (!string.IsNullOrWhiteSpace(value))
            PublishException(new DomainException(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is greater than the provided value.
    /// If the key is null or empty, or its length is not greater than the provided value, a standard domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="greaterThan">The integer value that the length of the key should be greater than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsLengthGreaterThan(string key, string value, int greaterThan)
    {
        if (value.Length < greaterThan)
            PublishException(new DomainException(Error.IsGreaterThan(key, greaterThan)));
        
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
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsLengthGreaterThan(string key, string value, int greaterThan, string message)
    {
        if (value.Length < greaterThan)
            PublishException(new DomainException(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the length of the specified key is less than the provided value.
    /// If the key is null or empty, or its length is not less than the provided value, a standard domain exception is added.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="lowerThan">The integer value that the length of the key should be less than.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsLengthLowerThan(string key, string value, int lowerThan)
    {
        if (value.Length > lowerThan)
            PublishException(new DomainException(Error.IsLowerThan(key, lowerThan)));
        
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
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsLengthLowerThan(string key, string value, int lowerThan, string message)
    {
        if (value.Length > lowerThan)
            PublishException(new DomainException(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the given GUID is not empty. If the GUID is empty, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the GUID value being validated.</param>
    /// <param name="value">The GUID value to be validated.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> IsGuidNotEmpty(string key, Guid value)
    {
        if (value == Guid.Empty)
            PublishException(new DomainException(Error.IsNotNull(key)));
        
        return this;
    }
    
    /// <summary>
    /// Validates that the given GUID is not empty. If the GUID is empty, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the GUID value being validated.</param>
    /// <param name="value">The GUID value to be validated.</param>
    /// <param name="message">The custom message for the domain exception if the validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> IsGuidNotEmpty(string key, Guid value, string message)
    {
        if (value == Guid.Empty)
            PublishException(new DomainException(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two string values. If the values are not equal, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, string value, string compareValue)
    {
        if (value != compareValue)
            PublishException(new DomainException(Error.Compare(key, compareValue)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two string values. If the values are not equal, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="message">The custom message for the domain exception if the validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, string value, string compareValue, string message)
    {
        if (value != compareValue)
            PublishException(new DomainException(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two string values using the specified comparison type. If the values are not equal, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="comparisonType">The type of string comparison to perform.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, string value, string compareValue, StringComparison comparisonType)
    {
        if (!string.Equals(value, compareValue, comparisonType))
            PublishException(new DomainException(Error.Compare(key, compareValue)));
        
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
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, string value, string compareValue, StringComparison comparisonType, string message)
    {
        if (!string.Equals(value, compareValue, comparisonType))
            PublishException(new DomainException(key, message));
        
        return this;
    }
    
    /// <summary>
    /// Compares two GUID values. If the values are not equal, adds a domain exception.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The GUID value to be compared.</param>
    /// <param name="compareValue">The GUID value to compare against.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, Guid value, Guid compareValue)
    {
        if (value != compareValue)
            PublishException(new DomainException(Error.Compare(key, compareValue)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two GUID values. If the values are not equal, adds a domain exception with a custom message.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The GUID value to be compared.</param>
    /// <param name="compareValue">The GUID value to compare against.</param>
    /// <param name="message">The custom message for the domain exception if the comparison fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRulesException<T> Compare(string key, Guid value, Guid compareValue, string message)
    {
        if (value != compareValue)
            PublishException(new DomainException(key, message));
        
        return this;
    }
}
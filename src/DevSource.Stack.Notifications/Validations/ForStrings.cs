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

    /// <summary>
    /// Validates that the string has an exact length.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="length">The exact required length for the string.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasExactLength(string key, string value, int length)
    {
        if (value?.Length != length)
            AddNotification(new Notification(Error.ExactLength(key, length)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string has an exact length, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="length">The exact required length for the string.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasExactLength(string key, string value, int length, string message)
    {
        if (value?.Length != length)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string contains only allowed characters.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="allowedChars">The string containing all allowed characters.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> ContainsOnly(string key, string value, string allowedChars)
    {
        if (value?.Any(c => !allowedChars.Contains(c)) == true)
            AddNotification(new Notification(Error.ContainsInvalidCharacters(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string contains only allowed characters, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="allowedChars">The string containing all allowed characters.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> ContainsOnly(string key, string value, string allowedChars, string message)
    {
        if (value?.Any(c => !allowedChars.Contains(c)) == true)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string contains only letters.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsAlphabetic(string key, string value)
    {
        if (string.IsNullOrEmpty(value) || !value.All(char.IsLetter))
            AddNotification(new Notification(Error.MustBeAlphabetic(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string contains only letters, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsAlphabetic(string key, string value, string message)
    {
        if (string.IsNullOrEmpty(value) || !value.All(char.IsLetter))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string is alphanumeric (contains only letters and digits).
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsAlphanumeric(string key, string value)
    {
        if (string.IsNullOrEmpty(value) || !value.All(char.IsLetterOrDigit))
            AddNotification(new Notification(Error.MustBeAlphanumeric(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string is alphanumeric (contains only letters and digits), with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsAlphanumeric(string key, string value, string message)
    {
        if (string.IsNullOrEmpty(value) || !value.All(char.IsLetterOrDigit))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string contains only digits.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNumeric(string key, string value)
    {
        if (string.IsNullOrEmpty(value) || !value.All(char.IsDigit))
            AddNotification(new Notification(Error.MustBeNumeric(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string contains only digits, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNumeric(string key, string value, string message)
    {
        if (string.IsNullOrEmpty(value) || !value.All(char.IsDigit))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string is a valid URL.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsUrl(string key, string value)
    {
        if (!Uri.TryCreate(value, UriKind.Absolute, out var uri) || 
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            AddNotification(new Notification(Error.InvalidUrl(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string is a valid URL, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsUrl(string key, string value, string message)
    {
        if (!Uri.TryCreate(value, UriKind.Absolute, out var uri) || 
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string matches a specific regex pattern.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="pattern">The regex pattern to match.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MatchesPattern(string key, string value, string pattern)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(value ?? "", pattern))
            AddNotification(new Notification(Error.PatternMismatch(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string matches a specific regex pattern, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="pattern">The regex pattern to match.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MatchesPattern(string key, string value, string pattern, string message)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(value ?? "", pattern))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string starts with a specific prefix.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="prefix">The required prefix.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> StartsWith(string key, string value, string prefix)
    {
        if (!value?.StartsWith(prefix) == true)
            AddNotification(new Notification(Error.MustStartWith(key, prefix)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string starts with a specific prefix, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="prefix">The required prefix.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> StartsWith(string key, string value, string prefix, string message)
    {
        if (!value?.StartsWith(prefix) == true)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string ends with a specific suffix.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="suffix">The required suffix.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> EndsWith(string key, string value, string suffix)
    {
        if (!value?.EndsWith(suffix) == true)
            AddNotification(new Notification(Error.MustEndWith(key, suffix)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string ends with a specific suffix, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="suffix">The required suffix.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> EndsWith(string key, string value, string suffix, string message)
    {
        if (!value?.EndsWith(suffix) == true)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string contains a specific substring.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="substring">The required substring.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> Contains(string key, string value, string substring)
    {
        if (!value?.Contains(substring) == true)
            AddNotification(new Notification(Error.MustContain(key, substring)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string contains a specific substring, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="substring">The required substring.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> Contains(string key, string value, string substring, string message)
    {
        if (!value?.Contains(substring) == true)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string is uppercase.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsUpperCase(string key, string value)
    {
        if (value != value?.ToUpper())
            AddNotification(new Notification(Error.MustBeUpperCase(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string is uppercase, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsUpperCase(string key, string value, string message)
    {
        if (value != value?.ToUpper())
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that the string is lowercase.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerCase(string key, string value)
    {
        if (value != value?.ToLower())
            AddNotification(new Notification(Error.MustBeLowerCase(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that the string is lowercase, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerCase(string key, string value, string message)
    {
        if (value != value?.ToLower())
            AddNotification(new Notification(key, message));
        
        return this;
    }
}
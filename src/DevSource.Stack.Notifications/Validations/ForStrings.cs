namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that the length of the string does not exceed the specified maximum length.    
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="maxLength">The maximum allowed length for the string.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MaxLength(string key, string? value, int maxLength, string? message = null)
        => IfInvalid(value is not null && value.Length > maxLength, 
                    key, 
                    message ?? Error.MaxLength(key, maxLength));    

    /// <summary>
    /// Validates that the length of the string meets or exceeds the specified minimum length.    
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="minLength">The minimum required length for the string.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MinLength(string key, string? value, int minLength, string? message = null)
        => IfInvalid(value is not null && value.Length < minLength, 
                    key, 
                    message ?? Error.MinLength(key, minLength));    

    /// <summary>
    /// Validates that the string has an exact length.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="length">The exact required length for the string.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasExactLength(string key, string? value, int length, string? message = null)
        => IfInvalid(IsMissing(value) || value!.Length != length, 
                    key, 
                    message ?? Error.ExactLength(key, length));
    
    /// <summary>
    /// Validates that a given string value is not null or empty. If the value is null or empty, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message for the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> for method chaining.</returns>
    public ValidationRules<T> IsNotNullOrEmpty(string key, string? value, string? message = null)
        => IfInvalid(string.IsNullOrEmpty(value), 
                    key, 
                    message ?? Error.IsNullOrEmpty(key));

    /// <summary>
    /// Determines whether the provided value is <c>null</c>, empty or contains
    /// only white-space characters. When such a value is detected, a
    /// notification is added indicating the field must have a value.
    /// </summary>
    /// <param name="key">The key representing the field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message for the notification.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNullOrWhiteSpace(string key, string? value, string? message = null)
        => IfInvalid(IsMissing(value), 
                    key, 
                    message ?? Error.IsNullOrWhiteSpace(key));    
    
    /// <summary>
    /// Validates that the given GUID is not empty. If the GUID is empty, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the GUID value being validated.</param>
    /// <param name="value">The GUID value to be validated.</param>
    /// <param name="message">The custom error message for the notification.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> IsGuidNotEmpty(string key, Guid value, string? message = null)
        => IfInvalid(value == Guid.Empty, 
                    key, 
                    message ?? Error.IsGuidNotEmpty(key));
    
    /// <summary>
    /// Compares two string values. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    [Obsolete("This method is deprecated. Use the overload that accepts a StringComparison parameter for more control over the comparison behavior.")]
    public ValidationRules<T> Compare(string key, string value, string compareValue, string? message = null)
    {
        if (value != compareValue)
            AddNotification(new Notification(key, message ?? Error.Compare(key, compareValue)));
        
        return this;
    }
    
    /// <summary>
    /// Compares two string values using the specified comparison type. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="comparison">The type of string comparison to perform.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(
        string key, 
        string? value, 
        string? compareValue, 
        StringComparison comparison = StringComparison.Ordinal, 
        string? message = null)
        => IfInvalid(!string.Equals(value, compareValue, comparison), 
                    key, 
                    message ?? Error.Compare(key, compareValue!));
    
    /// <summary>
    /// Compares two GUID values. If the values are not equal, adds a notification.
    /// </summary>
    /// <param name="key">The key associated with the value being validated.</param>
    /// <param name="value">The GUID value to be compared.</param>
    /// <param name="compareValue">The GUID value to compare against.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> Compare(string key, Guid value, Guid compareValue, string? message = null)
        => IfInvalid(value != compareValue, 
                    key, 
                    message ?? Error.Compare(key, compareValue));

    /// <summary>
    /// Validates that the provided value matches the specified comparison value. If the values do not match, adds a notification.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="key">The key identifying the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class for method chaining.</returns>
    public ValidationRules<T> MustMatch<TValue>(string key, TValue value, TValue compareValue, string? message = null)
        => IfInvalid(!EqualityComparer<TValue>.Default.Equals(value, compareValue), 
                    key, 
                    message ?? Error.MustMatch(key, compareValue!));

    /// <summary>
    /// Validates that the string contains only allowed characters.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="allowedChars">The string containing all allowed characters.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> ContainsOnly(string key, string? value, string? allowedChars, string? message = null)
        => IfInvalid(value?.Any(c => !allowedChars!.Contains(c)) == true, 
                    key, 
                    message ?? Error.ContainsInvalidCharacters(key));    

    /// <summary>
    /// Validates that the string contains only letters.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsAlphabetic(string key, string? value, string? message = null)
        => IfInvalid(IsMissing(value) || !value!.All(char.IsLetter), 
                    key, 
                    message ?? Error.MustBeAlphabetic(key));    

    /// <summary>
    /// Validates that the string is alphanumeric (contains only letters and digits).
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsAlphanumeric(string key, string? value, string? message = null)
        => IfInvalid(IsMissing(value) || !value!.All(char.IsLetterOrDigit), 
                    key, 
                    message ?? Error.MustBeAlphanumeric(key));    

    /// <summary>
    /// Validates that the string contains only digits.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsNumeric(string key, string? value, string? message = null)
        => IfInvalid(IsMissing(value) || !value!.All(char.IsDigit), 
                    key, 
                    message ?? Error.MustBeNumeric(key));

    /// <summary>
    /// Validates that the string is a valid URL.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsUrl(string key, string? value, string? message = null)
    {
        if (IsMissing(value))
            return Notify(key, Error.InvalidUrl(key));

        if (!Uri.TryCreate(value, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            return Notify(key, message ?? Error.InvalidUrl(key));
        
        return this;
    }    

    /// <summary>
    /// Validates that the string matches a specific regex pattern.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="pattern">The regex pattern to match.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> MatchesPattern(string key, string? value, string pattern, string? message = null)
        => IfInvalid(IsMissing(value) || 
                     !System.Text.RegularExpressions.Regex.IsMatch(value!, pattern),
                     key,
                     message ?? Error.PatternMismatch(key));    

    /// <summary>
    /// Validates that the string starts with a specific prefix.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="prefix">The required prefix.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> StartsWith(string key, string? value, string prefix, string? message = null)
        => IfInvalid(IsMissing(value) ||
                     !value!.StartsWith(prefix, StringComparison.Ordinal),
                     key,
                     message ?? Error.MustStartWith(key, prefix));

    /// <summary>
    /// Validates that the string ends with a specific suffix.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="suffix">The required suffix.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> EndsWith(string key, string? value, string suffix, string? message = null)
        => IfInvalid(IsMissing(value) ||
                     !value!.EndsWith(suffix, StringComparison.Ordinal),
                     key,
                     message ?? Error.MustEndWith(key, suffix));    

    /// <summary>
    /// Validates that the string contains a specific substring.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="substring">The required substring.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> Contains(string key, string? value, string substring, string? message = null)
        => IfInvalid(IsMissing(value) ||
                     !value!.Contains(substring, StringComparison.Ordinal),
                     key,
                     message ?? Error.MustContain(key, substring));    

    /// <summary>
    /// Validates that the string is uppercase.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsUpperCase(string key, string? value, string? message = null)
        => IfInvalid(IsMissing(value) ||
                     !value!.Equals(value.ToUpperInvariant(), StringComparison.Ordinal),
                     key,
                     message ?? Error.MustBeUpperCase(key));    

    /// <summary>
    /// Validates that the string is lowercase.
    /// </summary>
    /// <param name="key">The key representing the string field in the object being validated.</param>
    /// <param name="value">The string value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsLowerCase(string key, string? value, string? message = null)
        => IfInvalid(IsMissing(value) ||
                     !value!.Equals(value.ToLowerInvariant(), StringComparison.Ordinal),
                     key,
                     message ?? Error.MustBeLowerCase(key));
}
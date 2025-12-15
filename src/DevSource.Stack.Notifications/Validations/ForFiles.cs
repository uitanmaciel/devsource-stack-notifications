namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that a file size does not exceed the specified maximum size in bytes.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="fileSize">The file size in bytes.</param>
    /// <param name="maxSizeInBytes">The maximum allowed file size in bytes.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasMaxFileSize(string key, long fileSize, long maxSizeInBytes)
    {
        if (fileSize > maxSizeInBytes)
            AddNotification(new Notification(Error.FileMaxSizeExceeded(key, maxSizeInBytes)));
        
        return this;
    }

    /// <summary>
    /// Validates that a file size does not exceed the specified maximum size in bytes, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="fileSize">The file size in bytes.</param>
    /// <param name="maxSizeInBytes">The maximum allowed file size in bytes.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasMaxFileSize(string key, long fileSize, long maxSizeInBytes, string message)
    {
        if (fileSize > maxSizeInBytes)
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that a file has a valid extension from the allowed list.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="fileName">The file name with extension.</param>
    /// <param name="allowedExtensions">Array of allowed file extensions (e.g., ".jpg", ".png", ".pdf").</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasValidExtension(string key, string fileName, params string[] allowedExtensions)
    {
        var extension = Path.GetExtension(fileName)?.ToLower();
        
        if (!allowedExtensions.Any(ext => ext.ToLower() == extension))
            AddNotification(new Notification(Error.InvalidFileExtension(key, string.Join(", ", allowedExtensions))));
        
        return this;
    }

    /// <summary>
    /// Validates that a file has a valid extension from the allowed list, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="fileName">The file name with extension.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <param name="allowedExtensions">Array of allowed file extensions (e.g., ".jpg", ".png", ".pdf").</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasValidExtension(string key, string fileName, string message, params string[] allowedExtensions)
    {
        var extension = Path.GetExtension(fileName)?.ToLower();
        
        if (!allowedExtensions.Any(ext => ext.ToLower() == extension))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Validates that a file has a valid MIME type from the allowed list.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="mimeType">The MIME type of the file (e.g., "image/jpeg", "application/pdf").</param>
    /// <param name="allowedMimeTypes">Array of allowed MIME types.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasValidMimeType(string key, string mimeType, params string[] allowedMimeTypes)
    {
        if (!allowedMimeTypes.Contains(mimeType?.ToLower()))
            AddNotification(new Notification(Error.InvalidMimeType(key)));
        
        return this;
    }

    /// <summary>
    /// Validates that a file has a valid MIME type from the allowed list, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="mimeType">The MIME type of the file (e.g., "image/jpeg", "application/pdf").</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <param name="allowedMimeTypes">Array of allowed MIME types.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasValidMimeType(string key, string mimeType, string message, params string[] allowedMimeTypes)
    {
        if (!allowedMimeTypes.Contains(mimeType?.ToLower()))
            AddNotification(new Notification(key, message));
        
        return this;
    }
}

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that a file size does not exceed the specified maximum size in bytes.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="fileSize">The file size in bytes.</param>
    /// <param name="maxSizeInBytes">The maximum allowed file size in bytes.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasMaxFileSize(string key, long fileSize, long maxSizeInBytes, string? message = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxSizeInBytes);

        if (fileSize > maxSizeInBytes)
        {
            AddNotification(
                key,
                message ?? Error.FileMaxSizeExceeded(key, maxSizeInBytes));
        }
        
        return this;
    }
    

    /// <summary>
    /// Validates that a file has a valid extension from the allowed list.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="fileName">The file name with extension.</param>
    /// <param name="allowedExtensions">Array of allowed file extensions (e.g., ".jpg", ".png", ".pdf").</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasValidExtension(string key, string? fileName, string[] allowedExtensions, string? message = null)
    {
        if (IsMissing(fileName)) return this;

        if (allowedExtensions == null || allowedExtensions.Length == 0)
            throw new ArgumentException("Allowed extensions must be provided.");

        var extension = Path.GetExtension(fileName);

        if (string.IsNullOrWhiteSpace(extension))
        {
            AddNotification(
                key,
                message ?? Error.InvalidFileExtension(key, string.Join(", ", allowedExtensions)));
            return this;
        }

        var allowedSet = new HashSet<string>(
            allowedExtensions,
            StringComparer.OrdinalIgnoreCase);

        if (!allowedSet.Contains(extension))
        {
            AddNotification(
                key,
                message ?? Error.InvalidFileExtension(key, string.Join(", ", allowedExtensions)));
        }
        
        return this;
    }    

    /// <summary>
    /// Validates that a file has a valid MIME type from the allowed list, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the file field in the object being validated.</param>
    /// <param name="mimeType">The MIME type of the file (e.g., "image/jpeg", "application/pdf").</param>
    /// <param name="allowedMimeTypes">Array of allowed MIME types.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> HasValidMimeType(string key, string mimeType, string[] allowedMimeTypes, string? message = null)
    {
        if (IsMissing(mimeType)) return this;

        if (allowedMimeTypes == null || allowedMimeTypes.Length == 0)
            throw new ArgumentException("Allowed MIME types must be provided.");

        var allowedSet = new HashSet<string>(
            allowedMimeTypes,
            StringComparer.OrdinalIgnoreCase);

        if (!allowedSet.Contains(mimeType))
        {
            AddNotification(
                key,
                message ?? Error.InvalidMimeType(key));
        }
        
        return this;
    }
}

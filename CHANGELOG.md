# Changelog

All notable changes to this project will be documented in this file.

## [4.0.0] - 2026-02-20

### Breaking Changes
- **Validation Logic:** Changed validation logic for `IsBrazilianPhone`, `IsInternationalPhone`, `IsCreditCard`, `IsCpf`, `IsCnpj`, `HasValidMimeType`, `IsEmail`, and `IsPassword`. These methods now treat `null` or empty values as **valid** (optional fields) instead of invalid. To enforce required fields, you must now chain them with `IsNotNullOrEmpty` or `IsNullOrWhiteSpace`.
- **Method Signatures:** Refactored `INotifications.AddNotifications` and `Notifier.AddNotifications` to accept `INotifications` interface instead of the concrete `Notifier` class.
- **Removed Deprecated:** Removed deprecated methods and properties to clean up the API.

### Changed
- Updated `ValidationRules.Join` to accept `params INotifications[]` instead of `Notifier[]` for better flexibility.
- Updated `Notification.Key` property to be nullable (`string?`) to correctly reflect that notifications can exist without a key (global notifications).

### Fixed
- Fixed validation logic for several rules (Brazilian Documents, Credit Card, Phone, MimeType) so they don't incorrectly flag empty optional values.
- Fixed potential `NullReferenceException` in `MaxLength` and `MinLength` string validations by adding null checks before accessing properties.
- Fixed potential `ArgumentNullException` in `IsEmail` and `IsPassword` validations by adding checks for null or empty values before Regex matching.
- Fixed `IsCreditCardNotExpired` validation logic to use `DateTime.Now.Date`, preventing false positives when validating on the last day of the month due to time comparison.

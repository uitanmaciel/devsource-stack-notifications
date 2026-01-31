# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased]

### Changed
- Refactored `INotifications.AddNotifications` and `Notifier.AddNotifications` to accept `INotifications` interface instead of the concrete `Notifier` class, improving dependency inversion and testability.
- Updated `ValidationRules.Join` to accept `params INotifications[]` instead of `Notifier[]`.
- Updated `Notification.Key` property to be nullable (`string?`) to correctly reflect that notifications can exist without a key (e.g., general domain notifications).

### Fixed
- Fixed potential `NullReferenceException` in `MaxLength` and `MinLength` string validations by adding null checks before accessing `.Length`.
- Fixed potential `ArgumentNullException` in `IsEmail` and `IsPassword` validations by adding checks for null or empty values before Regex matching.
- Fixed `IsCreditCardNotExpired` validation logic to use `DateTime.Now.Date`, preventing false positives when validating on the last day of the month due to time comparison.

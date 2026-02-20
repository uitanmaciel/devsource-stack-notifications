namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates if the provided value is a valid CPF (Brazilian Individual Taxpayer Registry), with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the CPF field in the object being validated.</param>
    /// <param name="value">The CPF value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCpf(string key, string? value, string? message = null)
    {
        if (IsMissing(value)) return this;

        var digits = OnlyDigits(value!);

        if (!IsValidCpfInternal(digits))
            return Notify(key, message ?? Error.InvalidCpf(key));

        return this;
    }    

    /// <summary>
    /// Validates if the provided value is a valid CNPJ (Brazilian Company Taxpayer Registry), with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the CNPJ field in the object being validated.</param>
    /// <param name="value">The CNPJ value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCnpj(string key, string? value, string? message = null)
    {
        if (IsMissing(value)) return this;

        var digits = OnlyDigits(value!);

        if (!IsValidCnpjInternal(digits))
            return Notify(key, message ?? Error.InvalidCnpj(key));

        return this;
    }    

    private static bool IsValidCpfInternal(string cpf)
    {
        if (cpf.Length != 11)
            return false;

        if (cpf.Distinct().Count() == 1)
            return false;

        Span<int> numbers = stackalloc int[11];

        for (int i = 0; i < 11; i++)
            numbers[i] = cpf[i] - '0';

        // first digit
        var sum = 0;
        for (int i = 0; i < 9; i++)
            sum += numbers[i] * (10 - i);

        var remainder = sum % 11;
        var digit1 = remainder < 2 ? 0 : 11 - remainder;

        if (numbers[9] != digit1)
            return false;

        // second digit
        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += numbers[i] * (11 - i);

        remainder = sum % 11;
        var digit2 = remainder < 2 ? 0 : 11 - remainder;

        return numbers[10] == digit2;
    }

    private static bool IsValidCnpjInternal(string cnpj)
    {
        if (cnpj.Length != 14)
            return false;

        if (cnpj.Distinct().Count() == 1)
            return false;

        Span<int> numbers = stackalloc int[14];

        for (int i = 0; i < 14; i++)
            numbers[i] = cnpj[i] - '0';

        int[] m1 = [5,4,3,2,9,8,7,6,5,4,3,2];
        int[] m2 = [6,5,4,3,2,9,8,7,6,5,4,3,2];

        var sum = 0;
        for (int i = 0; i < 12; i++)
            sum += numbers[i] * m1[i];

        var remainder = sum % 11;
        var digit1 = remainder < 2 ? 0 : 11 - remainder;

        if (numbers[12] != digit1)
            return false;

        sum = 0;
        for (int i = 0; i < 13; i++)
            sum += numbers[i] * m2[i];

        remainder = sum % 11;
        var digit2 = remainder < 2 ? 0 : 11 - remainder;

        return numbers[13] == digit2;
    }
}

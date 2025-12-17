namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates if the provided value is a valid CPF (Brazilian Individual Taxpayer Registry).
    /// </summary>
    /// <param name="key">The key representing the CPF field in the object being validated.</param>
    /// <param name="value">The CPF value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCpf(string key, string value)
    {
        var cpf = value?.Replace(".", "").Replace("-", "").Trim();
        
        if (string.IsNullOrEmpty(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            AddNotification(new Notification(Error.InvalidCpf(key)));
            return this;
        }
        
        if (cpf.Distinct().Count() == 1)
        {
            AddNotification(new Notification(Error.InvalidCpf(key)));
            return this;
        }
        
        var tempCpf = cpf.Substring(0, 9);
        var sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(cpf[i].ToString()) * (10 - i);

        var remainder = sum % 11;
        var digit1 = remainder < 2 ? 0 : 11 - remainder;

        tempCpf += digit1;
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * (11 - i);

        remainder = sum % 11;
        var digit2 = remainder < 2 ? 0 : 11 - remainder;

        if (cpf != tempCpf + digit2)
            AddNotification(new Notification(Error.InvalidCpf(key)));

        return this;
    }

    /// <summary>
    /// Validates if the provided value is a valid CPF (Brazilian Individual Taxpayer Registry), with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the CPF field in the object being validated.</param>
    /// <param name="value">The CPF value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCpf(string key, string value, string message)
    {
        var cpf = value?.Replace(".", "").Replace("-", "").Trim();
        
        if (string.IsNullOrEmpty(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            AddNotification(new Notification(key, message));
            return this;
        }
        
        if (cpf.Distinct().Count() == 1)
        {
            AddNotification(new Notification(key, message));
            return this;
        }
        
        var tempCpf = cpf.Substring(0, 9);
        var sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(cpf[i].ToString()) * (10 - i);

        var remainder = sum % 11;
        var digit1 = remainder < 2 ? 0 : 11 - remainder;

        tempCpf += digit1;
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * (11 - i);

        remainder = sum % 11;
        var digit2 = remainder < 2 ? 0 : 11 - remainder;

        if (cpf != tempCpf + digit2)
            AddNotification(new Notification(key, message));

        return this;
    }

    /// <summary>
    /// Validates if the provided value is a valid CNPJ (Brazilian Company Taxpayer Registry).
    /// </summary>
    /// <param name="key">The key representing the CNPJ field in the object being validated.</param>
    /// <param name="value">The CNPJ value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCnpj(string key, string value)
    {
        var cnpj = value?.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
        
        if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14 || !cnpj.All(char.IsDigit))
        {
            AddNotification(new Notification(Error.InvalidCnpj(key)));
            return this;
        }
        
        if (cnpj.Distinct().Count() == 1)
        {
            AddNotification(new Notification(Error.InvalidCnpj(key)));
            return this;
        }
        
        int[] multiplier1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplier2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        var tempCnpj = cnpj.Substring(0, 12);
        var sum = 0;

        for (int i = 0; i < 12; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];

        var remainder = sum % 11;
        var digit1 = remainder < 2 ? 0 : 11 - remainder;

        tempCnpj += digit1;
        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

        remainder = sum % 11;
        var digit2 = remainder < 2 ? 0 : 11 - remainder;

        if (cnpj != tempCnpj + digit2)
            AddNotification(new Notification(Error.InvalidCnpj(key)));

        return this;
    }

    /// <summary>
    /// Validates if the provided value is a valid CNPJ (Brazilian Company Taxpayer Registry), with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the CNPJ field in the object being validated.</param>
    /// <param name="value">The CNPJ value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCnpj(string key, string value, string message)
    {
        var cnpj = value?.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
        
        if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14 || !cnpj.All(char.IsDigit))
        {
            AddNotification(new Notification(key, message));
            return this;
        }
        
        if (cnpj.Distinct().Count() == 1)
        {
            AddNotification(new Notification(key, message));
            return this;
        }
       
        int[] multiplier1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplier2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        var tempCnpj = cnpj.Substring(0, 12);
        var sum = 0;

        for (int i = 0; i < 12; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];

        var remainder = sum % 11;
        var digit1 = remainder < 2 ? 0 : 11 - remainder;

        tempCnpj += digit1;
        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

        remainder = sum % 11;
        var digit2 = remainder < 2 ? 0 : 11 - remainder;

        if (cnpj != tempCnpj + digit2)
            AddNotification(new Notification(key, message));

        return this;
    }
}

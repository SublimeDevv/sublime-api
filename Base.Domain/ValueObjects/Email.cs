namespace Base.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; } = null!;
        public Email(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            if (!email.Contains('@'))
            {
                throw new ArgumentException("Email is not valid.", nameof(email));
            }

            Value = email;

        }
    }
}

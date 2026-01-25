using Base.Domain.ValueObjects;

namespace Base.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        public Customer(string fullName, Email email)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be null or empty.", nameof(fullName));
            }

            if (email is null)
            {
                throw new ArgumentException("Email cannot be null.", nameof(email));
            }

            Id = Guid.CreateVersion7();
            FullName = fullName;
            Email = email;
        }

    }
}

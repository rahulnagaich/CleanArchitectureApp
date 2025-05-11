namespace CleanArchitectureApp.Domain.Entities
{
    public class Customer : BaseEntity<Guid>
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public ICollection<Order> Orders { get; private set; } = [];

        [SetsRequiredMembers]
        public Customer(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public Customer()
        {
            FullName = string.Empty;
            Email = string.Empty;
        }

        public void UpdateContact(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}

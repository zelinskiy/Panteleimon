public readonly record struct ContactDetails
{
    public string Email { get; }
    public string PhoneNumber { get; }

    public ContactDetails(string email, string phoneNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);

        Email = email;
        PhoneNumber = phoneNumber;
    }
}
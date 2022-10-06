namespace WebAPI.Models
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? ZipCode { get; set; }
    }
}

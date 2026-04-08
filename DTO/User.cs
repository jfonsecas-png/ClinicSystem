namespace DTO
{
    public class User : BaseClass
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? PatientId { get; set; }
    }
}
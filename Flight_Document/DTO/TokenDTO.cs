namespace Flight_Document.DTO
#nullable disable
{
    public class TokenDTO
    {
        public Guid AccountID { get; set; }
        public string Email { get; set; }
        public string AccountName { get; set; }

        public string Token { get; set; }
        public string Role { get; set; }
    }
}

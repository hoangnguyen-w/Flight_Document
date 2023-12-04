namespace Flight_Document.DTO
#nullable disable
{
    public class CreateAccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public Guid RoleID { get; set; }
    }
}

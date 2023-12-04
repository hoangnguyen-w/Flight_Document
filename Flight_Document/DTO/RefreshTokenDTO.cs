namespace Flight_Document.DTO
#nullable disable
{
    public class RefreshTokenDTO
    {
        public string Token { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}

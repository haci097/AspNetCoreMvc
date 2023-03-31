namespace AspNetCoreMvc.Models
{
    public class UserMaster
    {
        public int UserMasterId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}

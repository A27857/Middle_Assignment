namespace Middle_Assignments.Models.Users
{
    public class UpdateModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { set; get; }
        public int PhoneNumber { set; get; }
    }
}
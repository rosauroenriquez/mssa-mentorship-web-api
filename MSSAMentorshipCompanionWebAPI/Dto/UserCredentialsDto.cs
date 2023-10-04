namespace MSSAMentorshipCompanionWebAPI.Dto
{
    public class UserCredentialsDto
    {
        public string UserID { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public string AccountStatus { get; set; }
    }

    public class ChangePasswordDto 
    {
        public string UserID { get; set; }

        public string HashedPassword { get; set; }

    }

    public class ResetPasswordDto
    {
        public string UserID { get; set; }

        public bool Reset { get; set; }

    }

    public class UserLoginDto
    {
        public string EmailAddress { get; set; }

        public string HashedPassword { get; set; }
    }
}

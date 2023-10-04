using MSSAMentorshipCompanionWebAPI.Data;
using MSSAMentorshipCompanionWebAPI.Models;
using BCrypt.Net;

namespace MSSAMentorshipCompanionWebAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.UserCredentials.Any())
            {
                var initialUsers = new List<UserCredentials>()
                {
                    new UserCredentials()
                    {
                        UserID = "Admin0001",
                        EmailAddress = "admin.mssa@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("adminpassword"),
                        AccountStatus = "Active",
                        NeedPasswordReset = false,
                        Role = "admin",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Admin0001",
                            FirstName = "Admin",
                            LastName = "Admin",
                            LinkedInURL = "none",
                            JobTitle = "Admin"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "CDM0001",
                        EmailAddress = "cdm1@example.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("cdmpassword"),
                        AccountStatus = "Active",
                        NeedPasswordReset = false,
                        Role = "CDM",

                        UserProfile = new UserProfile()
                        {
                            UserID = "CDM0001",
                            FirstName = "Jen",
                            LastName = "Allsion",
                            LinkedInURL = "https://www.linkedin.com/in/jennifer-allison/",
                            JobTitle = "Career Development Manager"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Mentor0001",
                        EmailAddress = "mentor1@example.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("mentorpassword"),
                        AccountStatus = "Active",
                        NeedPasswordReset = false,
                        Role = "Mentor",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Mentor0001",
                            FirstName = "Shawn",
                            LastName = "Callahan",
                            LinkedInURL = "https://www.linkedin.com/in/shawn-callahan/",
                            JobTitle = "CSAM"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0001",
                        EmailAddress = "rosauro.o.enriquez@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password1"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0001",
                            FirstName = "Rosauro",
                            LastName = "Enriquez",
                            LinkedInURL = "https://www.linkedin.com/in/rosauroenriquez/",
                            JobTitle = "Aspiring Software Engineer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0002",
                        EmailAddress = "d.crow@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password2"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0002",
                            FirstName = "David",
                            LastName = "Crow",
                            LinkedInURL = "https://www.linkedin.com/in/davidcrow7/",
                            JobTitle = "Software Engineer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0003",
                        EmailAddress = "m.garcia@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password3"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0003",
                            FirstName = "Marco",
                            LastName = "Garcia",
                            LinkedInURL = "https://www.linkedin.com/in/marco-garcia2020/",
                            JobTitle = "Aspiring Software Developer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0004",
                        EmailAddress = "a.rhodes@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password4"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0004",
                            FirstName = "Austin",
                            LastName = "Rhodes",
                            LinkedInURL = "https://www.linkedin.com/in/austin--rhodes/",
                            JobTitle = "Aspiring Software Engineer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0005",
                        EmailAddress = "l.ruggieri@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password5"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0005",
                            FirstName = "Lindsay",
                            LastName = "Ruggieri",
                            LinkedInURL = "https://www.linkedin.com/in/lindsay-ruggieri/",
                            JobTitle = "Aspiring Software Engineer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0006",
                        EmailAddress = "c.morris@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password6"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0006",
                            FirstName = "Chris",
                            LastName = "Morris",
                            LinkedInURL = "https://www.linkedin.com/in/morris-christopher/",
                            JobTitle = "Aspiring Software Engineer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0007",
                        EmailAddress = "z.bailey@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password7"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0007",
                            FirstName = "Zachary",
                            LastName = "Bailey",
                            LinkedInURL = "https://www.linkedin.com/in/zbailey96/",
                            JobTitle = "Aspiring Software Engineer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0008",
                        EmailAddress = "d.melton@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password8"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0008",
                            FirstName = "Dex",
                            LastName = "Melton",
                            LinkedInURL = "https://www.linkedin.com/in/dexter-melton/",
                            JobTitle = "Aspiring Software Engineer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0009",
                        EmailAddress = "y.guan@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password9"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0009",
                            FirstName = "Yiyi",
                            LastName = "Guan",
                            LinkedInURL = "https://www.linkedin.com/in/yiyi-guan/",
                            JobTitle = "Aspiring Software Engineer"
                        }
                    },
                    new UserCredentials()
                    {
                        UserID = "Student0010",
                        EmailAddress = "a.bell@outlook.com",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("password10"),
                        AccountStatus = "Active",
                        NeedPasswordReset = true,
                        Role = "Student",

                        UserProfile = new UserProfile()
                        {
                            UserID = "Student0010",
                            FirstName = "Alex",
                            LastName = "Bell",
                            LinkedInURL = "https://www.linkedin.com/in/alex-w-bell/",
                            JobTitle = "Aspiring Software Engineer"
                        }
                    }
                };
                dataContext.UserCredentials.AddRange(initialUsers);
                dataContext.SaveChanges();
            }
        }
    }
}

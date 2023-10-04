using AutoMapper;
using MSSAMentorshipCompanionWebAPI.Dto;
using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserCredentials, UserCredentialsDto>();
            CreateMap<UserProfileDto, UserProfile>();
            CreateMap<ChangePasswordDto, UserCredentials>();
            CreateMap<ResetPasswordDto, UserCredentials>();
        }
    }
}

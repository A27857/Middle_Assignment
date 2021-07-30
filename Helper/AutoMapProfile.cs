using AutoMapper;
using Middle_Assignments.Models.Users;

namespace Middle_Assignments.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateUserModel, User>();
            //CreateMap<UpdateBookBorrowRequestModel, BookBorrowingRequest>();
        }
    }
}
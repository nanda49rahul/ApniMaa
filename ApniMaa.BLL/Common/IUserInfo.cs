using System;
namespace ApniMaa.Common
{
    public interface IUserInfo
    {
        string Email { get; set; }
        //int FleetId { get; set; }
        //string FleetName { get; set; }
        string FirstName { get; set; }
        string FullName { get; set; }
        bool IsAuthenticated { get; set; }
        string LastName { get; set; }
        int UserId { get; set; }
        int UserType { get; set; }
    }
}
